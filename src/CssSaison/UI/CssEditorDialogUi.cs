using System.ComponentModel;
using Emby.Web.GenericEdit;
using MediaBrowser.Model.Attributes;

namespace CssSaison.UI
{
    public class CssEditorDialogUi : EditableOptionsBase
    {
        // Empty title/description avoids double chrome (dialog + form headers).
        public override string EditorTitle => string.Empty;

        public override string EditorDescription => string.Empty;

        [Browsable(false)]
        public string FileName { get; set; }

        [DisplayName("CSS content")]
        [EditMultiline(24)]
        public string CssContent { get; set; } = string.Empty;
    }
}
