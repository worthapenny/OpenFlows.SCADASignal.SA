using Haestad.Domain;
using Haestad.Domain.ModelingObjects.Water;
using Haestad.Framework.Application;
using Haestad.Support.User;
using OpenFlows.SCADASignal.SA.Library;
using Serilog;
using System;
using System.IO;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.ComponentsModel;

public class OpenWaterDatabaseModelControlModel : HaestadUserControlModel
{
    #region Public Events
    public event EventHandler ModelOpened;
    #endregion

    #region Constructor
    public OpenWaterDatabaseModelControlModel(IApplicationModel appModel)
        : base("OpenWaterDatabaseModelControlModel", appModel)
    {
    }
    #endregion

    #region Public Methods
    public void CreateNewWaterModelDatabase(string newModelDatabaseFileFullPath, IProgressIndicator pi)
    {
        Log.Debug($"About to create a blank new model database...");

        var blankModelFilePath = Path.Combine(AppManager.WaterGEMSx64InstalledPath, PrototypeFileName);
        if (!File.Exists(blankModelFilePath))
            throw new FileNotFoundException($"Blank project template couldn't be located. Searched for: '{blankModelFilePath}'");

        pi.AddTask("About to create a new water model (database only)...");
        pi.IncrementTask();
        pi.BeginTask(1);

        File.Copy(blankModelFilePath, newModelDatabaseFileFullPath);
        Log.Information($"New model database created: {newModelDatabaseFileFullPath}");

        pi.IncrementStep();
        pi.EndTask();


        // Open up the newly created model
        ModelDatabaseFilePath = newModelDatabaseFileFullPath;
        OpenWaterModel(pi);

    }
    public bool OpenWaterModel(IProgressIndicator pi)
    {
        bool success = false;
        try
        {
            Log.Debug("About to open up the model...");
            pi.AddTask("About to open up the model...");
            pi.IncrementTask();
            pi.BeginTask(1);


            // CloseModelDatabase if any
            CloseModelDatabase();


            DataSource = new IdahoDataSource();
            DataSource.SetConnectionProperty(ConnectionProperty.FileName, ModelDatabaseFilePath);
            DataSource.SetConnectionProperty(ConnectionProperty.ConnectionType, ConnectionType.Sqlite);
            DataSource.SetConnectionProperty(ConnectionProperty.EnableSchemaUpdate, false);

            DataSource.Open();
            AppManager.Instance.DomainDataSet = DataSource.DomainDataSetManager.DomainDataSet(1);

            Log.Information($"Hydraulic model database got opened. Path: {ModelDatabaseFilePath}");

            pi.IncrementStep();
            pi.EndTask();

            success = true;
            ModelOpened?.Invoke(this, EventArgs.Empty);

        }
        catch (System.Runtime.InteropServices.SEHException sehEx)
        {
            string message =
                "Exception occurred while opening up the model.\n May be you are trying to open a model from a directory where _ADMIN_ right is required to edit files?. \n\n";

            Log.Error(sehEx, message);
        }
        catch (BadImageFormatException badImageEx)
        {
            string message =
                "Exception occurred while opening up the model. It appears 32/64 bit version conflict occurred. \n\n";

            Log.Error(badImageEx, message);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }


        LogLibrary.Separate_SuperSoft();
        return success;
    }

    public bool CloseModelDatabase()
    {
        if (DataSource?.IsOpen() ?? false)
        {
            Log.Debug($"About to close model database. Path: {ModelDatabaseFilePath}");
            DataSource.Close();
            DataSource.Dispose();
            Log.Information($"Model closed. Path: {ModelDatabaseFilePath}");

            DataSource = null;
            AppManager.Instance.DomainDataSet = null;

            ModelDatabaseFilePath = string.Empty;
            LogLibrary.Separate_EndMajor();

            return true;
        }

        return false;
    }

    public OpenFileDialog NewOpenExistingModelFileDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Select Water Model Database file";
        openFileDialog.Filter = "Water Model Files |*.wtg.sqlite";
        openFileDialog.CheckFileExists = true;
        openFileDialog.CheckPathExists = true;
        openFileDialog.Multiselect = false;

        return openFileDialog;
    }
    public OpenFileDialog NewOpenNewModelFileDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Create new Water Model Database file";
        openFileDialog.Filter = "Water Model Files |*.wtg.sqlite";
        openFileDialog.CheckFileExists = false;
        openFileDialog.CheckPathExists = true;
        openFileDialog.Multiselect = false;
        openFileDialog.FileName = "Untitled.wtg.sqlite";

        return openFileDialog;
    }
    #endregion

    #region Public Properties
    public string ModelDatabaseFilePath { get; set; }
    public string PrototypeFileName { get; } = "WaterPrototype.Sqlite.db";

    public IDomainDataSet DomainDataSet => AppManager.Instance.DomainDataSet;
    public IdahoDataSource DataSource { get; protected set; }

    #endregion
}
