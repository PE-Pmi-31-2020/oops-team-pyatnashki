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
            GameWindow cw = new GameWindow();
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
            this.Close();
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
