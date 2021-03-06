﻿/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 */
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Sasinosoft.SampMapEditor.Utils;

namespace Sasinosoft.SampMapEditor.View
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindowViewModel ViewModel { get; private set; }

        public SettingsWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as SettingsWindowViewModel;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.GTASAPath = ViewModel.GTASAPath;
            Properties.Settings.Default.Save();
        }

        private void OnBrowseButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.Description = "Select any valid GTA San Andreas installation directory";
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ViewModel.GTASAPath = dialog.SelectedPath;
            }
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class SettingsWindowViewModel : ViewModel
    {
        private string gtaSAPath;
        public string GTASAPath
        {
            get { return gtaSAPath; }
            set { SetProperty(ref gtaSAPath, value); }
        }
    }
}
