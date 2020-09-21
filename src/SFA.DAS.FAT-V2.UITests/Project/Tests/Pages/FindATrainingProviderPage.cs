using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class FindATrainingProviderPage : FATV2BasePage
    {
        protected override string PageTitle => "Training providers for";
        private readonly ScenarioContext _context;

        public FindATrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        #region Locators

        #endregion

    }
}
