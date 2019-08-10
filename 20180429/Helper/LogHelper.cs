using System;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using _20180429.Helper.CalendarioHelper;

namespace _20180429.Helper.LogHelper {
    public class LogInfo {

        Calendario _calendario;
        public LogInfo() {
            _calendario = new Calendario();
        }

        private string CaminhoLog() {
            var caminho = string.Format(@"{0}\Log\{1}\{2}\"
                , Directory.GetCurrentDirectory()
                , _calendario.Ano()
                , _calendario.Mes());
            if (!Directory.Exists(caminho)) Directory.CreateDirectory(caminho);
            return caminho;
        }
        private string ArquivoLog(string id) {
            return CaminhoLog() + string.Format("{0}.{1}.log", _calendario.AnoMesDia(), id);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(2);
            return string.Format("{0} : {1} : {2}"
                , sf.GetMethod().Module.Name
                , sf.GetMethod().ReflectedType.Name
                , sf.GetMethod().Name);
        }
        public void RegLogError(Exception ex) {
            var agora = _calendario.Agora();
            var info = string.Format("{0} [{1}] Source: {2} Error: {3}"
                , agora
                , GetCurrentMethod()
                , ex.Source
                , ex.Message);
            File.AppendAllText(ArquivoLog("erro"), info + Environment.NewLine);
            info = string.Format("{0} StackTrace: {1}"
                , agora
                , ex.StackTrace);
            File.AppendAllText(ArquivoLog("erro.detalhe"), info + Environment.NewLine);
        }

        public void RegLogInfo(string info) {
            info = string.Format("{0} [{1}] Info: {2}"
                , _calendario.Agora()
                , GetCurrentMethod()
                , info);
            File.AppendAllText(ArquivoLog("info"), info + Environment.NewLine);
        }
    }
}