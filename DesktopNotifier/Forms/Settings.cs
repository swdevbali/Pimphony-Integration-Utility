﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopNotifier.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            RegistrySettings.loadValues();
            numCheckInterval.Value = RegistrySettings.checkInterval;

            //check for autostart entry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (key.GetValue("Aquasol Desktop Notifier") == null)
            {
                chkRuntAtStartup.Checked = false;
            }
            else
            {
                chkRuntAtStartup.Checked = true;
            }
            key.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RegistrySettings.checkInterval = (int) numCheckInterval.Value;
            Program.mainForm.resetTimer();
            RegistrySettings.writeValues();

            //register for autostart entry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (chkRuntAtStartup.Checked)
            {
                key.SetValue("Aquasol Desktop Notifier", "\"" + Application.ExecutablePath + "\"");
            }
            else
            {
                key.DeleteValue("Aquasol Desktop Notifier");
            }
            key.Close();
            Close();
        }
    }
}
