﻿using System;
using System.Windows.Forms;
using GitCommands;

namespace GitUI
{
    public partial class FormCleanupRepository : GitExtensionsForm
    {
        public FormCleanupRepository()
        {
            InitializeComponent(); Translate();
            PreviewOutput.ReadOnly = true;
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            var form = new FormProcess(GitCommandHelpers.CleanUpCmd(true, RemoveDirectories.Checked, RemoveNonIgnored.Checked, RemoveIngnored.Checked));
            form.ShowDialog();
            PreviewOutput.Text = form.OutputString.ToString();
        }

        private void Cleanup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cleanup the repository?", "Cleanup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var form = new FormProcess(GitCommandHelpers.CleanUpCmd(false, RemoveDirectories.Checked, RemoveNonIgnored.Checked, RemoveIngnored.Checked));
                form.ShowDialog();
                PreviewOutput.Text = form.OutputString.ToString();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
