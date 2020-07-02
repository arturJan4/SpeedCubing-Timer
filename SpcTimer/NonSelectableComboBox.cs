using System.Windows.Forms;

namespace SpcTimer
{
    /// <summary>
    /// ComboBox which cannot be selected by TAB
    /// </summary>
    internal class NonSelectableComboBox : ComboBox
    {
        public NonSelectableComboBox()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
