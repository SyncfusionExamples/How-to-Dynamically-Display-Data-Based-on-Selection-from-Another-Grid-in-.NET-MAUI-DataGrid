using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class PasswordViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PasswordGroup> _groups;
        private ObservableCollection<Password> _allPasswords;
        private ObservableCollection<Password> _filteredPasswords;
        private bool _pwVisible = true;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<PasswordGroup> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }

        public ObservableCollection<Password> AllPasswords
        {
            get { return _allPasswords; }
            set
            {
                _allPasswords = value;
                OnPropertyChanged(nameof(AllPasswords));
            }
        }

        public ObservableCollection<Password> FilteredPasswords
        {
            get { return _filteredPasswords; }
            set
            {
                _filteredPasswords = value;
                OnPropertyChanged(nameof(FilteredPasswords));
            }
        }

        public bool PwVisible
        {
            get { return _pwVisible; }
            set
            {
                if (_pwVisible != value)
                {
                    _pwVisible = value;
                    OnPropertyChanged(nameof(PwVisible));
                }
            }
        }

        public PasswordViewModel()
        {
            _groups = new ObservableCollection<PasswordGroup>();
            _allPasswords = new ObservableCollection<Password>();
            _filteredPasswords = new ObservableCollection<Password>();

            GenerateSampleData();
        }

        public void UpdatePasswordsBasedOnSelectedGroups()
        {
            FilteredPasswords.Clear();

            var selectedGroupIds = Groups.Where(g => g.IsSelected).Select(g => g.Id).ToList();

            foreach (var password in AllPasswords)
            {
                if (selectedGroupIds.Contains(password.GroupId))
                {
                    FilteredPasswords.Add(password);
                }
            }
        }

        private void GenerateSampleData()
        {
            Groups.Add(new PasswordGroup(1, "Personal"));
            Groups.Add(new PasswordGroup(2, "Work"));
            Groups.Add(new PasswordGroup(3, "Social"));

            // Add exactly 5 passwords to Group 1 (Personal)
            AllPasswords.Add(new Password(1, "Gmail", "user1@gmail.com", "pass123", 1));
            AllPasswords.Add(new Password(2, "Yahoo", "user1@yahoo.com", "yahoo123", 1));
            AllPasswords.Add(new Password(3, "Bank", "bankuser", "secure123", 1));
            AllPasswords.Add(new Password(4, "Netflix", "netflixuser", "movies123", 1));
            AllPasswords.Add(new Password(5, "Amazon", "amazonuser", "shop123", 1));

            // Add 3 passwords to Group 2 (Work)
            AllPasswords.Add(new Password(6, "Work Email", "work@company.com", "work123", 2));
            AllPasswords.Add(new Password(7, "VPN", "vpnuser", "vpn123", 2));
            AllPasswords.Add(new Password(8, "Slack", "slack@company.com", "slack123", 2));

            // Add 4 passwords to Group 3 (Social)
            AllPasswords.Add(new Password(9, "Facebook", "fb@email.com", "social123", 3));
            AllPasswords.Add(new Password(10, "Twitter", "twitter@email.com", "tweet123", 3));
            AllPasswords.Add(new Password(11, "Instagram", "insta@email.com", "pic123", 3));
            AllPasswords.Add(new Password(12, "LinkedIn", "linkedin@email.com", "work123", 3));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
