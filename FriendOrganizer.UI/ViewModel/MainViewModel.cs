using System.Collections.ObjectModel;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Friend> Friends { get; set; }

        public Friend SelectedFriend
        {
            get => _selectedFriend;
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }

        private IFriendDataService friendDataService;
        private Friend _selectedFriend;

        public void Load()
        {
            var friends = friendDataService.GetAllFriends();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        public MainViewModel(IFriendDataService friendDataService)
        {
            this.friendDataService = friendDataService;
            Friends = new ObservableCollection<Friend>();
        }
    }
}
