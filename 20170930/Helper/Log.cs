using System;
using System.IO;
namespace Application.Helper
{
    public class Log : Arquivo
    {
        private void CriarPastaLog() {
            if (!Directory.Exists(Caminho))
            {
                Directory.CreateDirectory(base.Caminho);
            }
        }

        public void RegistrarLog(string info)
        {
            CriarPastaLog();
            using (StreamWriter log = new StreamWriter(string.Format("{0}{1}", Caminho, Nome), true)) {
                log.WriteLine(string.Format("{0} {1}", DateTime.Now.ToString("g"), info));
            }
        }
    }
}
