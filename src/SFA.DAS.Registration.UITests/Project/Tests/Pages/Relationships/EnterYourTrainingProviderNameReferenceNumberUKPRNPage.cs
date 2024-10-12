using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships
{
    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {

        public class TrainingProviderListPopulated : CheckPageUsingLongerTimeOut
        {
            protected override By Identifier => FirstOption;

            public TrainingProviderListPopulated(ScenarioContext context) : base(context) => checkPageInteractionHelper.UpdateTimeSpans(RetryTimeOut.GetTimeSpan([5, 5, 5]));

            public bool IsPageDisplayed(ProviderConfig providerConfig, Action retryAction) { checkPageInteractionHelper.WaitForElementToChange(FirstOption, AttributeHelper.InnerText, providerConfig.Ukprn, retryAction); return true; }
        }

        protected override string PageTitle => "name or reference number (UKPRN)";

        private static By UKProviderReferenceNumberText => By.CssSelector("input[id='SearchTerm']");

        private static By AutoCompleteMenu => By.CssSelector("[id='SearchTerm__listbox']");

        private static By AutoCompleteOptions => By.CssSelector(".autocomplete__option");

        private static By NthOption(int i) => By.CssSelector($"[id='SearchTerm__option--{i}']");

        private static By FirstOption => NthOption(0);

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
            string search = providerConfig.Ukprn;

            string a = string.Empty;

            foreach (var i in search)
            {
                a = $"{i}";

                formCompletionHelper.SendKeys(UKProviderReferenceNumberText, a);
            }

            int optionIndex = 0;

            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                pageInteractionHelper.WaitForElementToChange(AutoCompleteMenu, "class", "autocomplete__menu--visible");

                new TrainingProviderListPopulated(context).IsPageDisplayed(providerConfig, () => formCompletionHelper.SendKeys(UKProviderReferenceNumberText, $"{Keys.Backspace}{a}"));

                var isAutoCompleteDisplayed = pageInteractionHelper.IsElementDisplayed(FirstOption);

                var autoCompleteList = pageInteractionHelper.GetStringCollectionFromElementsGroup(AutoCompleteOptions).ToList();

                if (!isAutoCompleteDisplayed && !autoCompleteList.Any(x => x.ContainsCompareCaseInsensitive(search)))
                {
                    Assert.Fail($"Auto complete menu for list of providers does not pop up provider : {providerConfig.Name}, {providerConfig.Ukprn}");
                }

                var elementText = autoCompleteList.Find(x => x.ContainsCompareCaseInsensitive(search));

                optionIndex = autoCompleteList.IndexOf(elementText);

            }, RetryTimeOut.GetTimeSpan([10, 10, 10]));

            javaScriptHelper.ClickElement(NthOption(optionIndex));

            Continue();
        }
    }
}
