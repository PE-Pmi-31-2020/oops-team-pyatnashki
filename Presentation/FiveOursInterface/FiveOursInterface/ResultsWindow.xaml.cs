using System.ComponentModel;
using System.Windows;

namespace FiveOursInterface
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        public ResultsWindow()
        {
            InitializeComponent();
        }

        private void ResultsWindowClosing(object sender, CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }
    }
}
