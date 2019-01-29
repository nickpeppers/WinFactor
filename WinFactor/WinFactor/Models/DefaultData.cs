using System.Collections.ObjectModel;

namespace WinFactor.Models
{
    public static class DefaultData
    {
        public static string NewIssueMessage = "NewIssueMessage";

        public static ObservableCollection<Issue> SampleIssues1 = new ObservableCollection<Issue>
        {
            new Issue("Issue 1", 1, 2),
            new Issue("Issue 2", 3, 3),
            new Issue("Issue 3", 3, 3),
            new Issue("Issue 4", 4, 7),
            new Issue("Issue 5", 5, 10)
        };

        public static ObservableCollection<Issue> SampleIssues2 = new ObservableCollection<Issue>
        {
            new Issue("Issue 1", 1, 2),
            new Issue("Issue 2", 3, 3),
            new Issue("Issue 3", 3, 3),
            new Issue("Issue 4", 4, 7),
            new Issue("Issue 5", 5, 10),
            new Issue("Issue 6", 2, 1),
            new Issue("Issue 7", 3, 4),
            new Issue("Issue 8", 6, 3),
            new Issue("Issue 9", 4, 7),
            new Issue("Issue 10", 7, 10)
        };

        public static ObservableCollection<Issue> SampleIssues3 = new ObservableCollection<Issue>
        {
            new Issue("Issue 1", 1, 2),
            new Issue("Issue 2", 3, 3),
            new Issue("Issue 3", 3, 3),
            new Issue("Issue 4", 4, 7),
            new Issue("Issue 5", 5, 10),
            new Issue("Issue 6", 2, 1),
            new Issue("Issue 7", 3, 4),
            new Issue("Issue 8", 6, 3),
            new Issue("Issue 9", 4, 7),
            new Issue("Issue 10", 7, 10),
            new Issue("Issue 11", 2, 1),
            new Issue("Issue 12", 14, 28),
            new Issue("Issue 13", 4, 10),
            new Issue("Issue 14", 4, 12),
            new Issue("Issue 15", 11, 18),
            new Issue("Issue 16", 12, 1),
            new Issue("Issue 17", 13, 4),
            new Issue("Issue 18", 6, 5),
            new Issue("Issue 19", 54, 1000),
            new Issue("Issue 20", 3, 4)
        };
    }
}