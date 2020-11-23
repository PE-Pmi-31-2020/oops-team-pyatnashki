using ResultsDbContext;
using ResultsDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FiveOursInterface
{

    public class GameButton : Button
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private int _x;
        private int _y;

        private string _playerName;

        private DispatcherTimer _timer;
        private TimeSpan _timerTime = new TimeSpan(0, 0, 0);

        private bool _isClosingByEndingGame = false;

        private int _moves = 0;

        private Dictionary<int, GameButton> _buttons = new Dictionary<int, GameButton>(16);


        public GameWindow(string playerName = "")
        {
            InitializeComponent();

            _playerName = playerName;

            int i = 0;
            foreach (var obj in grid.Children)
            {
                if (obj is GameButton)
                {
                    var btn = (GameButton)obj;
                    btn.x = Grid.GetRow(btn);
                    btn.y = Grid.GetColumn(btn);
                    _buttons.Add(i++, btn);
                }
            }

            _buttons.Add(15, null);

            Random();

            InitializeTimer();
        }


        public void InitializeTimer()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            _timer.Tick += timerTick;
            _timer.Start();
        }

        void timerTick(object sender, EventArgs e)
        {
            _timerTime = _timerTime.Add(new TimeSpan(0, 0, 1));
            labelTimer.Content = _timerTime.ToString();
        }


        private void Random()
        {
            var rand = new Random();
            var a = new List<int>(16);
            var v = new List<int>(_buttons.Keys);

            int k = 0, n = 0;
            for (var x = 2; x < 6; x++)
            {
                for (var y = 1; y < 5; y++)
                {
                    do
                    {
                        k = rand.Next(0, v.Count);
                    }
                    while (a.Any(o => o == v[k]));

                    a.Add(v[k]);
                    v.RemoveAt(k);

                    var button = _buttons[a[n]];

                    if (button == null)
                    {
                        _x = x; _y = y;
                    }
                    else
                    {
                        Grid.SetRow(button, x);
                        Grid.SetColumn(button, y);
                    }
                    n++;
                }
            }

        }

        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (GameButton)sender;
            int x = Grid.GetRow(button);
            int y = Grid.GetColumn(button);

            if ((Math.Abs(_x - x) == 1 && _y == y)
                 || (Math.Abs(_y - y) == 1 && _x == x))
            {
                Grid.SetRow(button, _x);
                Grid.SetColumn(button, _y);
                _x = x; _y = y;
                labelCounter.Content = ++_moves;
            }
            else
            {
                return;
            }

            bool ok = _buttons.Values
                .Where(b => b != null)
                .All(b => b.x == Grid.GetRow(b)
                       && b.y == Grid.GetColumn(b));

            if (!ok)
            {
                //return;
            }

            _timer.Stop();
            GameCompleted();
        }

        private void GameCompleted()
        {
            MessageBox.Show("Niice!", "Completed",
                MessageBoxButton.OK, MessageBoxImage.Information);

            if (_playerName == "")
            {
                var mbResult = MessageBox.Show("Do you want to save your result?", "Saving results",
                MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (mbResult == MessageBoxResult.Yes)
                {
                    PlayerNameDialog nameWindow = new PlayerNameDialog();

                    if (nameWindow.ShowDialog() == true)
                    {
                        _playerName = nameWindow.Name;
                    }
                }
            }
            if (_playerName != "")
            {
                using (FiveOursContext db = new FiveOursContext())
                {
                    var result = new Result()
                    {
                        PlayerName = _playerName,
                        GameTime = _timerTime.Ticks,
                        MovesCount = _moves
                    };

                    db.Add(result);
                    db.SaveChanges();
                }
            }

            ResultsWindow cw = new ResultsWindow();
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();

            _isClosingByEndingGame = true;
            Close();
        }


        private void GameWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();
            if(!_isClosingByEndingGame)
            {
                Owner.Visibility = Visibility.Visible;
            }
        }

    }
}
