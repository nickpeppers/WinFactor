using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WinFactor.Models;
using WinFactor.Pages;
using WinFactor.Services;
using WinFactor.Services.Interfaces;
using Xamarin.Forms;

namespace WinFactor.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        readonly IWinCalculationService _winCalculationService = ServiceContainer.Resolve<IWinCalculationService>();

        public ICommand CalculateWinFactorCommand { get; set; }
        public ICommand AddIssueCommand { get; set; }

        public MainPageViewModel()
        {
            CalculateWinFactorCommand = new Command(OnCalculateWinFactor);
            AddIssueCommand = new Command<Page>(OnAddIssue);

            MessagingCenter.Subscribe<Issue>(this, DefaultData.NewIssueMessage, (issue) =>
            {
                Issues.Add(issue);
            });
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

        int _totalCost = 11;

        public int TotalCost
        {
            get { return _totalCost; }
            set
            {
                _totalCost = value;
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        async void OnCalculateWinFactor()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                await Task.Run(() =>
                {
                    var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(Issues, TotalCost);
                    Issues = new ObservableCollection<Issue>(issuesToFix);
                    IssuesCostTotal = _winCalculationService.LastCostTotal;
                    IssuesWinTotal = _winCalculationService.LastWinTotal;
                });
            }
            catch (Exception exc)
            {
                Console.WriteLine("OnCalculateWinFactor Error: " + exc);
            }
            finally
            {
                IsBusy = false;
            }
        }

        bool _isNavigating;

        async void OnAddIssue(Page page)
        {
            try
            {
                if (_isNavigating)
                    return;

                _isNavigating = true;

                await page.Navigation.PushModalAsync(new NavigationPage(new AddIssuePage()));
            }
            finally
            {
                _isNavigating = false;
            }
        }
    }
}