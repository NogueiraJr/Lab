using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Application
{
    public class ArquivoFinalCsv : Arquivo
    {
		//private const string PrimeiraLinhaCsv = "Descricao;Valor;DataVencimento;Categoria;SubCategoria;Conta;Observacao";
        private const string TransferenciasInternas = "TransferenciasInternas";
        private const string CartaoCredito = "CartaoCredito";
        private const string ContaJuridica = "Teste";
		private const string SeparadorCampoApp = ",";
        private string ContaFinanceira = string.Empty;
        private decimal SaldoAnteriorValor = 0.00M;
        private decimal SaldoAtualValor = 0.00M;
		private string ExtensaoParametro = "txt";

        public List<string> LinhasEntrada { get; set; }
        public List<string> LinhasSaida { get; set; }
        List<Campos> DadosFinais { get; set; }
  
        private DateTime SaldoAnteriorData;
        private DateTime SaldoAtualData;

        private Campos _campos;

        public ArquivoFinalCsv() {
            DadosFinais = new List<Campos>();
        }

        public void GerarArquivoFinal()
        {
            TratarCaminho();
            TratarNomeArquivo();
            MontarDadosFinais();
            GravarDadosFinais();
        }

        private void GravarDadosFinais()
        {
            using(StreamWriter saida = new StreamWriter(string.Format("{0}{1}", Caminho, Nome))) {
                //saida.WriteLine(PrimeiraLinhaCsv);
                foreach (var dados in DadosFinais)
                {
                    //TODO: Gravar Transferências Internas em .csv a parte (importar ou não importar)
                    if (ParametroOperacional(TransferenciasInternas, dados.Observacoes)) continue;
                    //

                    //TODO: Gravar Pagamento Cartao de Crétido em .csv a parte (importar ou não importar)
                    if (ParametroOperacional(CartaoCredito, dados.Observacoes)) continue;
                    //

                    if (dados.Valor < 0)
                    {
                        saida.WriteLine(MontarLinhaSaida(dados));
                    }
                }
            }
        }

        /*private bool PagamentoCartaoCredito(string obs)
        {
            if ((obs.Contains("Pagamento")
                 && obs.Contains("BANCO SANTANDER"))) return true;
            return false;
        }*/

        private string MontarLinhaSaida(Campos dados)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
                                 SeparadorCampoApp,
                                 dados.Descricao,
                                 dados.Valor.ToString("N2").Replace(".", "").Replace(SeparadorCampoApp, ".").Replace("-", ""),
                                 dados.DataVencimento.ToString("d"),
                                 dados.Categoria,
                                 dados.SubCategoria,
                                 dados.Conta,
                                 dados.Observacoes);
        }

        private void MontarDadosFinais() {
            Campos campos;
            string observacoes = string.Empty;
            foreach (var linha in LinhasEntrada)
            {
                var linhaTratada = TratarLinhasDiferenciadas(linha);
                if (linhaTratada.Trim().Length == 0) continue;
                if (IdentificadaLinhaComplementar(linhaTratada))
                {
                    campos = new Campos();
                    campos = _campos;
                    campos.Observacoes += string.Format(" {0}", TirarEspacosDuplos(linhaTratada));
                    if (DadosFinais.Count > 0) DadosFinais.RemoveAt(DadosFinais.Count - 1);
                }
                else
                {
                    #region Tratar campo a campo
                    var valor = ObterValor(linhaTratada);
                    var dataVcto = ObterData(linhaTratada);
                    observacoes = TratarObservacoes(linhaTratada,
                                         dataVcto.ToShortDateString(),
                                         valor.ToString("N2"));
                    var categoria = ObterCategoria(observacoes);
                    var subCategoria = ObterSubCategoria(observacoes);
                    #endregion
                    campos = new Campos()
                    {
                        Descricao = string.Format("{0} | {1}", categoria, subCategoria),
                        Valor = valor,
                        DataVencimento = dataVcto,
                        Categoria = categoria,
                        SubCategoria = subCategoria,
                        Conta = ContaFinanceira,
                        Observacoes = observacoes
                    };
                }

				DadosFinais.Add(campos);
                _campos = campos;
            }
        }

        private bool ParametroOperacional(string parametro, string obs)
        {
            var parametrosOperacionais = new ParametrosOperacionais {
                Caminho = "../../files/param/",
                Nome = string.Format("{0}.{1}", parametro, ExtensaoParametro)
            };
            foreach (var item in parametrosOperacionais.ObterParametrosOperacionais())
            {
                if (ExisteEstaInformacao(obs, item)) { return true; }
            }
            return false;
        }

        private string ObterSubCategoria(string obs)
        {
            return "Semanal";
        }

        private string ObterCategoria(string obs)
        {
            return "Supermercado";
        }

        private string TratarObservacoes(string linhaTratada, string data, string valor)
        {
            var r = string.Empty;
            foreach (var info in linhaTratada.Split(' '))
            {
                if ((info.Trim() != data) 
                    && (info.Trim() != valor.Replace("-", ""))
                    && (info.Trim() != "(+)")
                    && (info.Trim() != "(-)")) r += string.Format("{0} ", info);
            }
            return r.Trim();
        }

        private string TirarEspacosDuplos(string linhaTratada)
        {
            return linhaTratada.Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
        }

        private bool IdentificadaLinhaComplementar(string linhaTratada)
        {
            return (ObterData(linhaTratada).ToShortDateString() == DateTime.Now.ToShortDateString());
        }

        private string TratarLinhasDiferenciadas(string linha)
        {
			#region Ignorados
			if (linha.Contains("Extrato de Conta Corrente")) return string.Empty;
			if (linha.Contains("Lançamentos")) return string.Empty;
			if (linha.Contains("Dia Histórico Valor")) return string.Empty;
			if (linha.Contains("Informações Adicionais")) return string.Empty;
			if (linha.Contains("Informações Adicionais")) return string.Empty;
			if (linha.Contains("Juros ")) return string.Empty;
			if (linha.Contains("Data de Debito de Juros")) return string.Empty;
			if (linha.Contains("IOF ")) return string.Empty;
			if (linha.Contains("Data de Debito de IOF ")) return string.Empty;
			if (linha.Contains("Lançamentos Futuros")) return string.Empty;
			if (linha.Contains("Total Aplicações Financeiras ")) return string.Empty;
			if (linha.Contains("Saldos por dia Base")) return string.Empty;
			if (linha.Contains("Sujeitos a confirmação no momento da contratação")) return string.Empty;
			if (linha.Contains("S A L D O")) return string.Empty;
			#endregion
			
            #region Cabeçalho
            if (linha.Contains("Cliente: OCTAL SYSTEM SC LTDA")) { ContaFinanceira = ContaJuridica; return string.Empty; }
            //if (linha.Contains("Agência: 6953-1")) { ContaFinanceira = ContaJuridica; return string.Empty; }
			if (linha.Contains("Conta: 109192-1")) { ContaFinanceira = ContaJuridica; return string.Empty; }
            if (linha.Contains(" Saldo Anterior ")) { 
                SaldoAnteriorValor = ObterValor(linha);
                SaldoAnteriorData = ObterData(linha);
                return string.Empty;
            }
			if (linha.Contains("Saldo Atual "))
			{
				SaldoAtualValor = ObterValor(linha);
				SaldoAtualData = ObterData(linha);
				return string.Empty;
			}
            #endregion
            
            return linha;
        }

        private DateTime ObterData(string linha)
        {
			var regEx = new Regex(@"^\d{2}\/\d{2}\/\d{4}", RegexOptions.Singleline);
			var valor = regEx.Matches(linha);
            if (valor.Count == 0) return DateTime.Now;
            return DateTime.Parse(valor[0].ToString());
        }

        private decimal ObterValor(string linha)
        {
            var r = 0.00M;
            var regEx = new Regex(@"\s\d*.\d*.\d*,\d*", RegexOptions.Singleline);
            var valor = regEx.Matches(linha);
            if (valor.Count == 0) return r;
            r = Decimal.Parse(valor[0].ToString());
            if (linha.Contains("(-)")) r = r * -1;
            return r;
        }

        private bool ExisteEstaInformacao(string linha, string info) {
            var expr = string.Empty;
            foreach (var item in info.Split(' '))
            {
                expr += string.Format(".*{0}", item);
            }
            expr += ".*";
            var regEx = new Regex(expr, RegexOptions.Singleline);
            var valor = regEx.Matches(linha);
            return (valor.Count > 0);
        }

        private void TratarNomeArquivo()
        {
            Nome += string.Format(".{0}", Tipo);
        }

        private void TratarCaminho()
        {
            Caminho = string.Format(Caminho, Tipo);
            if (!Directory.Exists(Caminho)) Directory.CreateDirectory(Caminho);
        }
    }

}
