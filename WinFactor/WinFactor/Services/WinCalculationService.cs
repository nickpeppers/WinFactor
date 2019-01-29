using System.Collections.Generic;
using System.Linq;
using WinFactor.Models;
using WinFactor.Services.Interfaces;

namespace WinFactor.Services
{
    public class WinCalculationService : IWinCalculationService
    {
        public int LastWinTotal { get; set; }
        public int LastCostTotal { get; set; }

        public IEnumerable<Issue> CalculateOptimalIssuesList(IEnumerable<Issue> issues, int totalCost = 11)
        {
            LastWinTotal =
                LastCostTotal = 0;

            var issuesToFix = new List<Issue>();
            var sortedIssues = issues.OrderByDescending(i => i.Weight).ToList();

            int currentCostTotal = 0;
            foreach (var issue in sortedIssues)
            {
                currentCostTotal += issue.Cost;
                if (currentCostTotal <= totalCost)
                {
                    LastCostTotal += issue.Cost;
                    LastWinTotal += issue.WinFactor;

                    issuesToFix.Add(issue);
                }
                else
                {
                    currentCostTotal -= issue.Cost;
                }

                if (currentCostTotal == totalCost)
                {
                    return issuesToFix;
                }
            }

            return issuesToFix;
        }
    }
}