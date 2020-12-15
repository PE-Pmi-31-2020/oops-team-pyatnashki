using FiveOursInterface.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FiveOursInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FastGameBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                GameWindow cw = new GameWindow();
                cw.ShowInTaskbar = false;
                cw.Owner = Application.Current.MainWindow;
                this.Visibility = Visibility.Hidden;
                LogHelper.Log(LogTarget.File, LogType.Info, "Fast game started.");
                cw.Show();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, LogType.Fatal, ex.ToString());
            }
        }

        private void NotFastGameBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                PlayerNameDialog nameWindow = new PlayerNameDialog();

                if (nameWindow.ShowDialog() == true)
                {
                    GameWindow cw = new GameWindow(nameWindow.Name);
                    cw.ShowInTaskbar = false;
                    cw.Owner = Application.Current.MainWindow;
                    this.Visibility = Visibility.Hidden;
                    LogHelper.Log(LogTarget.File, LogType.Info, $"Usual game started. Player name: {nameWindow.Name}");
                    cw.Show();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, LogType.Fatal, ex.ToString());
            }
        }

        private void ResultsBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultsWindow cw = new ResultsWindow();
                cw.ShowInTaskbar = false;
                cw.Owner = Application.Current.MainWindow;
                this.Visibility = Visibility.Hidden;
                cw.Show();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, LogType.Fatal, ex.ToString());
            }
        }
    }
}
