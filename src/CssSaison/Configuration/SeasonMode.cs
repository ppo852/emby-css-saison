using System.ComponentModel;

namespace CssSaison.Configuration
{
    public enum SeasonMode
    {
        [Description("Automatique (selon la date)")]
        Auto = 0,

        [Description("Manuel (règle forcée par nom)")]
        Manual = 1
    }
}
