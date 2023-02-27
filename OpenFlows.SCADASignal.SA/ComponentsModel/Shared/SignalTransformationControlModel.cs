using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.SCADA.Domain.Support;
using Haestad.SCADA.Forms.Domain.Datasources;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.Shared;

public class SignalTransformationControlModel : HaestadUserControlModel
{
    #region Constructor
    public SignalTransformationControlModel(IApplicationModel appModel)
        : base("SignalTransformationControlModel", appModel)
    {
    }
    #endregion

    #region Public Properties
    public ISupportElementManager DataSourceManager { get; }
    /// <summary>
    /// Data source DataSourceId
    /// </summary>
    public int DataSourceId { get; set; }

    public TransformType PumpTransformType
    {
        get => (TransformType)this.TransferElement.PumpTransformType;
        set { this.TransferElement.PumpTransformType = (int)value; TransferElement.Commit(); }
    }
    public RelationalOperator PumpOnOperator
    {
        get => (RelationalOperator)this.TransferElement.PumpStatusOnOperator;
        set { this.TransferElement.PumpStatusOnOperator = (int)value; TransferElement.Commit(); }
    }
    public RelationalOperator PumpOffOperator
    {
        get => (RelationalOperator)this.TransferElement.PumpStatusOffOperator;
        set { this.TransferElement.PumpStatusOffOperator = (int)value; TransferElement.Commit(); }
    }
    public object PumpOnRawSignalValue
    {
        get => PumpTransformType == TransformType.ThresholdTransform
            ? this.TransferElement.PumpStatusOnThresholdValue
            : this.TransferElement.PumpStatusOnValue;

        set
        {
            if (PumpTransformType == TransformType.ThresholdTransform)
                this.TransferElement.PumpStatusOnThresholdValue = (double)value;
            else
                this.TransferElement.PumpStatusOnValue = value.ToString();

            TransferElement.Commit();
        }
    }
    public object PumpOffRawSignalValue
    {
        get => PumpTransformType == TransformType.ThresholdTransform
            ? this.TransferElement.PumpStatusOffThresholdValue
            : this.TransferElement.PumpStatusOffValue;

        set
        {
            if (PumpTransformType == TransformType.ThresholdTransform)
                this.TransferElement.PumpStatusOffThresholdValue = (double)value;
            else
                this.TransferElement.PumpStatusOffValue = value.ToString();

            TransferElement.Commit();
        }
    }
    public TransformType ValveTransformType
    {
        get => (TransformType)this.TransferElement.ValveTransformType;
        set { this.TransferElement.ValveTransformType = (int)value; TransferElement.Commit(); }
    }
    public RelationalOperator ValveActiveOperator
    {
        get => (RelationalOperator)this.TransferElement.ValveStatusActiveOperator;
        set { this.TransferElement.ValveStatusActiveOperator = (int)value; TransferElement.Commit(); }
    }
    public object ValveActiveValue
    {
        get => ValveTransformType == TransformType.ThresholdTransform
            ? this.TransferElement.ValveStatusActiveThresholdValue
            : this.TransferElement.ValveStatusActiveValue;

        set
        {
            if (ValveTransformType == TransformType.ThresholdTransform)
                this.TransferElement.ValveStatusActiveThresholdValue = (double)value;
            else
                this.TransferElement.ValveStatusActiveValue = value.ToString();

            TransferElement.Commit();
        }
    }
    public RelationalOperator ValveClosedOperator
    {
        get => (RelationalOperator)this.TransferElement.ValveStatusClosedOperator;
        set { this.TransferElement.ValveStatusClosedOperator = (int)value; TransferElement.Commit(); }
    }
    public object ValveClosedValue
    {
        get => ValveTransformType == TransformType.ThresholdTransform
            ? this.TransferElement.ValveStatusClosedThresholdValue
            : this.TransferElement.ValveStatusClosedValue;

        set
        {
            if (ValveTransformType == TransformType.ThresholdTransform)
                this.TransferElement.ValveStatusClosedThresholdValue = (double)value;
            else
                this.TransferElement.ValveStatusClosedValue = value.ToString();

            TransferElement.Commit();
        }
    }
    #endregion

    #region Private Properties
    private DataSourceTransformerElement TransferElement
    {
        get
        {
            if (_transferElement == null)
            {
                _transferElement = new DataSourceTransformerElement(
                                       domainDataSet: AppManager.Instance.DomainDataSet,
                                       elementID: DataSourceId,
                                       supportElementType: SupportElementType.ScadaDataSource);
            }
            return _transferElement;
        }
    }
    #endregion

    #region Private Fields
    private DataSourceTransformerElement _transferElement;
    #endregion
}
