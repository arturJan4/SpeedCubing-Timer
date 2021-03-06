﻿using System.Windows.Forms;

namespace SpcTimer
{
    /// <summary>
    /// Button which cannot be selected by TAB
    /// </summary>
    public class NonSelectableButton : Button
    {
        //https://stackoverflow.com/questions/32823525/how-to-stop-pressing-button-using-keyboard-keys-like-spacebar-or-enter-c-shar
        public NonSelectableButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
