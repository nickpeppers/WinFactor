using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WinFactor.Models;
using WinFactor.Services;
using WinFactor.Services.Interfaces;
using Xamarin.Forms;

namespace WinFactor.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        readonly IWinCalculationService _winCalculationService = ServiceContainer.Resolve<IWinCalculationService>();

        public ICommand CalculateWinFactorCommand { get; set; }

        public MainPageViewModel()
        {
            CalculateWinFactorCommand = new Command(OnCalculateWinFactor);
        }

        ObservableCollection<Issue> _issues = DefaultData.SampleIssues1;

        public ObservableCollection<Issue> Issues
        {
            get { return _issues; }
            set
            {
                _issues = value;
                OnPropertyChanged(nameof(Issues));
            }
        }

        int _issuesWinTotal = 0;

        public int IssuesWinTotal
        {
            get { return _issuesWinTotal; }
            set
            {
                _issuesWinTotal = value;
                OnPropertyChanged(nameof(IssuesWinTotal));
            }
        }

        int _issuesCostTotal = 0;

        public int IssuesCostTotal
        {
            get { return _issuesCostTotal; }
            set
            {
                _issuesCostTotal = value;
                OnPropertyChanged(nameof(IssuesCostTotal));
            }
        }

        bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        async void OnCalculateWinFactor ()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                await Task.Run(() =>
                {
                    var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(Issues);
                    Issues = new ObservableCollection<Issue>(issuesToFix);
                    IssuesCostTotal = _winCalculationService.LastCostTotal;
                    IssuesWinTotal = _winCalculationService.LastWinTotal;
                });
            }
            catch(Exception exc)
            {
                Console.WriteLine("OnCalculateWinFactor Error: " + exc);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}