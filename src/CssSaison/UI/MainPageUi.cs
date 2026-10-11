using System.ComponentModel;
using CssSaison.Configuration;
using Emby.Web.GenericEdit.Elements;

namespace CssSaison.UI
{
    /// <summary>
    /// Main UI: options + buttons that open the CSS editor dialog.
    /// </summary>
    public class MainPageUi : PluginOptions
    {
        public MainPageUi()
        {
            EditDefaultCssButton = new ButtonItem("Edit CSS — Default") { Data1 = "EditCss:Default" };
            EditValentineCssButton = new ButtonItem("Edit CSS — Valentine") { Data1 = "EditCss:Valentine" };
            EditSaintPatrickCssButton = new ButtonItem("Edit CSS — Saint-Patrick") { Data1 = "EditCss:SaintPatrick" };
            EditPaquesCssButton = new ButtonItem("Edit CSS — Easter") { Data1 = "EditCss:Paques" };
            EditJuilletCssButton = new ButtonItem("Edit CSS — 4th of July") { Data1 = "EditCss:Juillet" };
            EditHalloweenCssButton = new ButtonItem("Edit CSS — Halloween") { Data1 = "EditCss:Halloween" };
            EditThanksgivingCssButton = new ButtonItem("Edit CSS — Thanksgiving") { Data1 = "EditCss:Thanksgiving" };
            EditNoelCssButton = new ButtonItem("Edit CSS — Christmas") { Data1 = "EditCss:Noel" };
            EditNouvelAnCssButton = new ButtonItem("Edit CSS — New Year") { Data1 = "EditCss:NouvelAn" };
        }

        public override string EditorDescription =>
            "Seasons (period DD-MM → DD-MM) + CSS editor dialogs.\n" +
            "Files are saved in the plugin css/ folder. Off-season → default.css.\n" +
            "Missing file → Branding unchanged.\n" +
            "Apply: save settings / save CSS editor / task 03:15 / startup.";

        [DisplayName("CSS editor")]
        [Description("Open a dialog to paste / edit CSS for each theme.")]
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
