using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Which employer is this vacancy for?";

        private By RadioItems => By.CssSelector(".govuk-radios__item");

        public SelectEmployersPage(ScenarioContext context) : base(context) { }

        public VacancyTitlePage SelectEmployer(string empName)
        {
            if (string.IsNullOrEmpty(empName))
                formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioLabels)));
            else
                SelectRadioOptionByText(empName);

            Continue();

            return new VacancyTitlePage(context);
        }

        public (CreateAnApprenticeshipAdvertOrVacancyPage, bool) SelectEmployer_Provider()
        {
            int noOfLegalEntity = default;

            formCompletionHelper.ClickElement(() =>
            {
                var element = RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioItems));
                
                var hashedid = element.FindElement(By.CssSelector("input")).GetAttribute("value");

                noOfLegalEntity = context.Get<ProviderCreateVacancySqlDbHelper>().GetNoOfLegalEntity(hashedid);

                return element.FindElement(RadioLabels);
            });

            Continue();

            return (new CreateAnApprenticeshipAdvertOrVacancyPage(context), noOfLegalEntity > 1);
        }
    }
}
