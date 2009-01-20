﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GitCommands;
using System.IO;

namespace GitUI
{
    public partial class Open : Form
    {
        public Open()
        {
            InitializeComponent();

            Directory.DataSource = RepositoryHistory.MostRecentRepositories;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browseDialog = new FolderBrowserDialog();

            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                Directory.Text = browseDialog.SelectedPath;
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Directory.Text))
            {
                Settings.WorkingDir = Directory.Text;

                RepositoryHistory.AddMostRecentRepository(Settings.WorkingDir);

                Close();
            }
            else
            {
                MessageBox.Show("Directory does not exist.", "Error");
            }
        }

        private void Directory_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}