using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimPublicSectorReportingHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Annual apprenticeship return";

        protected override string Linktext => Link;

        private static string Link => "Report public sector apprenticeship target";

        public InterimPublicSectorReportingHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        public InterimPublicSectorReportingHomePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, OpenPublicSectorReporting(context, navigate), gotourl) { }

        private static Action OpenPublicSectorReporting(ScenarioContext context, bool navigate)
        {
            if (navigate)
            {
                return () =>
                {
                    new InterimApprenticesHomePage(context, true);

                    var helper = context.Get<FormCompletionHelper>();

                    helper.ClickLinkByText(Link);
                };
            }
            return null;
        }
    }
}

