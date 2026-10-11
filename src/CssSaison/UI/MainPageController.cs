using System.Threading.Tasks;
using CssSaison.Services;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Plugins.UI.Views;

namespace CssSaison.UI
{
    internal class MainPageController : ControllerBase
    {
        private readonly PluginInfo _pluginInfo;
        private readonly OptionsStore _store;

        public MainPageController(PluginInfo pluginInfo, OptionsStore store)
            : base(pluginInfo.Id.ToString())
        {
            _pluginInfo = pluginInfo;
            _store = store;

            PageInfo = new PluginPageInfo
            {
                Name = "CssSaisonSettings",
                DisplayName = PluginConstants.Name,
                EnableInMainMenu = true,
                IsMainConfigPage = true,
                MenuSection = "server",
                MenuIcon = "palette"
            };
        }

        public override PluginPageInfo PageInfo { get; }

        public override Task<IPluginUIView> CreateDefaultPageView()
        {
            IPluginUIView view = new MainPageView(_pluginInfo, _store);
            return Task.FromResult(view);
        }
    }
}
