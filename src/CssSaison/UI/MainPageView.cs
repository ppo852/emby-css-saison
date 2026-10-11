using System.Threading.Tasks;
using CssSaison.Services;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Plugins.UI.Views;

namespace CssSaison.UI
{
    internal class MainPageView : PluginPageView
    {
        private readonly PluginInfo _pluginInfo;
        private readonly OptionsStore _store;

        public MainPageView(PluginInfo pluginInfo, OptionsStore store)
            : base(pluginInfo.Id.ToString())
        {
            _pluginInfo = pluginInfo;
            _store = store;
            ContentData = MainPageUi.FromOptions(store.GetOptions());
            ShowSave = true;
            AllowSave = true;
        }

        public MainPageUi Ui => ContentData as MainPageUi;

        public override async Task<IPluginUIView> RunCommand(string itemId, string commandId, string data)
        {
            if (commandId != null && commandId.StartsWith("EditCss:"))
            {
                var key = commandId.Substring("EditCss:".Length);
                var opts = Ui ?? MainPageUi.FromOptions(_store.GetOptions());
                ThemeEngine.ResolveThemeFile(opts, key, out var label, out var file);
                var folder = ThemeEngine.ResolveCssFolder(opts);

                IPluginUIView dialog = new CssEditorDialogView(_pluginInfo, label, file, folder);
                return dialog;
            }

            return await base.RunCommand(itemId, commandId, data).ConfigureAwait(false);
        }

        public override Task<IPluginUIView> OnSaveCommand(string itemId, string commandId, string data)
        {
            var ui = Ui;
            if (ui != null)
            {
                ui.ValidateOrThrow();
                _store.SaveOptions(ui.ToOptions());
                Plugin.Instance?.ThemeEngine?.TryApplyFromPlugin();
            }

            return base.OnSaveCommand(itemId, commandId, data);
        }
    }
}
