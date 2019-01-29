using System.Collections.Generic;
using WinFactor.Models;

namespace WinFactor.Services.Interfaces
{
    public interface IWinCalculationService
    {
        int LastCostTotal { get; set; }
        int LastWinTotal { get; set; }

        IEnumerable<Issue> CalculateOptimalIssuesList(IEnumerable<Issue> issues, int totalCost = 11);
    }
}