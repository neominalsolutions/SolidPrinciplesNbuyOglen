using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DI
{
    public class DIBadSamples
    {
        // senaryomuz pdf oluşturduktan sonra yapılan işleme ait loglama yapmak

        public static class LogLevel
        {
            public const string Info = "InformationLevel";
            public const string Error = "CriticalLevel";
            public const string Warn = "WarningLevel";

        }



        public class Log
        {
            public string Level { get; set; }
            public string Message { get; set; }
        }

  
        public class TextLogger: ILogger
        {
         

            public void Log(string message, string logLevel)
            {
                Console.WriteLine($"{logLevel} {message}");
            }
        }


        public class PDFResult
        {
            public int Size { get; set; }
            public string OriginalName { get; set; }
            public string DocumentUrl { get; set; }

            public bool IsSucceded { get; set; }

            public string ErrorMessage { get; set; }

        }

        public class JsonLogger : ILogger
        {
           
                public void Log(string message, string logLevel)
                {
                    Console.WriteLine($"{logLevel} {message}");
                }
            
        }

        public class PDFGenerator
        {
            //BAd Sample
            private JsonLogger _logger;
            private JsonLogger logger = new JsonLogger();

            public PDFGenerator()
            {
                _logger = new JsonLogger();

            }


            public PDFResult GeneratePDF(string title, string body)
            {

                if(_logger != null)
                {
                    _logger.Log("mesaj", "info");
                }


                return new PDFResult();
            }

        }

        /// <summary>
        /// 2. verisyon PDFGenerator2 direk instance almak yerine instance constructuredan gönderdim. Burada sadece DI uyguladık. Fakat PDFGenerator2 sınıfı olan üst seviye sınıfın  TextLogger sınıfı olan alt seviye sınıf ile bağımsız bir şekilde haberleşmesini hala sağlayamadık.
        /// </summary>

        public class PDFGenerator2
        {
            private TextLogger _logger;

            public PDFGenerator2(TextLogger logger)
            {
                _logger = logger;
            }

            public PDFResult GeneratePDF(string title, string body)
            {

                if (_logger != null)
                {
                    _logger.Log("mesaj", "info");
                }


                return new PDFResult();
            }
        }

        public interface ILogger
        {
            void Log(string message, string logLevel);
            
        }


        public class PDFGenerator3
        {
            private ILogger _logger; // PDFGenerator3 sınıfı ile TextLogger ve JsonLogger sınıflarını birbirleri ile direkt bağımlı yapmadığımdan araya bir interface koyarak. Sınıflar arasındaki bağlımlılığı azaltık. Loose-coupling (Zayıf bağlılık)

            public PDFGenerator3(ILogger logger)
            {
                _logger = logger;
            }

            public PDFResult GeneratePDF(string title, string body)
            {

                if (_logger != null)
                {
                    _logger.Log("mesaj","info");
                }


                return new PDFResult();
            }
        }


        class Sample
        {
            /// <summary>
            /// 1. Örnek
            /// </summary>
            void Sample1()
            {
                var result = new PDFGenerator();
                result.GeneratePDF("deneme", "test");
                // json log işlemi yapar
                // tight-coupled sıkı  sıkıya bağımlı sınıf
            }

            /// <summary>
            /// 2.Örnek
            /// </summary>
            void Sample2()
            {
                var result2 = new PDFGenerator2(new TextLogger());
                result2.GeneratePDF("deneme","test2");
                // hala text logger ile çalışıyoruz.
                // DI yaptık (contructor DI)
                // sub loose-coupled 
            }

            /// <summary>
            /// 3.Örnek
            /// </summary>
            void Sample3()
            {
                // DI yaptık hemde DIP
                var result3 = new PDFGenerator3(new TextLogger());
                result3.GeneratePDF("json1", "messaj1");

                var result4 = new PDFGenerator3(new JsonLogger());
                result4.GeneratePDF("json", "messaj");


            }
        }


    }
}
