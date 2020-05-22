using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReportYourProgressPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Reporting your progress towards the public sector apprenticeship target";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Question Links
        private static string OrganisationName => "Your organisation's name";

        private static string Employees => "Number of employees who work in England";
        private static string Apprentices => "Number of apprentices who work in England";
        private static string FullTime => "Number of full-time equivalents who work in England(optional)";


        private static string Actions => "What actions have you taken this year to meet the target? How do these compare to the actions taken in the previous year?";
        private static string Challenges => "What challenges have you faced this year in your efforts to meet the target? How do these compare to the challenges experienced in the previous year?";
        private static string Planning => "How are you planning to meet the target in future? What will you continue to do or do differently?";
        private static string AnythingElse => "Do you have anything else you want to tell us? (optional)";

        private static string Review => "Review and submit answers";
        #endregion


        public ReportYourProgressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourOrganisationNamePage GoToYourOrganisationNamePage()
        {
            formCompletionHelper.ClickLinkByText(OrganisationName);
            return new YourOrganisationNamePage(_context);
        }

        public YourEmployeesPage GoToYourEmployeesPage()
        {
            formCompletionHelper.ClickLinkByText(Employees);
            return new YourEmployeesPage(_context);
        }
        public YourApprenticesPage GoToYourApprenticesPage()
        {
            formCompletionHelper.ClickLinkByText(Apprentices);
            return new YourApprenticesPage(_context);
        }
        public YourFullTimeEquivalentsPage GoToYourFullTimeEquivalentsPage()
        {
            formCompletionHelper.ClickLinkByText(FullTime);
            return new YourFullTimeEquivalentsPage(_context);
        }
        public WhatActionsHaveYouTakenPage GoToWhatActionsHaveYouTakenPage()
        {
            formCompletionHelper.ClickLinkByText(Actions);
            return new WhatActionsHaveYouTakenPage(_context);
        }
        public WhatChallengesHaveYouFacedPage GoToWhatChallengesHaveYouFacedPage()
        {
            formCompletionHelper.ClickLinkByText(Challenges);
            return new WhatChallengesHaveYouFacedPage(_context);
        }
        public HowAreYouPlanningToMeetTheTargetPage GoToHowAreYouPlanningToMeetTheTargetPage()
        {
            formCompletionHelper.ClickLinkByText(Planning);
            return new HowAreYouPlanningToMeetTheTargetPage(_context);
        }
        public DoYouHaveAnythingToTellUsPage GoToDoYouHaveAnythingToTellUsPage()
        {
            formCompletionHelper.ClickLinkByText(AnythingElse);
            return new DoYouHaveAnythingToTellUsPage(_context);
        }
        public ReviewDetailsPage GoToReviewPage()
        {
            formCompletionHelper.ClickLinkByText(Review);
            return new ReviewDetailsPage(_context);
        }
    }
}