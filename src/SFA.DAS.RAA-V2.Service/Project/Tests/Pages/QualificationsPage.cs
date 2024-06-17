using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class QualificationsPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Qualifications";

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public AddAQualificationPage SelectYesToAddQualification()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            Continue();
            return new AddAQualificationPage(context);
        }
    }
}
