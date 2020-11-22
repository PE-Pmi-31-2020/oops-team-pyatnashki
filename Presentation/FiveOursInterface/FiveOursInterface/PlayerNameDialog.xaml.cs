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
        public PlayerNameDialog()
        {
            InitializeComponent();
        }

        private void OkBtnClick(object sender, RoutedEventArgs e)
        {
            var playerName = textBoxPlayerName.Text;
            if(playerName == "")
            {
                MessageBox.Show("Player name field can not be empty!", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GameWindow cw = new GameWindow(playerName);
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;
            Owner.Visibility = Visibility.Hidden;
            cw.Show();
            Close();
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
