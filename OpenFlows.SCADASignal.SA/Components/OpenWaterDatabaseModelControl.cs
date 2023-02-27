using Haestad.Framework.Windows.Forms.Components;
using Haestad.Framework.Windows.Forms.Forms;
using OpenFlows.SCADASignal.SA.ComponentsModel;
using Serilog;
using System;
using System.IO;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components;
public partial class OpenWaterDatabaseModelControl : HaestadUserControl
{
    #region Constructor
    public OpenWaterDatabaseModelControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overrridden Methods
    protected override void InitializeEvents()
    {
        // Model file path
        this.textBoxModelFilePath.TextChanged += (s, e) => ModelFilePathUpdated();

        // Browse or Open button
        this.buttonBrowseOrOpen.Click += (s, e) => BrowseOrOpenWaterModel();

        // Create New
        this.buttonCreateNew.Click += (s, e) => CreateNewWaterModel();

        base.InitializeEvents();
    }
    #endregion

    #region Private Methods

    private void ModelFilePathUpdated()
    {
        var isValidPath = File.Exists(this.textBoxModelFilePath.Text);
        this.buttonBrowseOrOpen.Enabled = !isValidPath;

        ModelController.ModelDatabaseFilePath = isValidPath
            ? this.textBoxModelFilePath.Text
            : string.Empty;

        Log.Debug($"Model file path is set to: {ModelController.ModelDatabaseFilePath}");
    }
    private void BrowseOrOpenWaterModel()
    {
        var dialogBox = ModelController.NewOpenExistingModelFileDialog();
        if (dialogBox.ShowDialog() == DialogResult.OK)
        {
            this.textBoxModelFilePath.Text = dialogBox.FileName;
            ModelController.ModelDatabaseFilePath = dialogBox.FileName;

            // Open model
            if (ModelController != null && File.Exists(ModelController.ModelDatabaseFilePath))
            {
                var pi = new ProgressIndicatorForm();
                try
                {
                    pi.Show();
                    var success = ModelController.OpenWaterModel(pi);
                    this.groupBoxModelControl.Enabled = AppManager.Instance.DomainDataSet == null;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"...while opening up the model. Path: {ModelController.ModelDatabaseFilePath}");
                    MessageBox.Show(this, $"Error occurred. Look at the log file for details.\nMessage:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    pi.Done();
                }
            }
        }
        else
            Log.Debug($"User cancelled the dialog box");
    }
    private void CreateNewWaterModel()
    {
        var dialog = ModelController.NewOpenNewModelFileDialog();

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var pi = new ProgressIndicatorForm();
            this.textBoxModelFilePath.Text = dialog.FileName;
            ModelController.ModelDatabaseFilePath = dialog.FileName;

            try
            {
                pi.Show();
                ModelController.CreateNewWaterModelDatabase(dialog.FileName, pi);
                this.groupBoxModelControl.Enabled = AppManager.Instance.DomainDataSet == null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"...while opening up the model. Path: {ModelController.ModelDatabaseFilePath}");
                MessageBox.Show(this, $"Error occurred. Look at the log file for details.\nMessage:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pi.Done();
            }


        }
        else
            Log.Debug($"User cancelled the dialog box");
    }

    #endregion

    #region Private Properties
    private OpenWaterDatabaseModelControlModel ModelController
        => UserControlModel as OpenWaterDatabaseModelControlModel;
    #endregion
}
