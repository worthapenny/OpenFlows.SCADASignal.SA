using OpenFlows.SCADASignal.SA.Application;
using OpenFlows.SCADASignal.SA.FormModel;
using OpenFlows.SCADASignal.SA.Support.Logging;
using Serilog;
using System;
using System.Threading;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA;

public static class Program
{
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    static extern bool AttachConsole(int dwProcessId);
    private const int ATTACH_PARENT_PROCESS = -1;

    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // redirect console output to parent process;
        // must be before any calls to Console.WriteLine()
        AttachConsole(ATTACH_PARENT_PROCESS);
        Console.WriteLine("");

        // Setup logger
        Logging.SetupLogger();

        // Catch all Exceptions
        System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        var appModel = new SCADASignalApplicationModel(args);
        var formModel = new SCADASignalsParentFormModel(appModel);

        AppManager.Instance.AppModel = appModel;
        AppManager.Instance.SCADASignalsParentFormModel = formModel;

        System.Windows.Forms.Application.Run(new Forms.SCADASignalsParentForm(formModel));
    }

    #region Static Methods
    static void OnException(Exception ex)
    {
        var message = $"Exception Message: {ex.Message}\n\rStack:\n\r{ex.StackTrace}";
        Console.WriteLine(message);

        Log.Error(ex, message);
    }
    #endregion

    #region Event Handlers
    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        OnException(e.Exception);
    }

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        OnException(e.ExceptionObject as Exception);
    }
    #endregion
    
}
