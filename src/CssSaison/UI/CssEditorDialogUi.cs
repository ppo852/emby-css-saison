using System.ComponentModel;
using Emby.Web.GenericEdit;
using MediaBrowser.Model.Attributes;

namespace CssSaison.UI
{
    public class CssEditorDialogUi : EditableOptionsBase
    {
        // Titre/description vides : évite le double bandeau (chrome dialog + formulaire).
        public override string EditorTitle => string.Empty;

        public override string EditorDescription => string.Empty;

        [Browsable(false)]
        public string FileName { get; set; }

        [DisplayName("Contenu CSS")]
        [EditMultiline(24)]
        public string CssContent { get; set; } = string.Empty;
    }
}
