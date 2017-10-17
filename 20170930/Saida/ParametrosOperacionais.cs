using System;
using System.Collections.Generic;
using System.IO;

namespace Application
{
    public class ParametrosOperacionais : Arquivo
    {
		public List<string> Info { get; set; }

        public ParametrosOperacionais() {
            Info = new List<string>();
        }

        public List<string> ObterParametrosOperacionais() {
            if (Info.Count == 0)
            {
                CarregarLinhasDoArquivo();
            }
            return Info;
        }

        private void CarregarLinhasDoArquivo()
        {
            var linha = string.Empty;
            using (StreamReader arquivo = new StreamReader(string.Format("{0}{1}", Caminho, Nome)))
            {
                do
                {
                    linha = arquivo.ReadLine();
                    if (linha.Length > 0)
                    {
                        Info.Add(linha);
                    }
                } while (!arquivo.EndOfStream);
            }
        }
    }
}