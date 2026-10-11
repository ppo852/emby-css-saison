using MediaBrowser.Controller.Plugins;

namespace CssSaison
{
    public class SeasonEntryPoint : IServerEntryPoint
    {
        public void Run()
        {
            Plugin.Instance?.ThemeEngine?.TryApplyFromPlugin();
        }

        public void Dispose()
        {
        }
    }
}
