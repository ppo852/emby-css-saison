using System;
using System.IO;
using CssSaison.Configuration;
using MediaBrowser.Common;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Serialization;

namespace CssSaison.Services
{
    public class OptionsStore
    {
        private readonly IJsonSerializer _json;
        private readonly ILogger _logger;
        private readonly string _path;
        private readonly object _lock = new object();
        private PluginOptions _options;

        public OptionsStore(IApplicationHost host, ILogger logger)
        {
            _logger = logger;
            _json = host.Resolve<IJsonSerializer>();
            var paths = host.Resolve<IApplicationPaths>();
            Directory.CreateDirectory(paths.PluginConfigurationsPath);
            _path = Path.Combine(paths.PluginConfigurationsPath, "CSS Saison.json");
        }

        public PluginOptions GetOptions()
        {
            lock (_lock)
            {
                if (_options != null)
                    return _options;

                try
                {
                    if (File.Exists(_path))
                    {
                        _options = _json.DeserializeFromFile<PluginOptions>(_path);
                    }
                }
                catch (Exception ex)
                {
                    _logger.ErrorException("Lecture options CSS Saison", ex);
                }

                if (_options == null)
                    _options = new PluginOptions();

                // Anciennes configs : Start/End seuls → reconstruire la ligne période pour l'UI
                _options.PullPeriodsFromDates();
                return _options;
            }
        }

        public void SaveOptions(PluginOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            lock (_lock)
            {
                options.PushPeriodsToDates();
                Directory.CreateDirectory(Path.GetDirectoryName(_path) ?? ".");
                _json.SerializeToFile(options, _path);
                _options = options;
            }
        }
    }
}
