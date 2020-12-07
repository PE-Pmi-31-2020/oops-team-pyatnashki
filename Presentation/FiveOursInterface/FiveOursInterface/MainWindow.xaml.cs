﻿using FiveOursInterface.Logger;
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
            GameWindow cw = new GameWindow();
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;
            this.Visibility = Visibility.Hidden;
            LogHelper.Log(LogTarget.File, "Fast game started.");
            cw.Show();
        }

        private void NotFastGameBtnClick(object sender, RoutedEventArgs e)
        {
            PlayerNameDialog nameWindow = new PlayerNameDialog();

            if (nameWindow.ShowDialog() == true)
            {
                GameWindow cw = new GameWindow(nameWindow.Name);
                cw.ShowInTaskbar = false;
                cw.Owner = Application.Current.MainWindow;
                this.Visibility = Visibility.Hidden;
                LogHelper.Log(LogTarget.File, $"Usual game started. Player name: {nameWindow.Name}");
                cw.Show();
            }
        }

        private void ResultsBtnClick(object sender, RoutedEventArgs e)
        {
            ResultsWindow cw = new ResultsWindow();
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;
            this.Visibility = Visibility.Hidden;
            cw.Show();
        }
    }
}
