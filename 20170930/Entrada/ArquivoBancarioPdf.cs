using System.IO;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using iTextSharp.text.pdf.parser;

namespace Application
{
    public class ArquivoBancarioPdf : Arquivo
    {
		public List<string> Linhas { get; set; }

        public ArquivoBancarioPdf(){
			Linhas = new List<string>();
		}

        public void LerConteudoPdfs() {
            var pasta = new DirectoryInfo(Caminho);
            var arquivos = pasta.GetFiles("*.pdf");

            foreach (var arquivo in arquivos)
            {
                using (PdfReader dados = new PdfReader(string.Format(@"{0}{1}", Caminho, arquivo.Name)))
                {
                    for (int i = 1; i <= dados.NumberOfPages; i++)
                    {
                        Linhas.AddRange(PdfTextExtractor.GetTextFromPage(dados, i).Split('\n'));
                    }
                }
            }
        }
    }
}
