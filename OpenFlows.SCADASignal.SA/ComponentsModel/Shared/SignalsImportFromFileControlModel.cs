using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.Support.Support;
using Newtonsoft.Json;
using OpenFlows.SCADASignal.SA.Support.IO;
using Serilog;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.Shared;

public class SignalsImportFromFileControlModel : HaestadUserControlModel
{
    #region Constructor
    public SignalsImportFromFileControlModel(IApplicationModel appModel)
        : base("SignalsImportFromFileControlModel", appModel)
    {
    }
    #endregion

    #region Public Methods
    public void LoadJsonPath()
    {
        if (!File.Exists(JsonFilePath))
        {
            var dialog = NewOpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                JsonFilePath = dialog.FileName;
                Log.Debug($"Json file path is set to: {JsonFilePath}");
            }
        }
    }
    public DataTable GetSignalInfoTable()
    {
        var jsonString = File.ReadAllText(JsonFilePath);
        var dt = JsonConvert.DeserializeObject<DataTable>(jsonString);
        Log.Debug($"Found '{dt.Rows.Count}' rows and '{dt.Columns.Count}' columns.");
        return dt;
    }

    public List<string> GetTableHeaders(DataTable dt)
    {
        var headers = new List<string>();
        foreach (DataColumn column in dt.Columns)
            headers.Add(column.ColumnName);

        Log.Debug($"Headers found: {string.Join(", ", headers)}");
        return headers;
    }
    public List<SCADASignalInfo> GetSignalInfoList(DataTable dt)
    {
        var signals = new List<SCADASignalInfo>();
        foreach (DataRow row in dt.Rows)
        {
            var signal = new SCADASignalInfo(
                tag: row[TagColumnName].ToString(),
                label: row[LabelColumnName].ToString());

            if (!string.IsNullOrEmpty(FormulaColumnName))
            {
                var formula = row[FormulaColumnName].ToString();
                if (!string.IsNullOrEmpty(formula))
                    signal.Formula = formula;
            }

            Log.Debug($"Extracted signal, {signal}");
            signals.Add(signal);
        }

        Log.Information($"Total number of signals extracted: {signals.Count}");
        return signals;
    }

    public int DeleteAllRawScadaTags()
    {
        var deletedCount = 0;
        var dataSourceIdField = SignalManager.SupportElementField(StandardFieldName.ScadaSignal_ScadaDatasourceID) as IEditField;

        foreach (var id in SignalManager.ElementIDs())
        {
            var dataSourceId = (int)dataSourceIdField.GetValue(id);

            if (dataSourceId != DataSourceElement.Id)
                continue;

            SignalManager.Delete(id);
            deletedCount++;
        }

        Log.Information($"'{deletedCount}' number of items deleted");
        return deletedCount;
    }
    public int AppendNewRawScadaTags(List<SCADASignalInfo> signals)
    {
        var addedTagsCount = 0;
        foreach (var signal in signals)
        {
            if (!signal.Validate())
            {
                Log.Warning($"[Skipped] Given signal is not valid. Signal: {signal}");
                continue;
            }

            SignalId = SignalManager.Add();
            var element = SignalManager.Element(SignalId);

            DataSourceId = DataSourceElement.Id;
            SignalLabel = signal.Tag;

            // Label
            element.Label = signal.Label;

            // Formula
            if (!string.IsNullOrEmpty(signal.Formula))
            {
                IsDerived = true;
                Formula = signal.Formula;
                TransformMethod = SCADASignalTransformMethod.Formula;
            }

            Log.Debug($"Imported signal. Signal: {signal}");
            addedTagsCount++;
        }

        Log.Information($"'{addedTagsCount}' number of rows imported");
        return addedTagsCount;
    }
    #endregion

    #region Private Methods
    private IEditField SupportField(string fieldName)
    {
        return (IEditField)SignalManager.SupportElementField(fieldName);
    }
    private OpenFileDialog NewOpenFileDialog()
    {
        return new OpenFileDialog
        {
            Title = "Select SCADA Tags, label Json File",
            Filter = "JSON Files|*.json",
            CheckFileExists = true,
            CheckPathExists = true,
            Multiselect = false
        };
    }
    #endregion

    #region Public Properties
    public int DataSourceElementId { get; set; }
    public ISupportElementManager SignalManager
        => DomainDataSet.SupportElementManager((int)SupportElementType.ScadaSignal);
    public ISupportElement DataSourceElement => (ISupportElement)SignalManager.Element(DataSourceElementId);
    
    public IDomainDataSet DomainDataSet => AppManager.Instance.DomainDataSet;


    public string JsonFilePath { get; set; }
    public string TagColumnName { get; set; }
    public string LabelColumnName { get; set; }
    public string FormulaColumnName { get; set; }
    #endregion

    #region Private Properties
    public int DataSourceId
    {
        get => (int)SupportField(StandardFieldName.ScadaSignal_ScadaDatasourceID).GetValue(SignalId);
        set => SupportField(StandardFieldName.ScadaSignal_ScadaDatasourceID).SetValue(SignalId, value);
    }
    public string SignalLabel
    {
        get => (string)SupportField(StandardFieldName.ScadaSignal_SignalLabel).GetValue(SignalId);
        set => SupportField(StandardFieldName.ScadaSignal_SignalLabel).SetValue(SignalId, value);
    }
    public bool IsDerived
    {
        get => (bool)SupportField(StandardFieldName.ScadaSignal_isDerived).GetValue(SignalId);
        set => SupportField(StandardFieldName.ScadaSignal_isDerived).SetValue(SignalId, value);
    }
    public string Formula
    {
        get => (string)SupportField(StandardFieldName.FormulaTransform_FormulaText).GetValue(SignalId);
        set => SupportField(StandardFieldName.FormulaTransform_FormulaText).SetValue(SignalId, value);
    }
    public SCADASignalTransformMethod TransformMethod
    {
        get => (SCADASignalTransformMethod)SupportField(StandardFieldName.TransformMethod).GetValue(SignalId);
        set => SupportField(StandardFieldName.TransformMethod).SetValue(SignalId, value);
    }
    #endregion

    #region Private Properties
    private int SignalId { get; set; }
    #endregion
}

public enum SCADASignalTransformMethod
{
    Threshold = 0,
    Range = 1,
    Formula = 2,
}
