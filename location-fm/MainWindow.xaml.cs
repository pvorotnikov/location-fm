using LinqToTwitter;
using location_fm.ViewModels;
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

namespace location_fm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new TweetViewModel();
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (SharedState.Authorizer == null)
            {
                new OAuth().Show();
            }
        }

        private void refreshTweetsBtn_Click(object sender, RoutedEventArgs e)
        {
            refreshTweets();
        }

        // refresh the tweets
        async void refreshTweets()
        {
            var twitterCtx = new TwitterContext(SharedState.Authorizer);

            var tweets =
                await
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.Home
                 select new Tweet
                 {
                     ImageSource = tweet.User.ProfileImageUrl,
                     UserName = tweet.User.ScreenNameResponse,
                     Message = tweet.Text
                 })
                .ToListAsync();

            var tweetCollection = (DataContext as TweetViewModel).Tweets;
            tweetCollection.Clear();
            tweets.ForEach(tweet => tweetCollection.Add(tweet));
        }
    }
}
