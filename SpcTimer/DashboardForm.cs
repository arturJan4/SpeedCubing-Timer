using System;
using System.Drawing;
using System.Windows.Forms;
using TimerLibrary;

namespace SpcTimer
{
    /// <summary>
    /// Main form implementing View interface.
    /// </summary>
    public partial class DashboardForm : Form, IViewInterface
    {
        /// <summary>
        /// Link to the Controller class.
        /// </summary>
        private Controller controller;
        /// <summary>
        /// Inititilzing a form.
        /// </summary>
        public DashboardForm()
        {
            InitializeComponent();
            controller = new Controller(this)
            {
                DirName = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
            };

            KeyPreview = true;                  // allows keyboard control
            controller.InspectionTime = 15;     // default inspection time

            /*
            Scramble newScramble = new Scramble(new ThreeByThreeScramble());
            LabelTest.Text = newScramble.Representation;
            */

        }
        /// <summary>
        /// Links the controller to the current form.
        /// </summary>
        /// <param name="controller"></param>
        public void SetController(Controller controller)
        {
            this.controller = controller;
        }
        /// <summary>
        /// Internal Winforms Timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWinformsTimer_Tick(object sender, EventArgs e)
        {
            controller.Update();
        }
        #region Labels
        /// <summary>
        /// Clock in HH:MM:SS:FF format.
        /// </summary>
        public string ClockTime
        {
            get => ClockLabel.Text;
            set => ClockLabel.Text = value;
        }
        /// <summary>
        /// Text representation of a scramble.
        /// </summary>
        public string Scramble
        {
            get => ScrambleLabel.Text;
            set => ScrambleLabel.Text = value;
        }
        /// <summary>
        /// Shows up when the current solve is disqualified.
        /// </summary>
        public string DNF
        {
            get => DNFLabel.Text;
            set => DNFLabel.Text = value;
        }
        /// <summary>
        /// Shows the current cube type
        /// </summary>
        public string CubeTypeLabelInter
        {
            get => CubeTypeLabel.Text;
            set => CubeTypeLabel.Text = value;
        }
        /// <summary>
        /// Shows the current best score given current cube type.
        /// </summary>
        public string BestValue
        {
            get => BestValueLabel.Text;
            set
            {
                BestValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                BestValueLabel.Text = value;
            }
        }
        /// <summary>
        /// Shows the current worst score given current cube type.
        /// </summary>
        public string WorstValue
        {
            get => WorstValueLabel.Text;
            set
            {
                WorstValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                WorstValueLabel.Text = value;
            }
        }
        /// <summary>
        /// Shows the current average score given current cube type.
        /// </summary>
        public string AverageValue
        {
            get => AverageValueLabel.Text;
            set
            {
                AverageValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                AverageValueLabel.Text = value;
            }
        }
        /// <summary>
        /// Shows the BO5 of given cube type if applicable (there may be less then 5 solves).
        /// </summary>
        public string Bo5Value
        {
            get => Bo5ValueLabel.Text;
            set
            {
                Bo5ValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                Bo5ValueLabel.Text = value;
            }
        }
        /// <summary>
        /// Shows the BO12 of given cube type if applicable (there may be less then 12 solves).
        /// </summary>
        public string Bo12Value
        {
            get => Bo12ValueLabel.Text;
            set
            {
                Bo12ValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                Bo12ValueLabel.Text = value;
            }
        }
        #endregion
        #region Visual
        /// <summary>
        /// Changes color of the clock text.
        /// </summary>
        /// <param name="color">Color Enum (can use RGB input)</param>
        public void SetClockColor(Color color)
        {
            ClockLabel.ForeColor = color;
        }
        /// Changes color of form background
        /// </summary>
        /// <param name="color">Color Enum (can use RGB input)</param>
        public void SetBackgroundColor(Color color)
        {
            DashboardForm.ActiveForm.BackColor = color;
        }
        /// <summary>
        /// Does a start/stop action on the timer.
        /// </summary>
        public void TimerInteract()
        {
            controller.StartStopTimer();
        }
        #endregion
        #region Statistics
        /// <summary>
        /// string of an item currently selected in the statistics box.
        /// </summary>
        private string selectedItem = "";
        /// <summary>
        /// Deletes item selected in current box.
        /// </summary>
        /// <param name="selectedItem">Full string of selected item</param>
        public void DeleteSelectedStatistics(string selectedItem)
        {
            if (StatisticsListBox.Items.Count == 0)
            {
                const string message = "No element to remove";
                const string caption = "Error";
                MessageBox.Show(message, caption);
                return;
            }
            string parsed = selectedItem.Split('[', ']')[1];
            controller.DeleteStatisticsById(int.Parse(parsed));
        }
        /// <summary>
        /// Deletes all statistics
        /// </summary>
        public void DeleteAllStatistics()
        {
            const string message = "Do you want to delete all solves (of all cube types)?";
            const string caption = "Confirmation";
            DialogResult result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            controller.DeleteAllStatistics();
            controller.UpdateStatistics();
            StatisticsListBox.Items.Clear();
        }
        /// <summary>
        /// Deletes item last inputted in current box.
        /// </summary>
        public void DeleteLastStatistics()
        {
            if (StatisticsListBox.Items.Count == 0)
            {
                const string message = "No element to remove";
                const string caption = "Error";
                MessageBox.Show(message, caption);
                return;
            }
            const string message2 = "Do you want to delete last solve?";
            const string caption2 = "Confirmation";
            DialogResult result = MessageBox.Show(message2, caption2,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            controller.DeleteLast();
            controller.UpdateStatistics();
            StatisticsListBox.Items.RemoveAt(StatisticsListBox.Items.Count - 1);
        }
        /// <summary>
        /// Adds one item to the box.
        /// </summary>
        /// <param name="item">Format: [id] time</param>
        public void AddStatistics(string item)
        {
            StatisticsListBox.Items.Add(item);
        }
        /// <summary>
        /// Automatically selects and scrolls to the last statistic in the box.
        /// </summary>
        public void GoToLastStatistics()
        {
            StatisticsListBox.SelectedIndex = StatisticsListBox.Items.Count - 1;
        }
        /// <summary>
        /// Clears the statistics box (without deleting statistics)
        /// </summary>
        public void ClearStatisticsBox()
        {
            StatisticsListBox.Items.Clear();
        }
        /// <summary>
        /// Event signalling that selection in statistics listbox has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatisticsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = StatisticsListBox.GetItemText(StatisticsListBox.SelectedItem);
        }
        #endregion
        #region Controls
        /// <summary>
        /// User changed cube type in control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CubeTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (CubeTypeComboBox.SelectedItem.ToString().Trim())
            {
                case "2x2 Cube":
                    controller.ChangeCubeType(CubeType.TWO);
                    break;

                case "3x3 Cube":
                    controller.ChangeCubeType(CubeType.THREE);
                    break;

                case "4x4 Cube":
                    controller.ChangeCubeType(CubeType.FOUR);
                    break;

                default:
                    throw new InvalidOperationException("Unknown ComboBox option");
                    break;
            }
        }
        /// <summary>
        /// User clicked a start time button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTimerButton_Click_1(object sender, EventArgs e)
        {
            controller.StartStopTimer();
        }
        /// <summary>
        /// User clicked a confirm button to confirm changes in inspection time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmInspectionButton_Click(object sender, EventArgs e)
        {
            int.TryParse(InspectionTimeLabel.Text, out int inspectionTimeValue);
            controller.InspectionTime = inspectionTimeValue;
        }
        /// <summary>
        /// User clicked a button to turn on/off sound.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoundButton_Click(object sender, EventArgs e)
        {
            controller.ChangePlaySounds();
        }
        /// <summary>
        /// User clicked a button to markt the current solve as disqualified.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDNFButton_Click(object sender, EventArgs e)
        {
            if (StatisticsListBox.Items.Count == 0)
            {
                const string message2 = "No solve to mark as diqualified";
                const string caption2 = "Error";
                MessageBox.Show(message2, caption2);
                return;
            }
            const string message = "Do you want to mark current solve as DNF";
            const string caption = "Confirmation";
            DialogResult result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            controller.SetDNF();
        }
        /// <summary>
        /// User clicked a button to delete selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedStatistics(selectedItem);
            ClearStatisticsBox();
            controller.UpdateStatistics();
        }
        /// <summary>
        /// User clicked a button to delete an item last inputted in statistics box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteLastButton_Click(object sender, EventArgs e)
        {
            DeleteLastStatistics();
            controller.UpdateStatistics();
        }
        /// <summary>
        /// User clicked a button to delete all statistics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            DeleteAllStatistics();
            controller.UpdateStatistics();
        }
        #endregion
        #region KeyboardInput
        /// <summary>
        /// Checks if any key is currently still pressed
        /// </summary>
        private bool keyPressed = false;
        /// <summary>
        /// Controls when to start/stop timer and visibility of InspectionLabel, changes InfoLabels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DashboardForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
            if (controller.IsInspecting() && e.KeyCode == Keys.Space)
            {
                InspectionLabel.Visible = false;
                controller.StartStopTimer();
                InfoLabel.Text = "Hit space to stop timer";
            }
        }
        //ref: https://stackoverflow.com/questions/1140250/how-to-remove-the-focus-from-a-textbox-in-winforms
        /// <summary>
        /// Controls when to start/stop timer and visibility of InspectionLabel, changes InfoLabels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyPressed)
            {
                InspectionTimeLabel.Enabled = false;
                e.Handled = true;
            }
            else
            {
                InspectionTimeLabel.Enabled = true;
                keyPressed = true;
                if (e.KeyCode == Keys.Space)
                {
                    InspectionTimeLabel.Enabled = false;
                    if (controller.IsWating())
                    {
                        controller.StartStopTimer();
                        InspectionLabel.Visible = true;
                        InfoLabel.Text = "Release space to begin timer";
                    }

                    if (controller.IsSolving())
                    {
                        controller.StartStopTimer();
                        InfoLabel.Text = "Hold space to begin inspection";
                        InspectionTimeLabel.Enabled = true;
                    }
                }

            }

        }
        #endregion
    }
}
