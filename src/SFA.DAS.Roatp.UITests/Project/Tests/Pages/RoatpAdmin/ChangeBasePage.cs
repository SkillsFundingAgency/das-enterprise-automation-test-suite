using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public abstract class ChangeBasePage : RoatpAdminBasePage
    {
        public ChangeBasePage(ScenarioContext context) : base(context) { }

        public ResultsFoundPage ClickBackLink()
        {
            Back();
            return new ResultsFoundPage(_context);
        }
    }
}
