using System;
using System.Threading;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class SearchEmployerNamePage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Who do you work for?";
        private static By FirstAddress => By.Id("SearchTerm__option--0");

        private static By PostCodeField => By.Id("SearchTerm");

        public EmployerDetailsPage EnterPostcodeAndContinue()
        {
            formCompletionHelper.EnterText(PostCodeField, aanDataHelpers.PostCode);
            //pageInteractionHelper.WaitForElementToBeDisplayed(FirstAddress);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            formCompletionHelper.Click(FirstAddress);
            Continue();
            return new EmployerDetailsPage(context);
        }

        public EmployerDetailsPage EnterAddressManually()
        {
            formCompletionHelper.ClickLinkByText("Enter address manually");
            return new EmployerDetailsPage(context);
        }

        public EditEmployerDetailsPage EnterAddressManuallyEdit()
        {
            formCompletionHelper.ClickLinkByText("Enter address manually");
            return new EditEmployerDetailsPage(context);
        }
    }
}