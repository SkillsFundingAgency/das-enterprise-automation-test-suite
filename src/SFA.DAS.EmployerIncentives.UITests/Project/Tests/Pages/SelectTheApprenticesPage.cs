using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class SelectTheApprenticesPage : EIBasePage
    {
        protected override string PageTitle => "Which apprentices do you want to apply for?";

        private By Apprentices => CheckBoxLabels;

        public SelectTheApprenticesPage(ScenarioContext context) : base(context)  { }

        public WhenDidApprenticeJoinTheOrgPage SubmitApprentices()
        {
            foreach (var apprentice in pageInteractionHelper.FindElements(Apprentices))
                formCompletionHelper.ClickElement(apprentice);

            Continue();
            return new WhenDidApprenticeJoinTheOrgPage(context);
        }
    }
}
