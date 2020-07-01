using System.Windows.Forms;

namespace SpcTimer
{
    internal class NonSelectableComboBox : ComboBox
    {
        public NonSelectableComboBox()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
