using System;

namespace InssTest {
    class MainClass {
        public static void Main() {
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2011"), 1000.00M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2011"), 1100.00M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2011"), 1102.00M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2011"), 1250.00M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2011"), 2857.00M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2011"), 2857.03M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2011"), 4000.99M));
            Console.WriteLine("");
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2012"), 1000.00M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2012"), 1127.54M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2012"), 1503.78M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2012"), 3058.23M));
            Console.WriteLine((new INSS.clsInss()).CalcularDesconto(Convert.ToDateTime("01/01/2012"), 5000.99M));

            //Console.ReadLine(); /* se Windows */
        }
    }
}
