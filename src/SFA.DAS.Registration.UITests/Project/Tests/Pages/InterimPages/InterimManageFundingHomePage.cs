using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimManageFundingHomePage(ScenarioContext context, bool navigate, bool gotourl) : InterimEmployerBasePage(context, OpenYourFundingReservations(context, navigate), gotourl)
    {
        protected override string PageTitle => "Your funding reservations";

        protected override bool TakeFullScreenShot => false;

        protected override string Linktext => Link;

        private static string Link => "Your funding reservations";

        public InterimManageFundingHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        private static Action OpenYourFundingReservations(ScenarioContext context, bool navigate)
        {
            if (navigate)
            {
                return () =>
                {
                    _ = new HomePage(context, true);

                    var helper = context.Get<FormCompletionHelper>();

                    helper.ClickLinkByText(Link);
                };
            }
            return null;
        }
    }
}

