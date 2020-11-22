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

namespace FiveOursInterface
{

    public class GameButton: Button
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

        private Dictionary<int, GameButton> _buttons = new Dictionary<int, GameButton>(16);

        public  GameWindow()
        {
            InitializeComponent();
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
                counterLabel.Content = Convert.ToInt32(counterLabel.Content) + 1;
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
                return;
            }                

            MessageBox.Show("Completed Successfully!");

            ResultsWindow cw = new ResultsWindow();
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
            this.Close();
        }


        private void Random()
        {

            var r = new Random();
            var a = new List<int>(16);
            var v = new List<int>(_buttons.Keys);

            int k = 0, n = 0;
            for (var x = 2; x < 6; x++)
            {
                for (var y = 1; y < 5; y++)
                {
                    do
                    {
                        k = r.Next(0, v.Count);
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
    }
}
