using System.ComponentModel;

namespace CssSaison.Configuration
{
    public enum SeasonMode
    {
        [Description("Automatic (by date)")]
        Auto = 0,

        [Description("Manual (forced season)")]
        Manual = 1
    }
}
