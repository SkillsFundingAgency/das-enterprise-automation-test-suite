using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class CreateATransfersApplicationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Create a transfers application";

        protected override By ContinueButton => By.CssSelector("#opportunity-apply-submit");

        public CreateATransfersApplicationPage(ScenarioContext context) : base(context) { }

        public ApplicationSubmittedPage SubmitApplication()
        {
            Continue();
            return new ApplicationSubmittedPage(context);
        }

        public ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage()
        {
            formCompletionHelper.ClickLinkByText(GetRandomLink(AppTraining));
            return new ApprenticeshipTrainingPage(context);
        }

        public AddYourBusinessDetailsPage GoToYourBusinessDetailsPage()
        {
            formCompletionHelper.ClickLinkByText(GetRandomLink(BusinessDetails));
            return new AddYourBusinessDetailsPage(context);
        }

        public AboutYourApprenticeshipPage GoToAboutYourApprenticeshipPage()
        {
            formCompletionHelper.ClickLinkByText("More detail");
            return new AboutYourApprenticeshipPage(context);
        }

        public AddContactDetailsPage GoToContactDetailsPage()
        {
            formCompletionHelper.ClickLinkByText(GetRandomLink(ContactDetails));
            return new AddContactDetailsPage(context);
        }

        private string GetRandomLink(List<string> list) => RandomDataGenerator.GetRandomElementFromListOfElements(list);

        private List<string> AppTraining => new List<string>() { "Job role", "Number of apprentices", "Start by", "Have you found a training provider?" };

        private List<string> BusinessDetails => new List<string>() { "Sector", "Location" };

        private List<string> ContactDetails => new List<string>() { "Name", "Email address", "Business website" };
    }
}