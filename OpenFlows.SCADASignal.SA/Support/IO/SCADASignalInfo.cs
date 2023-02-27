using Serilog;
using System.Diagnostics;

namespace OpenFlows.SCADASignal.SA.Support.IO;

[DebuggerDisplay("{ToString()}")]
public class SCADASignalInfo
{
    #region Constructor
    public SCADASignalInfo()
    {            
    }
    public SCADASignalInfo(string tag)
        :this(tag, tag)
    {
    }
    public SCADASignalInfo(string tag, string label)
        :this()
    {
        Tag = tag;
        Label = label;
    }

    #endregion

    #region Public Methods
    public bool Validate()
    {
        if(string.IsNullOrEmpty(Tag) && string.IsNullOrEmpty(Label))
        {
            Log.Warning($"Both Tag and Label cannot be empty.");
            return false;
        }

        // do a minor fix
        if (string.IsNullOrEmpty(Label))
            Label = Tag;


        return true;
    }
    #endregion

    #region Overridden Methods
    public override string ToString()
    {
        return $"{Tag} | {Label} | {Formula}";
    }        
    #endregion

    #region Public Properties
    public string Tag { get; set; }
    public string Label { get; set; }
    public string Formula { get; set; }
    #endregion
}
