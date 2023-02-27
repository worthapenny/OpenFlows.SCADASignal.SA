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
        var elements = new List<SCADASignalElement>();
        var manager = AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaSignal);

        var dataSourceField = manager.SupportElementField(StandardFieldName.ScadaSignal_ScadaDatasourceID);
        var tagField = manager.SupportElementField(StandardFieldName.ScadaSignal_SignalLabel);
        var isDerivedField = manager.SupportElementField(StandardFieldName.ScadaSignal_isDerived);
        var formulaField = manager.SupportElementField(StandardFieldName.FormulaTransform_FormulaText);

        foreach (var element in manager.Elements())
        {
            var dataSourceId = (int)dataSourceField.GetValue(element.Id);
            if (dataSourceId != DataSourceElement.Id)
                continue;

            elements.Add(
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

        Log.Information($"'{elements.Count}' number of SCADA signals found on {DataSourceElement.Label} in water model.");
        return elements;
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
