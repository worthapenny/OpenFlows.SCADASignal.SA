using Haestad.Framework.Application;
using Haestad.Support.Support;
using System;

namespace OpenFlows.SCADASignal.SA.Application;
public class SCADASignalApplicationDescription : ApplicationDescriptionBase
{
    #region Constructor
    public SCADASignalApplicationDescription()
        : base(HmiProductBeta.Test, "SCADASignal.SA", new Version(1, 0, 0, 0), string.Empty, DateTime.Now.Year.ToString())
    {
    }
    #endregion
}
