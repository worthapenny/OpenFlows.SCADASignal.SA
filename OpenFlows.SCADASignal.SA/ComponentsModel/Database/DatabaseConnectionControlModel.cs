using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.SCADA.Domain;
using Haestad.SCADA.Domain.Application;
using Haestad.Support.Support;
using System;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.Database;

public class DatabaseConnectionControlModel : HaestadUserControlModel
{
    #region Constructor
    public DatabaseConnectionControlModel(IApplicationModel appModel)
        : base("SignalUnitControlModel", appModel)
    {
    }
    #endregion


    #region Private Methods
    private bool ShouldUseConnectionString()
    {
        switch (DatabaseDataSourceType)
        {
            case DatabaseDataSourceType.Excel30:
            case DatabaseDataSourceType.Excel40:
            case DatabaseDataSourceType.Excel50:
            case DatabaseDataSourceType.Excel80:
            case DatabaseDataSourceType.Excel120:
            case DatabaseDataSourceType.Access20:
            case DatabaseDataSourceType.Access30:
            case DatabaseDataSourceType.Access40:
            case DatabaseDataSourceType.Access120:
                return false;

            case DatabaseDataSourceType.OdbcConnection:
            case DatabaseDataSourceType.OleDbConnection:
            case DatabaseDataSourceType.SqlConnection:
            case DatabaseDataSourceType.OracleConnection:
                return true;

            default:
                throw new NotImplementedException($"Give value '{DatabaseDataSourceType}' is not supported.");
        }
    }
    private IEditField SupportField(string fieldName)
    {
        return (IEditField)DataSourceManager.SupportElementField(fieldName);
    }
    #endregion

    #region Public Properties
    public ISupportElementManager DataSourceManager => AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);
    /// <summary>
    /// Data source DataSourceId
    /// </summary>
    public int DataSourceId { get; set; }
    public ISupportElement DataSourceElement => DataSourceManager.Element(DataSourceId) as ISupportElement;


    #region Data Source Structure Fields
    public string DataSourceLabel
    {
        get => DataSourceElement.Label;
        set => DataSourceElement.Label = value;
    }
    public ScadaDatasourceType DataSourceType
    {
        get => (ScadaDatasourceType)SupportField(StandardFieldName.ScadaDatasourceType).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDatasourceType).SetValue(DataSourceId, value);
    }
    public DatabaseDataSourceType DatabaseDataSourceType
    {
        get => (DatabaseDataSourceType)SupportField(StandardFieldName.DatabaseDatasourceType).GetValue(DataSourceId);
        set { SupportField(StandardFieldName.DatabaseDatasourceType).SetValue(DataSourceId, (int)value); UseConnectionString = ShouldUseConnectionString(); }
    }
    public string DataFilePath
    {
        get => (string)SupportField(StandardFieldName.DatabaseType_DatasourcePath).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.DatabaseType_DatasourcePath).SetValue(DataSourceId, value);
    }
    public bool UseConnectionString
    {
        get => (bool)SupportField(StandardFieldName.DatabaseType_UseCustomConnectionString).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.DatabaseType_UseCustomConnectionString).SetValue(DataSourceId, value);
    }
    public string ConnectionString
    {
        get => (string)SupportField(StandardFieldName.DatabaseType_ConnectionString).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.DatabaseType_ConnectionString).SetValue(DataSourceId, value);
    }
    public string QueryDateTimeDelimiter
    {
        get => (string)SupportField(StandardFieldName.DatabaseType_DateTimeSQLPrefix).GetValue(DataSourceId);
        set
        {
            SupportField(StandardFieldName.DatabaseType_DateTimeSQLPrefix).SetValue(DataSourceId, value);
            SupportField(StandardFieldName.DatabaseType_DateTimeSQLSuffix).SetValue(DataSourceId, value);
        }
    }
    public string SCADADataSourceConnection
    {
        get => (string)SupportField(StandardFieldName.DatabaseType_Datasource).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.DatabaseType_Datasource).SetValue(DataSourceId, value);
    }
    public string TableName
    {
        get => (string)SupportField(StandardFieldName.ScadaDataSource_TableName).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_TableName).SetValue(DataSourceId, value);
    }
    public DatabaseDataSourceFormat SourceFormat
    {
        get => (DatabaseDataSourceFormat)SupportField(StandardFieldName.SourceFormat).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.SourceFormat).SetValue(DataSourceId, value);
    }
    public string SignalColumnName
    {
        get => (string)SupportField(StandardFieldName.ScadaDataSource_SignalNameField).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_SignalNameField).SetValue(DataSourceId, value);
    }
    public string ValueColumnName
    {
        get => (string)SupportField(StandardFieldName.ScadaDataSource_ValueField).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_ValueField).SetValue(DataSourceId, value);
    }
    public string TimestampColumnName
    {
        get => (string)SupportField(StandardFieldName.ScadaDataSource_TimeStampField).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_TimeStampField).SetValue(DataSourceId, value);
    }
    public string QuestionableColumnName
    {
        get => (string)SupportField(StandardFieldName.ScadaDataSource_QuestionableField).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_QuestionableField).SetValue(DataSourceId, value);
    }
    public bool IsHistorical
    {
        get => (bool)SupportField(StandardFieldName.ScadaDataSource_SupportsHistoricalData).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_SupportsHistoricalData).SetValue(DataSourceId, value);
    }
    public bool IsRealTime
    {
        get => (bool)SupportField(StandardFieldName.ScadaDataSource_SupportsRealtimeData).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_SupportsRealtimeData).SetValue(DataSourceId, value);
    }
    public double TimeToleranceBackwardInMinutes
    {
        get => (double)SupportField(StandardFieldName.ScadaDataSource_TimeTolerance).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_TimeTolerance).SetValue(DataSourceId, value);
    }
    public double TimeToleranceForwardInMinutes
    {
        get => (double)SupportField(StandardFieldName.ScadaDataSource_TimeToleranceForwards).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_TimeToleranceForwards).SetValue(DataSourceId, value);
    }
    public bool IsZeroGoodQuality
    {
        get => (bool)SupportField(StandardFieldName.ScadaDataSource_ZeroIsGoodQuality).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDataSource_ZeroIsGoodQuality).SetValue(DataSourceId, value);
    }

    public bool UseCustomizedSQL
    {
        get => (bool)SupportField(StandardFieldName.Database_CustomizeSQLStatements).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.Database_CustomizeSQLStatements).SetValue(DataSourceId, value);
    }
    public string AvailableSignalsSQLQuery
    {
        get => (string)SupportField(StandardFieldName.Database_AvailableSignalsSQLStatement).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.Database_AvailableSignalsSQLStatement).SetValue(DataSourceId, value);
    }
    public string SignalDataSQLQueryOVPR
    {
        get => (string)SupportField(StandardFieldName.Database_HistoricalOVPR).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.Database_HistoricalOVPR).SetValue(DataSourceId, value);
    }
    public string SignalDataSQLQueryMVPR
    {
        get => (string)SupportField(StandardFieldName.Database_HistoricalMVPR).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.Database_HistoricalMVPR).SetValue(DataSourceId, value);
    }
    public string DateTimeRangeSQLQuery
    {
        get => (string)SupportField(StandardFieldName.Database_DateTimeRangeSQLStatement).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.Database_DateTimeRangeSQLStatement).SetValue(DataSourceId, value);
    }
    public string AvailableSignalsSQLQueryDefault => DatabaseDataSource.DefaultAvailableSignalsSelectStatement;
    public string SignalDataSQLQueryDefault => DatabaseDataSource.DefaultHistoricalSelectStatement;
    public string DateTimeRangeSQLQueryDefault => DatabaseDataSource.DefaultHistoricalDateTimeRangeSelectStatement;

    public DatabaseDataSource DatabaseDataSource
    {
        get
        {
            if (_dataSource == null)
            {
                _dataSource = (DatabaseDataSource)ScadaFactory.NewDatabaseDataSource(
                                scadaDataSourceType: DatabaseDataSourceType,
                                databaseDataSourceFormat: SourceFormat,
                                dataSourcePath: DataFilePath);

                if (UseConnectionString)
                    _dataSource.Connection.ConnectionString = ConnectionString;
            }

            return _dataSource;

            //var _dataSource = (DatabaseDataSource)ScadaFactory.NewDatabaseDataSource(
            //                scadaDataSourceType: DatabaseDataSourceType,
            //                databaseDataSourceFormat: SourceFormat,
            //                dataSourcePath: DataFilePath);
            //_dataSource.TableName = TableName;
            //_dataSource.SourceFormat = SourceFormat;
            //_dataSource.SignalNameField = SignalColumnName;
            //_dataSource.SignalValueField = ValueColumnName;
            //_dataSource.SignalDateTimeField = TimestampColumnName;


            //if (UseConnectionString)
            //    _dataSource.Connection.ConnectionString = ConnectionString;

            //return _dataSource;
        }
    }
    #endregion


    #endregion

    #region Private Field
    private DatabaseDataSource _dataSource;
    #endregion
}
