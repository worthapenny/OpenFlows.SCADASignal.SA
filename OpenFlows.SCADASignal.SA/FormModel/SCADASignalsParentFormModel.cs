using Haestad.Framework.Application;
using OpenFlows.SCADASignal.SA.ComponentsModel;

namespace OpenFlows.SCADASignal.SA.FormModel;

public class SCADASignalsParentFormModel : HaestadFormModel
{
    #region Constructor
    public SCADASignalsParentFormModel(IApplicationModel appModel)
        :base("SCADASignalsParentFormModel", appModel)
    {
        OpenWaterDatabaseModelControlModel = new OpenWaterDatabaseModelControlModel(appModel);
        DataSourceConnectionControlModel = new DataSourceConnectionControlModel(appModel);
    }
    #endregion

    #region Public Properties
    public OpenWaterDatabaseModelControlModel OpenWaterDatabaseModelControlModel { get;  }
    public DataSourceConnectionControlModel DataSourceConnectionControlModel { get; }

    #endregion
}
