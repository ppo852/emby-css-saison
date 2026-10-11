using System.IO;
using System.Threading.Tasks;
using CssSaison.Services;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Plugins.UI.Views;

namespace CssSaison.UI
{
    internal class CssEditorDialogView : PluginDialogView
    {
        private readonly string _folder;
        private readonly string _themeLabel;

        public CssEditorDialogView(PluginInfo pluginInfo, string themeLabel, string fileName, string folder)
            : base(pluginInfo.Id.ToString())
        {
            _folder = folder;
            _themeLabel = themeLabel ?? string.Empty;
            OKButtonCaption = "Enregistrer";
            AllowCancel = true;
            AllowOk = true;
            DialogSize = MediaBrowser.Model.Plugins.UI.Views.Enums.DialogSize.FullScreen;

            var content = string.Empty;
            Directory.CreateDirectory(folder);
            var path = Path.Combine(folder, Path.GetFileName(fileName) ?? fileName);
            if (File.Exists(path))
            {
                try { content = File.ReadAllText(path); }
                catch { /* empty */ }
            }

            ContentData = new CssEditorDialogUi
            {
                FileName = fileName,
                CssContent = content
            };
        }

        public override string Caption => "CSS — " + _themeLabel;

        public override string SubCaption => string.Empty;

        public override bool ShowDialogFullScreen => true;

        private CssEditorDialogUi Ui => ContentData as CssEditorDialogUi;

        public override Task OnOkCommand(string providerId, string commandId, string data)
        {
            var ui = Ui;
            if (ui == null || string.IsNullOrWhiteSpace(ui.FileName))
                return Task.CompletedTask;

            var safe = Path.GetFileName(ui.FileName);
            Directory.CreateDirectory(_folder);
            var path = Path.Combine(_folder, safe);
            File.WriteAllText(path, ui.CssContent ?? string.Empty);

            Plugin.Instance?.ThemeEngine?.TryApplyFromPlugin();

            return Task.CompletedTask;
        }
    }
}
