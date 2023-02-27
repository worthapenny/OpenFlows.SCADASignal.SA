using Haestad.Framework.Application;

namespace OpenFlows.SCADASignal.SA.Application;

public class SCADASignalApplicationModel : ApplicationModelBase
{
    #region Constructor
    public SCADASignalApplicationModel(object[] args)
        :base(args)
    {            
    }
    #endregion

    #region Public Properties

    public override IApplicationDescription Description { get
        {
            if (_description == null) _description = new SCADASignalApplicationDescription();
            return _description;
        }

    }
    public override bool SupportsVariousDrawingStyles => false;
    public override bool SupportsMultipleViewIndependence => false;
    #endregion

    #region Private Fields
    private IApplicationDescription _description;
    #endregion
}
