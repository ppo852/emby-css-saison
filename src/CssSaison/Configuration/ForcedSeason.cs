using System.ComponentModel;

namespace CssSaison.Configuration
{
    public enum ForcedSeason
    {
        [Description("Défaut (hors saison)")]
        Default = 0,

        [Description("Valentine")]
        Valentine = 1,

        [Description("Saint-Patrick")]
        SaintPatrick = 2,

        [Description("Pâques")]
        Paques = 3,

        [Description("4 Juillet")]
        Juillet = 4,

        [Description("Halloween")]
        Halloween = 5,

        [Description("Thanksgiving")]
        Thanksgiving = 6,

        [Description("Noël")]
        Noel = 7,

        [Description("Nouvel An")]
        NouvelAn = 8
    }
}
