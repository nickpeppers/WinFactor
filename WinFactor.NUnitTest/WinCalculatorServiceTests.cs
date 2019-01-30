using NUnit.Framework;
using System.Linq;
using WinFactor.Models;
using WinFactor.Services;
using WinFactor.Services.Interfaces;

namespace Tests
{
    public class WinCalculatorServiceTests
    {
        IWinCalculationService _winCalculationService;

        [SetUp]
        public void Setup()
        {
            _winCalculationService = new WinCalculationService();
        }

        [Test]
        public void Sample1Test()
        {
            var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(DefaultData.SampleIssues1);

            Assert.AreEqual(3, issuesToFix.Count());
            Assert.AreEqual(10, _winCalculationService.LastCostTotal);
            Assert.AreEqual(19, _winCalculationService.LastWinTotal);
        }

        [Test]
        public void Sample2Test()
        {
            var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(DefaultData.SampleIssues2, 20);

            Assert.AreEqual(6, issuesToFix.Count());
            Assert.AreEqual(20, _winCalculationService.LastCostTotal);
            Assert.AreEqual(33, _winCalculationService.LastWinTotal);
        }

        [Test]
        public void Sample3Test()
        {
            var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(DefaultData.SampleIssues3, 50);

            var issue19 = issuesToFix.Where(i => i.Name == "Issue 19").FirstOrDefault();
            Assert.IsNull(issue19);

            Assert.AreEqual(9, issuesToFix.Count());
            Assert.AreEqual(50, _winCalculationService.LastCostTotal);
            Assert.AreEqual(98, _winCalculationService.LastWinTotal);
        }

        [Test]
        public void Sample4Test()
        {
            var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(DefaultData.SampleIssues4);

            Assert.AreEqual(3, issuesToFix.Count());
            Assert.AreEqual(9, _winCalculationService.LastCostTotal);
            Assert.AreEqual(8, _winCalculationService.LastWinTotal);
        }

        [Test]
        public void Sample5Test()
        {
            var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(DefaultData.SampleIssues5);

            Assert.AreEqual(3, issuesToFix.Count());
            Assert.AreEqual(10, _winCalculationService.LastCostTotal);
            Assert.AreEqual(19, _winCalculationService.LastWinTotal);
        }

        [Test]
        public void Sample6Test()
        {
            var issuesToFix = _winCalculationService.CalculateOptimalIssuesList(DefaultData.SampleIssues6);

            Assert.AreEqual(5, issuesToFix.Count());
            Assert.AreEqual(10, _winCalculationService.LastCostTotal);
            Assert.AreEqual(8, _winCalculationService.LastWinTotal);
        }
    }
}