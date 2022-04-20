using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using SFA.DAS.TestDataExport;
using System.Linq;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Which employer is this vacancy for?";

        private By RadioItem(string value) => By.CssSelector($".govuk-radios__item input{value}");

        public SelectEmployersPage(ScenarioContext context) : base(context) { }

        public (CreateAnApprenticeshipAdvertOrVacancyPage, bool) SelectEmployer()
        {
            var employers = pageInteractionHelper.FindElements(RadioItem(string.Empty)).ToList().Select(x => x.GetAttribute("value")).ToList();

            var validemployers = context.Get<ProviderCreateVacancySqlDbHelper>().GetValidHashedId(employers);

            var hashedid = RandomDataGenerator.GetRandomElementFromListOfElements(validemployers);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(RadioItem($"[value='{hashedid[0]}']")));

            int noOfLegalEntity = (int)hashedid[1];

            objectContext.SetDebugInformation($"Selected employer with hashed id {hashedid} who has {noOfLegalEntity} legal entities");

            Continue();

            return (new CreateAnApprenticeshipAdvertOrVacancyPage(context), noOfLegalEntity > 1);
        }
    }
}
