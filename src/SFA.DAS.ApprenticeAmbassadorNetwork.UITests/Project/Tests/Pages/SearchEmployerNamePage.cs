using System;
using System.Threading;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class SearchEmployerNamePage : AanBasePage
    {
        protected override string PageTitle => "Search for your employer's name or address";
        private static By FirstAddress => By.Id("SearchTerm__option--0");

        private static By PostCodeField = By.Id("SearchTerm");

        public SearchEmployerNamePage(ScenarioContext context) : base(context) { }

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
    }
}



