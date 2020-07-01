using System.Windows.Forms;

namespace SpcTimer
{
    class NonSelectableComboBox : ComboBox
    {
        public NonSelectableComboBox()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
