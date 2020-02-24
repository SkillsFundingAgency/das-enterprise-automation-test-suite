using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ReserveFundingToTrainAnApprenticePage : BasePage
    {
        protected override string PageTitle => "Reserve funding to train and assess an apprentice";

        public ReserveFundingToTrainAnApprenticePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
