using Haestad.Framework.Windows.Forms.Forms;
using OpenFlows.SCADASignal.SA.FormModel;
using OpenFlows.SCADASignal.SA.Library;
using Serilog;
using System.ComponentModel;

namespace OpenFlows.SCADASignal.SA.Forms;

public partial class SCADASignalsParentForm : HaestadForm
{
    #region Constructor
    public SCADASignalsParentForm(SCADASignalsParentFormModel formModel)
        :base(formModel)
    {
        InitializeComponent();           
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeText()
    {
        Text = AppManager.AppName;
        base.InitializeText();
    }
    protected override void InitializeVisually()
    {
        Icon = Properties.Resources.SCADASignal;

        this.dataSourceConnectionControl.Enabled = false;
        base.InitializeVisually();
    }
    protected override void InitializeEvents()
    {
        ParentFormModel.OpenWaterDatabaseModelControlModel.ModelOpened += (s, e) =>
        {
            AppManager.Instance.DomainDataSet
                = ParentFormModel.OpenWaterDatabaseModelControlModel.DomainDataSet;

            this.dataSourceConnectionControl.LoadDataSourcesToTreeView();
            this.dataSourceConnectionControl.Enabled = true;
        };
        base.InitializeEvents();
    }
    protected override void InitializeBindings()
    {
        this.openWaterModelDatabaseControl.LoadUserControl(ParentFormModel.OpenWaterDatabaseModelControlModel);
        this.dataSourceConnectionControl.LoadUserControl(ParentFormModel.DataSourceConnectionControlModel);
    }
    protected override void HaestadForm_Closing(object sender, CancelEventArgs e)
    {
        ParentFormModel.OpenWaterDatabaseModelControlModel?.CloseModelDatabase();

        Log.Information($"Form '{Name}' is closing...");
        LogLibrary.Separate_EndMajor();

        base.HaestadForm_Closing(sender, e);
    }
    #endregion

    #region Private Properties
    private SCADASignalsParentFormModel ParentFormModel =>
        FormModel as SCADASignalsParentFormModel;
    
    #endregion

}
