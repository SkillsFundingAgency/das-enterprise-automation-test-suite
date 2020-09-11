using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public class ModerationApplicationsPage : ModeratorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";
        private readonly ScenarioContext _context;

        public By AssignToMeLinkForMainProvider => By.XPath("//td[contains(text(),'7TAO ENGINEERING UK LIMITED')]//following-sibling::td//a");
        public By AssignToMeLinkForSupportingProvider => By.XPath("//td[contains(text(),'ARTHUR MUREVERWI')]//following-sibling::td//a");
        public By AssignToMeLinkForEmployerProvider => By.XPath("//td[contains(text(),'SHOCKOUT ACADEMY')]//following-sibling::td//a");
        public By ModerationLink => By.LinkText("/Dashboard/InModeration");

        public ModerationApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        //public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMeForMainProvider()
        //{
        //    formCompletionHelper.ClickElement(ModerationLink);
        //    formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
        //    return new ModerationApplicationAssessmentOverviewPage(_context);
        //}

        //public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMeForSupportingProvider()
        //{
        //    formCompletionHelper.ClickElement(ModerationLink);
        //    formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
        //    return new ModerationApplicationAssessmentOverviewPage(_context);
        //}

        //public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMeForEmployerProvider()
        //{
        //    formCompletionHelper.ClickElement(ModerationLink);
        //    formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
        //    return new ModerationApplicationAssessmentOverviewPage(_context);
        //}
    }
}
