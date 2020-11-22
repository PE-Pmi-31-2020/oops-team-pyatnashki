using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FiveOursInterface
{
    /// <summary>
    /// Interaction logic for PlayerNameDialog.xaml
    /// </summary>
    public partial class PlayerNameDialog : Window
    {
        public string Name
        {
            get { return textBoxPlayerName.Text; }
        }

        private bool _isForSaving;

        public PlayerNameDialog(bool isForSaving = false)
        {
            InitializeComponent();

            _isForSaving = isForSaving;
        }

        private void OkBtnClick(object sender, RoutedEventArgs e)
        {
            
            var playerName = textBoxPlayerName.Text;
            if (playerName == "")
            {
                MessageBox.Show("Player name field can not be empty!", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DialogResult = true;
        }
    }
}
