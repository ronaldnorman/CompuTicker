using CompuTicker.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuTicker.UI
{
    public partial class MainForm : Form
    {
        IMainController _mainController;
        private bool _statusStarted;

        public MainForm(IMainController mainController)
        {
            InitializeComponent();

            _mainController = mainController;
            _mainController.TickerProcessed += OnTickerProcessed;
            _mainController.NetworkErrorEncountered += OnNetworkErrorEncountered;

            SetStartStatus();
        }

        private void OnNetworkErrorEncountered(object sender, EventArgs e)
        {
            AlertLabel.Visible = true;
            AlertLabel.Text = "Connecting...";
        }

        private void _mainController_NetworkErrorEncountered(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Await.Warning", "CS4014:Await.Warning")]
        private void StartToggleButton_Click(object sender, EventArgs e)
        {
            // Fire and forget
            HandleStartOrStopAsync();
        }

        private async Task HandleStartOrStopAsync()
        {
            try
            {
                if (!_statusStarted)
                {
                    SetStopStatus();
                    await _mainController.StartPolling();
                }
                else
                {
                    SetStartStatus();
                    _mainController.StopPolling();
                }
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException || ex is ObjectDisposedException)
                    return;

                var answer = MessageBox.Show($"Oops! Something went wrong.\r\n\r\n{ex.Message}. Exit?",
                    "Error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (answer == DialogResult.Yes)
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }

                SetStartStatus();
            }
        }

        private void SetStopStatus()
        {
            _statusStarted = true;
            StartToggleButton.Text = "STOP";
            StartToggleButton.BackColor = Color.Red;
        }

        private void SetStartStatus()
        {
            _statusStarted = false;
            AlertLabel.Visible = false;
            StartToggleButton.Text = "START";
            StartToggleButton.BackColor = Color.DodgerBlue;
        }

        private void OnTickerProcessed(object sender, TickerProcessedEventArgs e)
        {
            if (e != null && e.Equation!= null)
            {
                AlertLabel.Visible = false;
                LogListBox.Items.Insert(0, $"{e.DateProcessed}: {e.Equation.Param1} {e.Equation.Operation} {e.Equation.Param2} = {e.Result}");
            }
        }

        private void ClearLogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var answer = MessageBox.Show("Clearing the log. Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                LogListBox.Items.Clear();
            }
        }
    }
}
