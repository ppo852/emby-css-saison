using System;
using System.Collections.Generic;
using CssSaison.Services;
using CssSaison.UI;
using MediaBrowser.Common;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Plugins.UI;

namespace CssSaison
{
    public class Plugin : BasePlugin, IHasUIPages
    {
        private List<IPluginUIPageController> _pages;

        // IApplicationPaths required by Emby DI (DataFolderPath via BasePlugin).
        public Plugin(IApplicationHost applicationHost, IApplicationPaths applicationPaths, ILogManager logManager)
        {
            Instance = this;
            ApplicationHost = applicationHost;
            var logger = logManager.GetLogger(Name);
            OptionsStore = new OptionsStore(applicationHost, logger);
            ThemeEngine = new ThemeEngine(applicationHost.Resolve<IConfigurationManager>(), logger);
        }

        public static Plugin Instance { get; private set; }

        public IApplicationHost ApplicationHost { get; }

        public OptionsStore OptionsStore { get; }

        public ThemeEngine ThemeEngine { get; }

        public override Guid Id => new Guid("D4E8F1A2-3B5C-4D6E-8F90-1A2B3C4D5E6F");

        public override string Name => PluginConstants.Name;

        public override string Description =>
            "Applies Branding Custom CSS by calendar windows (DD-MM), with an in-dashboard CSS editor.";

        public Configuration.PluginOptions Options => OptionsStore.GetOptions();

        public IReadOnlyCollection<IPluginUIPageController> UIPageControllers
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new List<IPluginUIPageController>
                    {
                        new MainPageController(GetPluginInfo(), OptionsStore)
                    };
                }

                return _pages.AsReadOnly();
            }
        }
    }
}
