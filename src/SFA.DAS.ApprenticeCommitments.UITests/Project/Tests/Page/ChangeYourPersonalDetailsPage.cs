using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
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
            return new ApprenticeHomePage(context, false);
        }

        public new ApprenticeHomePage EnterValidApprenticeDetails(string firstName, string lastName)
        {
            base.EnterValidApprenticeDetails(firstName, lastName);
            objectContext.SetFirstName(firstName);
            objectContext.SetFirstName(lastName);
            return new ApprenticeHomePage(context);
        }
    }
}
