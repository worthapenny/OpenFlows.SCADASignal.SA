using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.SCADA.Domain;
using Haestad.SCADA.Domain.Application;
using OpenFlows.SCADASignal.SA.Components.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.Shared;

public class PreviewSCADADataControlModel : HaestadUserControlModel
{
    #region Constructor
    public PreviewSCADADataControlModel(IApplicationModel appModel)
        : base("PreviewSCADADataControlModel", appModel)
    {
        EndDateTime = DateTime.Now.Date.AddDays(1);
        StartDateTime = DateTime.Now.Date.AddDays(-3);
    }
    #endregion

    #region Public Methods
    public List<SCADASignalElement> GetSCADASignalElements()
    {
        var signalElements = new List<SCADASignalElement>();
        var signalManager = AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaSignal);

        var dataSourceField = signalManager.SupportElementField(StandardFieldName.ScadaSignal_ScadaDatasourceID);
        var tagField = signalManager.SupportElementField(StandardFieldName.ScadaSignal_SignalLabel);
        var isDerivedField = signalManager.SupportElementField(StandardFieldName.ScadaSignal_isDerived);
        var formulaField = signalManager.SupportElementField(StandardFieldName.FormulaTransform_FormulaText);

        foreach (var element in signalManager.Elements())
        {
            var fieldValue = dataSourceField.GetValue(element.Id);
            if (fieldValue == null)
            {
                Log.Error($"The data source id filed value is null, which it should not be. Skipped {element.Id}: {element.Label}. [Signal Manager's Element]");
                continue;
            }

            var dataSourceId = (int)fieldValue;
            if (dataSourceId != DataSourceElement.Id)
                continue;

            signalElements.Add(
                new SCADASignalElement(
                    id: element.Id,
                    label: element.Label,
                    dataSourceId: dataSourceId,
                    SCADATag: tagField.GetValue(element.Id) as string
                    )
                {
                    IsDerived = (bool)isDerivedField.GetValue(element.Id),
                    Formula = (string)formulaField.GetValue(element.Id)
                });

        }

        Log.Information($"'{signalElements.Count}' number of SCADA signals found on {DataSourceElement.Label} in water model.");
        return signalElements;
    }
    public List<ISignalValue> GetSCADAData(SCADASignalElement signal)
    {
        var scadaAdapter = new ScadaAdapter(AppManager.Instance.DomainDataSet);

        var values = scadaAdapter.GetSignalValues(signal.Id, StartDateTime, EndDateTime);
        var valuesList = new List<ISignalValue>();
        if (values != null)
            valuesList = values.ToList();

        Log.Debug($"Found number of SCADA data rows: {valuesList.Count} on {DataSourceElement.Label}, signal: {signal}");
        scadaAdapter.CloseScadaDataSource(DataSourceElement.Id);
        return valuesList;
    }

    public void DeleteTag(SCADASignalElement SCADASignalElement)
    {
        var signalManager = AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaSignal);
        signalManager.Delete(SCADASignalElement.Id);
        Log.Information($"Deleted. Signal: {SCADASignalElement}");
    }

    #endregion

    #region Public Properties
    public ISupportElement DataSourceElement { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    #endregion
}
