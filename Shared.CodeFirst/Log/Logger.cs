using System;
using System.Diagnostics;
using log4net;

namespace QWERTY.Shared.Log
{
    public interface ILogger
    {
        void ОтправитьОшибкуВ_Лог(Exception? ex);
    }


///

/// гшвнпагшыврагшрывшарывшга

    public class HelpLogger
    {
        public HelpLogger()
        {
        }

        public static string СобратьВсеПодчиненныеОшибки(Exception? e)
        {
            var s = "";
            do
            {
                s += e?.Message + ".\n";
                e = e?.InnerException;
            } while (e != null);

            return s;
        }
    }

    public class Logger : ILogger
    {
        private readonly ILog _log;
        private readonly HelpLogger _helpLogger;

        public Logger(ILog? log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _helpLogger = new HelpLogger();
        }
        
        public void ОтправитьОшибкуВ_Лог(Exception? ex)
        {
            _log.Error(HelpLogger.СобратьВсеПодчиненныеОшибки(ex), ex);
            Debug.WriteLine(ex?.Message);
            Console.WriteLine(ex?.Message);
        }
    }
}