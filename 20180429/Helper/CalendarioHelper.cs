using System;
using System.Globalization;

namespace _20180429.Helper.CalendarioHelper {
    public class Calendario {
        public Calendario() { }

        public string Ano() {
            return DateTime.Now.Year.ToString("0000");
        }       

        public string Mes() {
            return DateTime.Now.Month.ToString("00");
        }

        public string Dia() {
            return DateTime.Now.ToString();
        }
        public string AnoMesDia() {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        public string Agora() {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }

    }
}