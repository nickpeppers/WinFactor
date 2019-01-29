using System.Collections.ObjectModel;

namespace WinFactor.Models
{
    public static class DefaultData
    {
        public static ObservableCollection<Issue> SampleIssues1 = new ObservableCollection<Issue>
        {
            new Issue{Name = "Issue 1", Cost = 1, WinFactor = 2},
            new Issue{Name = "Issue 2", Cost = 3, WinFactor = 3},
            new Issue{Name = "Issue 3", Cost = 3, WinFactor = 3},
            new Issue{Name = "Issue 4", Cost = 4, WinFactor = 7},
            new Issue{Name = "Issue 5", Cost = 5, WinFactor = 10},
        };
    }
}