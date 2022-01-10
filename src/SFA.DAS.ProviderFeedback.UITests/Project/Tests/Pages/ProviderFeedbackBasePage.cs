using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public abstract class ProviderFeedbackBasePage : VerifyBasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        protected By Labels => By.CssSelector(".multiple-choice label");

        protected ProviderFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            if (verifypage) VerifyPage();
        }

        protected void SelectOptionAndContinue()
        {
            List<string> checkboxList = pageInteractionHelper.FindElements(Labels).Select(x => x.Text).Where(y => !string.IsNullOrEmpty(y)).ToList();

            for (int i = 0; i <= 2; i++)
            {
                var randomoption = RandomDataGenerator.GetRandomElementFromListOfElements(checkboxList);
                formCompletionHelper.SelectCheckBoxByText(Labels, randomoption);
                checkboxList.Remove(randomoption);
            }

            Continue();
        }
    }
}