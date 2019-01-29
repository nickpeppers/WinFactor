using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WinFactor.Models;
using Xamarin.Forms;

namespace WinFactor.ViewModels
{
    public class AddIssuePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CloseCommand { get; set; }
        public ICommand AddIssueCommand { get; set; }

        public AddIssuePageViewModel()
        {
            CloseCommand = new Command<Page>(OnClose);
            AddIssueCommand = new Command(OnAddIssue);
        }

        string _issueName = "Issue";

        public string IssueName
        {
            get { return _issueName; }
            set
            {
                _issueName = value;
                OnPropertyChanged(nameof(IssueName));
            }
        }

        int _issueCost = 1;

        public int IssueCost
        {
            get { return _issueCost; }
            set
            {
                _issueCost = value;
                OnPropertyChanged(nameof(IssueCost));
            }
        }

        int _issueWinFactor = 1;

        public int IssueWinFactor
        {
            get { return _issueWinFactor; }
            set
            {
                _issueWinFactor = value;
                OnPropertyChanged(nameof(IssueWinFactor));
            }
        }

        bool _isRunning;

        async void OnClose(Page page)
        {
            try
            {
                if (_isRunning)
                    return;

                _isRunning = true;

                if (page.Navigation.ModalStack.Any())
                {
                    await page.Navigation.PopModalAsync();
                }
            }
            finally
            {
                _isRunning = false;
            }
        }

        void OnAddIssue()
        {
            var issue = new Issue(IssueName, IssueCost, IssueWinFactor);
            MessagingCenter.Send<Issue>(issue, DefaultData.NewIssueMessage);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}