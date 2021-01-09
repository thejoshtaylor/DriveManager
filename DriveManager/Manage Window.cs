using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveManager
{
    public partial class ManageWindow : Form
    {
        NotifyIcon trayIcon;

        public ManageWindow(NotifyIcon trayIcon)
        {
            InitializeComponent();

            this.trayIcon = trayIcon;

            this.ShowInTaskbar = false;  // Removes the application from the taskbar
            Hide();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
