using ResultsDbContext;
using ResultsDbContext.Models;
using System;
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

            FillListView();
        }

        private void FillListView()
        {
            using (FiveOursContext db = new FiveOursContext())
            {
                var results = db.Results;

                foreach(var result in results)
                {
                    var convertedResult = new
                    {
                        Id = result.ResultID,
                        Name = result.PlayerName,
                        Time = TimeSpan.FromTicks(result.GameTime),
                        Moves = result.MovesCount
                    };

                    listViewResults.Items.Add(convertedResult);
                }
            }
        }

        private void ResultsWindowClosing(object sender, CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }
    }
}

