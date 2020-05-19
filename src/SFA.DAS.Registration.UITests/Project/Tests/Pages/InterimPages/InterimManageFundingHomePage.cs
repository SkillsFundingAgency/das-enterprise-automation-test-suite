using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimManageFundingHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your funding reservations";

        protected override string Linktext => "Your funding reservations";

        public InterimManageFundingHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        public InterimManageFundingHomePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, OpenYourFundingReservations(context, navigate), gotourl) { }

        private static Action OpenYourFundingReservations(ScenarioContext context, bool navigate)
        {
            if (navigate)
            {
                return () =>
                {
                    new HomePage(context, true);

                    var helper = context.Get<FormCompletionHelper>();

                    helper.ClickLinkByText("Your funding reservations");
                };
            }
            return null;
            
        }
    }
}

