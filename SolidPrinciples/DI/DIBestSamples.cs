using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DI
{
    public class DIBestSamples
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

        public interface ILogger
        {
            void Log(Log model);
        }
  
        public class TextLogger: ILogger
        {
            public void Log(Log model)
            {
                Console.WriteLine($"{model.Level} {model.Message}");
            }
        }

        public class DBLogger : ILogger
        {
            public void Log(Log model)
            {
                //DB Connection
                throw new NotImplementedException();
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

        public class PDFGenerator
        {
            //BAd Sample
            //private TextLogger logger;

            //public PDFGenerator()
            //{
            //    logger = new TextLogger();

            //}

            public PDFGenerator()
            {

            }

            private ILogger _logger;

            /// <summary>
            /// Property Injection yaptık ençok kullanılan DI tekniği
            /// </summary>
            public ILogger Logger { get { return _logger;  } set { _logger = value;  } }


            /// <summary>
            /// Constructor Injection Yaptık. En çok kullanılan DI yöntemi
            /// </summary>
            /// <param name="logger"></param>
            public PDFGenerator(ILogger logger)
            {
                _logger = logger;
            }


            public PDFResult GeneratePDF(string title, string body)
            {

                if(_logger != null)
                {
                    _logger.Log(new Log { Level = LogLevel.Warn, Message = "Dikkat" });
                }


                return new PDFResult();
            }

            /// <summary>
            /// bu method ile Method Injection yaptık
            /// </summary>
            /// <param name="title"></param>
            /// <param name="body"></param>
            /// <param name="logger"></param>
            /// <returns></returns>
            public PDFResult GeneratePDF(string title, string body, ILogger logger)
            {
                _logger = logger;

                _logger.Log(new Log { Level = LogLevel.Warn, Message = "Dikkat" });

                return new PDFResult();
            }

        }

    }
}
