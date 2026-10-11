using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Model.Tasks;

namespace CssSaison
{
    public class ApplySeasonTask : IScheduledTask
    {
        public string Name => PluginConstants.Name + " — Apply theme";

        public string Key => PluginConstants.TaskKey;

        public string Description =>
            "Recomputes the season and updates Branding Custom CSS.";

        public string Category => PluginConstants.Name;

        public Task Execute(CancellationToken cancellationToken, IProgress<double> progress)
        {
            progress?.Report(0);
            if (!cancellationToken.IsCancellationRequested)
                Plugin.Instance?.ThemeEngine?.TryApplyFromPlugin();
            progress?.Report(100);
            return Task.CompletedTask;
        }

        public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
        {
            return new[]
            {
                new TaskTriggerInfo
                {
                    Type = TaskTriggerInfo.TriggerDaily,
                    TimeOfDayTicks = TimeSpan.FromHours(3).Add(TimeSpan.FromMinutes(15)).Ticks
                }
            };
        }
    }
}
