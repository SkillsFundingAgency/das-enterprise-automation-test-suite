using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships
{
    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected override string PageTitle => "name or reference number (UKPRN)";

        private static By UKProviderReferenceNumberText => By.CssSelector("input[id='SearchTerm']");

        private static By AutoCompleteMenu => By.CssSelector("[id='SearchTerm__listbox']");

        private static By AutoCompleteOptions => By.CssSelector(".autocomplete__option");

        private static By FirstOption => By.CssSelector("[id='SearchTerm__option--0']");

        public AddPermissionsForTrainingProviderPage SearchForATrainingProvider(ProviderConfig providerConfig)
        {
            EnterATrainingProvider(providerConfig);

            return new AddPermissionsForTrainingProviderPage(context, providerConfig);
        }

        public AlreadyLinkedToTrainingProviderPage SearchForAnExistingTrainingProvider(ProviderConfig providerConfig)
        {
            EnterATrainingProvider(providerConfig);

            return new AlreadyLinkedToTrainingProviderPage(context);
        }

        private void EnterATrainingProvider(ProviderConfig providerConfig)
        {
            formCompletionHelper.EnterText(UKProviderReferenceNumberText, providerConfig.Ukprn);

            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                pageInteractionHelper.WaitForElementToChange(AutoCompleteMenu, "class", "autocomplete__menu--visible");

                pageInteractionHelper.WaitForElementToChange(FirstOption, AttributeHelper.InnerText, providerConfig.Ukprn);

                if (!pageInteractionHelper.IsElementDisplayed(FirstOption) && !pageInteractionHelper.GetStringCollectionFromElementsGroup(AutoCompleteOptions).ToList().Any(x => x.ContainsCompareCaseInsensitive(providerConfig.Ukprn)))
                {
                    Assert.Fail($"Auto complete menu for list of providers does not pop up provider : {providerConfig.Name}, {providerConfig.Ukprn}");
                }

                pageInteractionHelper.FocusTheElement(FirstOption);

            }, RetryTimeOut.GetTimeSpan([10, 10, 10]));

            javaScriptHelper.ClickElement(FirstOption);

            Continue();
        }
    }
}
