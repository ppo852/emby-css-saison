using System.ComponentModel;
using CssSaison.Configuration;
using Emby.Web.GenericEdit;
using Emby.Web.GenericEdit.Elements;

namespace CssSaison.UI
{
    /// <summary>
    /// UI principale : options + boutons ouvrant le dialog d'édition CSS.
    /// </summary>
    public class MainPageUi : PluginOptions
    {
        public MainPageUi()
        {
            EditDefaultCssButton = new ButtonItem("Éditer CSS — Défaut") { Data1 = "EditCss:Default" };
            EditValentineCssButton = new ButtonItem("Éditer CSS — Valentine") { Data1 = "EditCss:Valentine" };
            EditSaintPatrickCssButton = new ButtonItem("Éditer CSS — Saint-Patrick") { Data1 = "EditCss:SaintPatrick" };
            EditPaquesCssButton = new ButtonItem("Éditer CSS — Pâques") { Data1 = "EditCss:Paques" };
            EditJuilletCssButton = new ButtonItem("Éditer CSS — 4 Juillet") { Data1 = "EditCss:Juillet" };
            EditHalloweenCssButton = new ButtonItem("Éditer CSS — Halloween") { Data1 = "EditCss:Halloween" };
            EditThanksgivingCssButton = new ButtonItem("Éditer CSS — Thanksgiving") { Data1 = "EditCss:Thanksgiving" };
            EditNoelCssButton = new ButtonItem("Éditer CSS — Noël") { Data1 = "EditCss:Noel" };
            EditNouvelAnCssButton = new ButtonItem("Éditer CSS — Nouvel An") { Data1 = "EditCss:NouvelAn" };
        }

        public override string EditorDescription =>
            "Saisons (période JJ-MM → JJ-MM) + éditeur CSS (dialogs).\n" +
            "Fichiers enregistrés dans css/ du plugin. Hors saison → default.css.\n" +
            "Fichier manquant → Branding non modifié. Apply : save / tâche 03:15 / démarrage.";

        [DisplayName("Éditeur CSS")]
        [Description("Ouvre un dialog pour coller / modifier le CSS de chaque thème.")]
        public ButtonItem EditDefaultCssButton { get; set; }

        public ButtonItem EditValentineCssButton { get; set; }

        public ButtonItem EditSaintPatrickCssButton { get; set; }

        public ButtonItem EditPaquesCssButton { get; set; }

        public ButtonItem EditJuilletCssButton { get; set; }

        public ButtonItem EditHalloweenCssButton { get; set; }

        public ButtonItem EditThanksgivingCssButton { get; set; }

        public ButtonItem EditNoelCssButton { get; set; }

        public ButtonItem EditNouvelAnCssButton { get; set; }

        public static MainPageUi FromOptions(PluginOptions src)
        {
            var ui = new MainPageUi();
            if (src == null)
                return ui;

            src.PullPeriodsFromDates();

            ui.Enabled = src.Enabled;
            ui.Mode = src.Mode;
            ui.ForcedSeason = src.ForcedSeason;
            ui.DefaultCssFileName = src.DefaultCssFileName;
            ui.CssFolderPath = src.CssFolderPath;

            ui.ValentineEnabled = src.ValentineEnabled;
            ui.ValentineCssFile = src.ValentineCssFile;
            ui.ValentineStart = src.ValentineStart;
            ui.ValentineEnd = src.ValentineEnd;
            ui.ValentinePeriod = src.ValentinePeriod;

            ui.SaintPatrickEnabled = src.SaintPatrickEnabled;
            ui.SaintPatrickCssFile = src.SaintPatrickCssFile;
            ui.SaintPatrickStart = src.SaintPatrickStart;
            ui.SaintPatrickEnd = src.SaintPatrickEnd;
            ui.SaintPatrickPeriod = src.SaintPatrickPeriod;

            ui.PaquesEnabled = src.PaquesEnabled;
            ui.PaquesCssFile = src.PaquesCssFile;
            ui.PaquesStart = src.PaquesStart;
            ui.PaquesEnd = src.PaquesEnd;
            ui.PaquesPeriod = src.PaquesPeriod;

            ui.JuilletEnabled = src.JuilletEnabled;
            ui.JuilletCssFile = src.JuilletCssFile;
            ui.JuilletStart = src.JuilletStart;
            ui.JuilletEnd = src.JuilletEnd;
            ui.JuilletPeriod = src.JuilletPeriod;

            ui.HalloweenEnabled = src.HalloweenEnabled;
            ui.HalloweenCssFile = src.HalloweenCssFile;
            ui.HalloweenStart = src.HalloweenStart;
            ui.HalloweenEnd = src.HalloweenEnd;
            ui.HalloweenPeriod = src.HalloweenPeriod;

            ui.ThanksgivingEnabled = src.ThanksgivingEnabled;
            ui.ThanksgivingCssFile = src.ThanksgivingCssFile;
            ui.ThanksgivingStart = src.ThanksgivingStart;
            ui.ThanksgivingEnd = src.ThanksgivingEnd;
            ui.ThanksgivingPeriod = src.ThanksgivingPeriod;

            ui.NoelEnabled = src.NoelEnabled;
            ui.NoelCssFile = src.NoelCssFile;
            ui.NoelStart = src.NoelStart;
            ui.NoelEnd = src.NoelEnd;
            ui.NoelPeriod = src.NoelPeriod;

            ui.NouvelAnEnabled = src.NouvelAnEnabled;
            ui.NouvelAnCssFile = src.NouvelAnCssFile;
            ui.NouvelAnStart = src.NouvelAnStart;
            ui.NouvelAnEnd = src.NouvelAnEnd;
            ui.NouvelAnPeriod = src.NouvelAnPeriod;

            return ui;
        }

        public PluginOptions ToOptions()
        {
            PushPeriodsToDates();

            return new PluginOptions
            {
                Enabled = Enabled,
                Mode = Mode,
                ForcedSeason = ForcedSeason,
                DefaultCssFileName = DefaultCssFileName,
                CssFolderPath = CssFolderPath,
                ValentineEnabled = ValentineEnabled,
                ValentineCssFile = ValentineCssFile,
                ValentinePeriod = ValentinePeriod,
                ValentineStart = ValentineStart,
                ValentineEnd = ValentineEnd,
                SaintPatrickEnabled = SaintPatrickEnabled,
                SaintPatrickCssFile = SaintPatrickCssFile,
                SaintPatrickPeriod = SaintPatrickPeriod,
                SaintPatrickStart = SaintPatrickStart,
                SaintPatrickEnd = SaintPatrickEnd,
                PaquesEnabled = PaquesEnabled,
                PaquesCssFile = PaquesCssFile,
                PaquesPeriod = PaquesPeriod,
                PaquesStart = PaquesStart,
                PaquesEnd = PaquesEnd,
                JuilletEnabled = JuilletEnabled,
                JuilletCssFile = JuilletCssFile,
                JuilletPeriod = JuilletPeriod,
                JuilletStart = JuilletStart,
                JuilletEnd = JuilletEnd,
                HalloweenEnabled = HalloweenEnabled,
                HalloweenCssFile = HalloweenCssFile,
                HalloweenPeriod = HalloweenPeriod,
                HalloweenStart = HalloweenStart,
                HalloweenEnd = HalloweenEnd,
                ThanksgivingEnabled = ThanksgivingEnabled,
                ThanksgivingCssFile = ThanksgivingCssFile,
                ThanksgivingPeriod = ThanksgivingPeriod,
                ThanksgivingStart = ThanksgivingStart,
                ThanksgivingEnd = ThanksgivingEnd,
                NoelEnabled = NoelEnabled,
                NoelCssFile = NoelCssFile,
                NoelPeriod = NoelPeriod,
                NoelStart = NoelStart,
                NoelEnd = NoelEnd,
                NouvelAnEnabled = NouvelAnEnabled,
                NouvelAnCssFile = NouvelAnCssFile,
                NouvelAnPeriod = NouvelAnPeriod,
                NouvelAnStart = NouvelAnStart,
                NouvelAnEnd = NouvelAnEnd
            };
        }
    }
}
