using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancyApplicationPage : RAAV1BasePage
    {
        protected override string PageTitle => "Vacancy application";

        private By HeadingSecondary => By.CssSelector(".heading-secondary");

        public RAA_VacancyApplicationPage(ScenarioContext context) : base(context) => VerifyPage(HeadingSecondary, context.Get<VacancyTitleDatahelper>().VacancyTitle);
    }
}
