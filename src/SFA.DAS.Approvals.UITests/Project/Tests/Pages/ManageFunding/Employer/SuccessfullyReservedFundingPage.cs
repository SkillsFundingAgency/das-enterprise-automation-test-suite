using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class SuccessfullyReservedFundingPage(ScenarioContext context) : ReservationIdBasePage(context)
    {
        protected override string PageTitle => "You have reserved funding for training";
        private static By GoToHomePageLink => By.XPath("//a[contains(text(),'Go to homepage')]");
        private static By AddLearnerLink => By.XPath("//a[contains(text(),'Add learner')]");

        public DynamicHomePages GoToDynamicHomePage()
        {
            formCompletionHelper.ClickElement(GoToHomePageLink);
            return new DynamicHomePages(context);
        }

        internal AddOrSendLearnerRequestPage AddLearner()
        {
            formCompletionHelper.ClickElement(AddLearnerLink);
            return new AddOrSendLearnerRequestPage(context);
        }


        internal SuccessfullyReservedFundingPage SaveReservationId(bool isSecondReservation = false)
        {
            SetCurrentReservationId(isSecondReservation);
            return new SuccessfullyReservedFundingPage(context);
        }
    }
}