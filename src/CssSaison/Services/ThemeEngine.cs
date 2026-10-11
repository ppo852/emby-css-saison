using System;
using System.IO;
using CssSaison.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Model.Branding;
using MediaBrowser.Model.Logging;

namespace CssSaison.Services
{
    public class ThemeEngine
    {
        private readonly IConfigurationManager _configManager;
        private readonly ILogger _logger;

        public ThemeEngine(IConfigurationManager configManager, ILogger logger)
        {
            _configManager = configManager;
            _logger = logger;
        }

        public bool TryApplyFromPlugin()
        {
            if (Plugin.Instance == null)
            {
                _logger.Warn("Plugin.Instance null — application annulée.");
                return false;
            }

            return TryApply(Plugin.Instance.Options);
        }

        public bool TryApply(PluginOptions options)
        {
            try
            {
                Apply(options);
                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorException("Échec application " + PluginConstants.Name, ex);
                return false;
            }
        }

        public void Apply(PluginOptions options)
        {
            if (options == null || !options.Enabled)
            {
                _logger.Info("{0} désactivé — Branding non modifié.", PluginConstants.Name);
                return;
            }

            var folder = ResolveCssFolder(options);
            Directory.CreateDirectory(folder);

            var resolution = Resolve(options, DateTime.Now.Date);
            if (resolution == null)
            {
                _logger.Info("Aucune règle / défaut applicable — Branding non modifié.");
                return;
            }

            var safeName = Path.GetFileName(resolution.CssFileName);
            if (string.IsNullOrWhiteSpace(safeName) ||
                !string.Equals(safeName, resolution.CssFileName.Trim(), StringComparison.Ordinal))
            {
                _logger.Warn("Nom de fichier CSS invalide : {0}", resolution.CssFileName);
                return;
            }

            var cssPath = Path.Combine(folder, safeName);
            if (!File.Exists(cssPath))
            {
                _logger.Warn("Fichier CSS manquant ({0}) : {1} — Branding non modifié.", resolution.Label, cssPath);
                return;
            }

            string css;
            try
            {
                css = File.ReadAllText(cssPath);
            }
            catch (Exception ex)
            {
                _logger.ErrorException("Lecture CSS impossible : " + cssPath, ex);
                return;
            }

            if (string.IsNullOrWhiteSpace(css))
            {
                _logger.Warn("Fichier CSS vide : {0}", cssPath);
                return;
            }

            var branding = _configManager.GetConfiguration<BrandingOptions>("branding");
            var current = branding.CustomCss ?? string.Empty;

            if (string.Equals(current, css, StringComparison.Ordinal))
            {
                _logger.Info("Déjà à jour : {0}", resolution.Label);
                return;
            }

            branding.CustomCss = css;
            _configManager.SaveConfiguration("branding", branding);
            _logger.Info("Appliqué : {0} ← {1}", resolution.Label, cssPath);
        }

        public static ResolvedTheme Resolve(PluginOptions options, DateTime today)
        {
            if (options == null)
                return null;

            if (options.Mode == SeasonMode.Manual)
                return ResolveForced(options);

            // Priority = declaration order below (first match wins).
            if (Match(options.ValentineEnabled, options.ValentineStart, options.ValentineEnd, today))
                return FileTheme("Valentine", options.ValentineCssFile);

            if (Match(options.SaintPatrickEnabled, options.SaintPatrickStart, options.SaintPatrickEnd, today))
                return FileTheme("Saint-Patrick", options.SaintPatrickCssFile);

            if (Match(options.PaquesEnabled, options.PaquesStart, options.PaquesEnd, today))
                return FileTheme("Pâques", options.PaquesCssFile);

            if (Match(options.JuilletEnabled, options.JuilletStart, options.JuilletEnd, today))
                return FileTheme("4 Juillet", options.JuilletCssFile);

            if (Match(options.HalloweenEnabled, options.HalloweenStart, options.HalloweenEnd, today))
                return FileTheme("Halloween", options.HalloweenCssFile);

            if (Match(options.ThanksgivingEnabled, options.ThanksgivingStart, options.ThanksgivingEnd, today))
                return FileTheme("Thanksgiving", options.ThanksgivingCssFile);

            if (Match(options.NoelEnabled, options.NoelStart, options.NoelEnd, today))
                return FileTheme("Noël", options.NoelCssFile);

            if (Match(options.NouvelAnEnabled, options.NouvelAnStart, options.NouvelAnEnd, today))
                return FileTheme("Nouvel An", options.NouvelAnCssFile);

            return FileTheme("Défaut", options.DefaultCssFileName);
        }

        private static ResolvedTheme ResolveForced(PluginOptions options)
        {
            switch (options.ForcedSeason)
            {
                case ForcedSeason.Valentine: return FileTheme("Valentine", options.ValentineCssFile);
                case ForcedSeason.SaintPatrick: return FileTheme("Saint-Patrick", options.SaintPatrickCssFile);
                case ForcedSeason.Paques: return FileTheme("Pâques", options.PaquesCssFile);
                case ForcedSeason.Juillet: return FileTheme("4 Juillet", options.JuilletCssFile);
                case ForcedSeason.Halloween: return FileTheme("Halloween", options.HalloweenCssFile);
                case ForcedSeason.Thanksgiving: return FileTheme("Thanksgiving", options.ThanksgivingCssFile);
                case ForcedSeason.Noel: return FileTheme("Noël", options.NoelCssFile);
                case ForcedSeason.NouvelAn: return FileTheme("Nouvel An", options.NouvelAnCssFile);
                default: return FileTheme("Défaut", options.DefaultCssFileName);
            }
        }

        private static bool Match(bool enabled, string start, string end, DateTime today)
        {
            return enabled && SeasonDateHelper.IsInRange(today, start, end);
        }

        private static ResolvedTheme FileTheme(string label, string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                return null;
            return new ResolvedTheme(label, file.Trim());
        }

        public static string ResolveCssFolder(PluginOptions options)
        {
            if (options != null && !string.IsNullOrWhiteSpace(options.CssFolderPath))
                return options.CssFolderPath.Trim();

            if (Plugin.Instance != null && !string.IsNullOrWhiteSpace(Plugin.Instance.DataFolderPath))
                return Path.Combine(Plugin.Instance.DataFolderPath, "css");

            return Path.Combine(Path.GetTempPath(), "CssSaison", "css");
        }

        /// <summary>Résout libellé + nom de fichier pour une clé UI (EditCss:…).</summary>
        public static void ResolveThemeFile(PluginOptions opts, string key, out string label, out string file)
        {
            switch (key)
            {
                case "Valentine":
                    label = "Valentine"; file = opts?.ValentineCssFile; break;
                case "SaintPatrick":
                    label = "Saint-Patrick"; file = opts?.SaintPatrickCssFile; break;
                case "Paques":
                    label = "Pâques"; file = opts?.PaquesCssFile; break;
                case "Juillet":
                    label = "4 Juillet"; file = opts?.JuilletCssFile; break;
                case "Halloween":
                    label = "Halloween"; file = opts?.HalloweenCssFile; break;
                case "Thanksgiving":
                    label = "Thanksgiving"; file = opts?.ThanksgivingCssFile; break;
                case "Noel":
                    label = "Noël"; file = opts?.NoelCssFile; break;
                case "NouvelAn":
                    label = "Nouvel An"; file = opts?.NouvelAnCssFile; break;
                default:
                    label = "Défaut"; file = opts?.DefaultCssFileName; break;
            }

            if (string.IsNullOrWhiteSpace(file))
                file = (key ?? "default").ToLowerInvariant() + ".css";
        }

        public sealed class ResolvedTheme
        {
            public ResolvedTheme(string label, string cssFileName)
            {
                Label = label;
                CssFileName = cssFileName;
            }

            public string Label { get; }
            public string CssFileName { get; }
        }
    }
}
