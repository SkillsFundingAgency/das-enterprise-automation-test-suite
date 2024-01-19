using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimPublicSectorReportingHomePage(ScenarioContext context, bool navigate) : InterimEmployerBasePage(context, OpenPublicSectorReporting(context, navigate), false)
    {
        protected override string PageTitle => "Annual apprenticeship return";

        protected override string Linktext => Link;

        private static string Link => "Report public sector apprenticeship target";

        private static Action OpenPublicSectorReporting(ScenarioContext context, bool navigate)
        {
            if (navigate)
            {
                return () =>
                {
                    _ = new InterimApprenticesHomePage(context, false);

                    var helper = context.Get<FormCompletionHelper>();

                    helper.ClickLinkByText(Link);
                };
            }
            return null;
        }
    }
}

