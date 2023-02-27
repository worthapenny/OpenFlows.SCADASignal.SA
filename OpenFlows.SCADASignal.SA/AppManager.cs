using Haestad.Domain;
using Haestad.Framework.Application;
using OpenFlows.SCADASignal.SA.FormModel;
using System;
using System.IO;

namespace OpenFlows.SCADASignal.SA;

public class AppManager
{
    #region Singleton Pattern
    private static AppManager _appManager = null;
    private static readonly object lockObject = new object();

    private AppManager() { }

    public static AppManager Instance
    {
        get
        {
            lock (lockObject)
            {
                if (_appManager == null)
                {
                    _appManager = new AppManager();

                    _appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), AppFQDN);
                    _appTempDir = Path.Combine(Path.GetTempPath(), AppFQDN);
                    _appLogDir = Path.Combine(_appTempDir, "Log");
                    _appTestDir = Path.Combine(_appTempDir, "Test");

                    if (!Directory.Exists(_appTempDir))
                        CreateDirectories();
                }
                return _appManager;
            }
        }
    }
    #endregion

    #region Constants
    public const string AppName = "SCADA Signals SA";
    public const string AppFQDN = "OpenFlows.SCADASignals.SA";
    public const string WaterGEMSInstalledPath = @"C:\Program Files (x86)\Bentley\WaterGEMS";
    public const string WaterGEMSx64InstalledPath = @"C:\Program Files (x86)\Bentley\WaterGEMS\x64";

    #endregion


    #region Public Properties
    public string AppTempDir => _appTempDir;
    public string AppDataDir => _appDataDir;
    public string AppLogDir => _appLogDir;
    public string AppTestDir => _appTestDir;
    public string AppGenericLogFilePath => Path.Combine(_appLogDir, $"{AppFQDN}..Log");
    public string AppLogFilePath { get; set; }
    public IDomainDataSet DomainDataSet { get; set; }
    public IApplicationModel AppModel { get; set; }
    public SCADASignalsParentFormModel SCADASignalsParentFormModel { get; set; }
    #endregion

    #region Private Static Methods
    private static void CreateDirectories()
    {
        Console.WriteLine($"About to create directories");
        Directory.CreateDirectory(_appDataDir);
        Directory.CreateDirectory(_appTempDir);
        Directory.CreateDirectory(_appLogDir);
        Directory.CreateDirectory(_appTestDir);

        Console.WriteLine($"Directories created. \n{_appDataDir}\n{_appTempDir}\n{_appLogDir}");
    }
    #endregion

    #region Private Fields

    static string _appDataDir;
    static string _appTempDir;
    static string _appLogDir;
    static string _appTestDir;
    #endregion
}
