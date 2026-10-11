using System;
using System.Threading.Tasks;
using MediaBrowser.Model.Plugins.UI.Views;

namespace CssSaison.UI
{
    internal abstract class PluginDialogView : PluginViewBase, IPluginDialogView
    {
        protected PluginDialogView(string pluginId)
            : base(pluginId)
        {
            AllowCancel = true;
            AllowOk = true;
            DialogSize = MediaBrowser.Model.Plugins.UI.Views.Enums.DialogSize.FullScreen;
        }

        public bool AllowCancel { get; set; }

        public bool AllowOk { get; set; }

        public virtual bool ShowDialogFullScreen => false;

        public virtual Task OnCancelCommand() => Task.CompletedTask;

        public virtual Task OnOkCommand(string providerId, string commandId, string data)
        {
            throw new NotImplementedException();
        }
    }
}
