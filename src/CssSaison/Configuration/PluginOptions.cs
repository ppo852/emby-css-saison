using System.ComponentModel;
using CssSaison.Services;
using Emby.Web.GenericEdit;
using Emby.Web.GenericEdit.Validation;

namespace CssSaison.Configuration
{
    /// <summary>
    /// Options + UI : dates début/fin regroupées en une seule ligne « période ».
    /// </summary>
    public class PluginOptions : EditableOptionsBase
    {
        public override string EditorTitle => PluginConstants.Name;

        public override string EditorDescription =>
            "Injecte un CSS dans Branding selon la date (JJ-MM).\n" +
            "Fichiers dans le dossier css/ du plugin (aucun CSS embarqué).\n" +
            "Hors saison → default.css. Fichier manquant → Branding non modifié.\n" +
            "Priorité Auto = ordre des saisons ci-dessous (fixe).\n" +
            "Période = début → fin (ex. 01-02 → 15-02).";

        [DisplayName("Activer le plugin")]
        public bool Enabled { get; set; } = false;

        [DisplayName("Mode")]
        public SeasonMode Mode { get; set; } = SeasonMode.Auto;

        [DisplayName("Saison forcée (mode Manuel)")]
        public ForcedSeason ForcedSeason { get; set; } = ForcedSeason.Default;

        [Browsable(false)]
        public string DefaultCssFileName { get; set; } = "default.css";

        [DisplayName("Dossier CSS (vide = data plugin / css)")]
        public string CssFolderPath { get; set; } = string.Empty;

        // —— Valentine ——
        [DisplayName("Valentine — activée")]
        public bool ValentineEnabled { get; set; } = false;

        [Browsable(false)]
        public string ValentineCssFile { get; set; } = "valentine.css";

        [DisplayName("Valentine — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 01-02 → 15-02")]
        public string ValentinePeriod { get; set; } = "01-02 → 15-02";

        [Browsable(false)]
        public string ValentineStart { get; set; } = "01-02";

        [Browsable(false)]
        public string ValentineEnd { get; set; } = "15-02";

        // —— Saint-Patrick ——
        [DisplayName("Saint-Patrick — activée")]
        public bool SaintPatrickEnabled { get; set; } = false;

        [Browsable(false)]
        public string SaintPatrickCssFile { get; set; } = "saint-patrick.css";

        [DisplayName("Saint-Patrick — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 10-03 → 18-03")]
        public string SaintPatrickPeriod { get; set; } = "10-03 → 18-03";

        [Browsable(false)]
        public string SaintPatrickStart { get; set; } = "10-03";

        [Browsable(false)]
        public string SaintPatrickEnd { get; set; } = "18-03";

        // —— Pâques ——
        [DisplayName("Pâques — activée")]
        public bool PaquesEnabled { get; set; } = false;

        [Browsable(false)]
        public string PaquesCssFile { get; set; } = "paques.css";

        [DisplayName("Pâques — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 01-04 → 20-04")]
        public string PaquesPeriod { get; set; } = "01-04 → 20-04";

        [Browsable(false)]
        public string PaquesStart { get; set; } = "01-04";

        [Browsable(false)]
        public string PaquesEnd { get; set; } = "20-04";

        // —— 4 Juillet ——
        [DisplayName("4 Juillet — activée")]
        public bool JuilletEnabled { get; set; } = false;

        [Browsable(false)]
        public string JuilletCssFile { get; set; } = "juillet.css";

        [DisplayName("4 Juillet — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 28-06 → 06-07")]
        public string JuilletPeriod { get; set; } = "28-06 → 06-07";

        [Browsable(false)]
        public string JuilletStart { get; set; } = "28-06";

        [Browsable(false)]
        public string JuilletEnd { get; set; } = "06-07";

        // —— Halloween ——
        [DisplayName("Halloween — activée")]
        public bool HalloweenEnabled { get; set; } = false;

        [Browsable(false)]
        public string HalloweenCssFile { get; set; } = "halloween.css";

        [DisplayName("Halloween — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 01-10 → 01-11")]
        public string HalloweenPeriod { get; set; } = "01-10 → 01-11";

        [Browsable(false)]
        public string HalloweenStart { get; set; } = "01-10";

        [Browsable(false)]
        public string HalloweenEnd { get; set; } = "01-11";

        // —— Thanksgiving ——
        [DisplayName("Thanksgiving — activée")]
        public bool ThanksgivingEnabled { get; set; } = false;

        [Browsable(false)]
        public string ThanksgivingCssFile { get; set; } = "thanksgiving.css";

        [DisplayName("Thanksgiving — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 15-11 → 30-11")]
        public string ThanksgivingPeriod { get; set; } = "15-11 → 30-11";

        [Browsable(false)]
        public string ThanksgivingStart { get; set; } = "15-11";

        [Browsable(false)]
        public string ThanksgivingEnd { get; set; } = "30-11";

        // —— Noël ——
        [DisplayName("Noël — activée")]
        public bool NoelEnabled { get; set; } = false;

        [Browsable(false)]
        public string NoelCssFile { get; set; } = "noel.css";

        [DisplayName("Noël — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 01-12 → 26-12")]
        public string NoelPeriod { get; set; } = "01-12 → 26-12";

        [Browsable(false)]
        public string NoelStart { get; set; } = "01-12";

        [Browsable(false)]
        public string NoelEnd { get; set; } = "26-12";

        // —— Nouvel An ——
        [DisplayName("Nouvel An — activée")]
        public bool NouvelAnEnabled { get; set; } = false;

        [Browsable(false)]
        public string NouvelAnCssFile { get; set; } = "nouvel-an.css";

        [DisplayName("Nouvel An — période (JJ-MM → JJ-MM)")]
        [Description("Exemple : 27-12 → 02-01")]
        public string NouvelAnPeriod { get; set; } = "27-12 → 02-01";

        [Browsable(false)]
        public string NouvelAnStart { get; set; } = "27-12";

        [Browsable(false)]
        public string NouvelAnEnd { get; set; } = "02-01";

        /// <summary>UI période ← Start/End (source de vérité moteur).</summary>
        public void PullPeriodsFromDates()
        {
            ValentinePeriod = SeasonDateHelper.FormatPeriod(ValentineStart, ValentineEnd);
            SaintPatrickPeriod = SeasonDateHelper.FormatPeriod(SaintPatrickStart, SaintPatrickEnd);
            PaquesPeriod = SeasonDateHelper.FormatPeriod(PaquesStart, PaquesEnd);
            JuilletPeriod = SeasonDateHelper.FormatPeriod(JuilletStart, JuilletEnd);
            HalloweenPeriod = SeasonDateHelper.FormatPeriod(HalloweenStart, HalloweenEnd);
            ThanksgivingPeriod = SeasonDateHelper.FormatPeriod(ThanksgivingStart, ThanksgivingEnd);
            NoelPeriod = SeasonDateHelper.FormatPeriod(NoelStart, NoelEnd);
            NouvelAnPeriod = SeasonDateHelper.FormatPeriod(NouvelAnStart, NouvelAnEnd);
        }

        /// <summary>Start/End ← UI période (avant save / apply / validate).</summary>
        public void PushPeriodsToDates()
        {
            if (SeasonDateHelper.TryParsePeriod(ValentinePeriod, out var vStart, out var vEnd))
            {
                ValentineStart = vStart;
                ValentineEnd = vEnd;
            }

            if (SeasonDateHelper.TryParsePeriod(SaintPatrickPeriod, out var spStart, out var spEnd))
            {
                SaintPatrickStart = spStart;
                SaintPatrickEnd = spEnd;
            }

            if (SeasonDateHelper.TryParsePeriod(PaquesPeriod, out var pStart, out var pEnd))
            {
                PaquesStart = pStart;
                PaquesEnd = pEnd;
            }

            if (SeasonDateHelper.TryParsePeriod(JuilletPeriod, out var jStart, out var jEnd))
            {
                JuilletStart = jStart;
                JuilletEnd = jEnd;
            }

            if (SeasonDateHelper.TryParsePeriod(HalloweenPeriod, out var hStart, out var hEnd))
            {
                HalloweenStart = hStart;
                HalloweenEnd = hEnd;
            }

            if (SeasonDateHelper.TryParsePeriod(ThanksgivingPeriod, out var tStart, out var tEnd))
            {
                ThanksgivingStart = tStart;
                ThanksgivingEnd = tEnd;
            }

            if (SeasonDateHelper.TryParsePeriod(NoelPeriod, out var nStart, out var nEnd))
            {
                NoelStart = nStart;
                NoelEnd = nEnd;
            }

            if (SeasonDateHelper.TryParsePeriod(NouvelAnPeriod, out var naStart, out var naEnd))
            {
                NouvelAnStart = naStart;
                NouvelAnEnd = naEnd;
            }
        }

        protected override void Validate(ValidationContext context)
        {
            base.Validate(context);
            PushPeriodsToDates();

            ValidatePeriod(context, ValentineEnabled, ValentinePeriod, "Valentine");
            ValidatePeriod(context, SaintPatrickEnabled, SaintPatrickPeriod, "Saint-Patrick");
            ValidatePeriod(context, PaquesEnabled, PaquesPeriod, "Pâques");
            ValidatePeriod(context, JuilletEnabled, JuilletPeriod, "4 Juillet");
            ValidatePeriod(context, HalloweenEnabled, HalloweenPeriod, "Halloween");
            ValidatePeriod(context, ThanksgivingEnabled, ThanksgivingPeriod, "Thanksgiving");
            ValidatePeriod(context, NoelEnabled, NoelPeriod, "Noël");
            ValidatePeriod(context, NouvelAnEnabled, NouvelAnPeriod, "Nouvel An");
        }

        private static void ValidatePeriod(ValidationContext context, bool enabled, string period, string label)
        {
            if (!enabled)
                return;

            if (!SeasonDateHelper.TryParsePeriod(period, out _, out _))
                context.AddValidationError(label + " — période invalide (ex. 01-02 → 15-02).");
        }
    }
}
