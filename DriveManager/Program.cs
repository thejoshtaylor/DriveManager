using DriveManager.Properties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


using Usb.Events;

namespace DriveManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new TaskTrayIconContext());

            usbEventWatcher.UsbDeviceRemoved += UsbEventWatcher_UsbDeviceRemoved;
            usbEventWatcher.UsbDeviceAdded += UsbEventWatcher_UsbDeviceAdded;
            usbEventWatcher.UsbDriveEjected += UsbEventWatcher_UsbDriveEjected;
            usbEventWatcher.UsbDriveMounted += UsbEventWatcher_UsbDriveMounted;
        }

        // This is triggered when a USB device (any kind) is removed
        private static void UsbEventWatcher_UsbDeviceRemoved(object sender, UsbDevice device)
        {
            throw new NotImplementedException();
        }

        // This is triggered when a USB device (any kind) is inserted
        private static void UsbEventWatcher_UsbDeviceAdded(object sender, UsbDevice device)
        {
            throw new NotImplementedException();
        }

        // This is triggered when the USB drive directory collapses
        private static void UsbEventWatcher_UsbDriveEjected(object sender, string path)
        {
            throw new NotImplementedException();
        }

        // This triggers when a USB drive is made into a "directory" on Windows
        private static void UsbEventWatcher_UsbDriveMounted(object sender, string path)
        {
            throw new NotImplementedException();
        }

        static readonly IUsbEventWatcher usbEventWatcher = new UsbEventWatcher();

        public class TaskTrayIconContext : ApplicationContext
        {
            private NotifyIcon trayIcon;

            public TaskTrayIconContext()
            {
                // Initialize Tray Icon
                trayIcon = new NotifyIcon()
                {
                    Text = "Drive Manager",
                    Icon = Resources.AppIcon,
                    ContextMenu = new ContextMenu(new MenuItem[] {
                            new MenuItem("Manage", OpenForm),
                            new MenuItem("Exit", Exit)
                        }),
                    Visible = true
                };

                trayIcon.Click += trayIcon_Click;
            }

            void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Visible = false;

                Application.Exit();
            }

            void OpenForm(object sender, EventArgs e)
            {
                ManageWindow window = new ManageWindow(trayIcon);
                window.Show();
            }

            private void trayIcon_Click(object sender, EventArgs e)
            {
                MouseEventArgs mouse = e as MouseEventArgs;

                switch (mouse.Button)
                {
                    case MouseButtons.Left:
                        OpenForm(null, null);
                        break;
                }
            }
        }
    }
}
