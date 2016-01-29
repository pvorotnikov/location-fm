using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace location_fm.ViewModels
{
    class TweetViewModel
    {
        public TweetViewModel()
        {
            Tweets = new ObservableCollection<Tweet>();
        }

        public ObservableCollection<Tweet> Tweets { get; set; }
    }
}
