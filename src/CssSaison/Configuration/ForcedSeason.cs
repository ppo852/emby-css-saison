using System.ComponentModel;

namespace CssSaison.Configuration
{
    public enum ForcedSeason
    {
        [Description("Default (off-season)")]
        Default = 0,

        [Description("Valentine")]
        Valentine = 1,

        [Description("Saint-Patrick")]
        SaintPatrick = 2,

        [Description("Easter")]
        Paques = 3,

        [Description("4th of July")]
        Juillet = 4,

        [Description("Halloween")]
        Halloween = 5,

        [Description("Thanksgiving")]
        Thanksgiving = 6,

        [Description("Christmas")]
        Noel = 7,

        [Description("New Year")]
        NouvelAn = 8
    }
}
