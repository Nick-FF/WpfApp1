using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlLocalDbContext Context;
        public List<Track> TracksList;
        public MainWindow()
        {
            InitializeComponent();
            Context = new SqlLocalDbContext();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(ArtistNameText.Text)) && (!string.IsNullOrWhiteSpace(TrackNameText.Text)))
            {
                AddNewTrack();
                ReloadTracks();
            }

        }

        private void AddNewTrack()
        {
            Context.Tracks.Add(
                new Track
                {
                    ArtistName = ArtistNameText.Text,
                    TrackName = TrackNameText.Text
                });
            Context.SaveChanges();
        }

        private void MW_OnLoaded (object sender, RoutedEventArgs e)
        {
            ReloadTracks();
        }

        private void ReloadTracks()
        {
            TracksList = Context.Tracks.ToList();
            Grid.ItemsSource = TracksList;
        }
    }
}
