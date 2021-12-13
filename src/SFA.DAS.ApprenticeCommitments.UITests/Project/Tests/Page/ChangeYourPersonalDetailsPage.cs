using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ChangeYourPersonalDetailsPage : PersonalDetailsBasePage
    {
        protected override string PageTitle => $"Change your personal details";
        protected override By ContinueButton => By.CssSelector("#identity-assurance-btn");

        public ChangeYourPersonalDetailsPage(ScenarioContext context) : base(context)  { }

        public new ApprenticeHomePage UpdateApprenticeName()
        {
            base.UpdateApprenticeName();
            return new ApprenticeHomePage(_context, false);
        }

        public new ApprenticeHomePage EnterValidApprenticeDetails(string firstName, string lastName)
        {
            base.EnterValidApprenticeDetails(firstName, lastName);
            return new ApprenticeHomePage(_context);
        }
    }
}
