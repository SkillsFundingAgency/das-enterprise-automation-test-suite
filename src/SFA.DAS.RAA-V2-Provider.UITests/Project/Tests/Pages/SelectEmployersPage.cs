using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using SFA.DAS.TestDataExport;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Which employer is this vacancy for?";

        private By RadioItems => By.CssSelector(".govuk-radios__item");

        public SelectEmployersPage(ScenarioContext context) : base(context) { }

        public (CreateAnApprenticeshipAdvertOrVacancyPage, bool) SelectEmployer()
        {
            int noOfLegalEntity = default;

            string hashedid = string.Empty;

            formCompletionHelper.ClickElement(() =>
            {
                var element = RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioItems));
                
                hashedid = element.FindElement(By.CssSelector("input")).GetAttribute("value");

                noOfLegalEntity = context.Get<ProviderCreateVacancySqlDbHelper>().GetNoOfLegalEntity(hashedid);

                return element.FindElement(RadioLabels);
            });

            objectContext.SetDebugInformation($"Selected employer with hashed id {hashedid} who has {noOfLegalEntity} legal entities");

            Continue();

            return (new CreateAnApprenticeshipAdvertOrVacancyPage(context), noOfLegalEntity > 1);
        }
    }
}
