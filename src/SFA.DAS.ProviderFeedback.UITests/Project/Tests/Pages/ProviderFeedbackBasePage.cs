using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderFeedback.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public abstract class ProviderFeedbackBasePage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        protected By Labels => By.CssSelector(".multiple-choice label");

        #region Helpers and Context
        protected readonly RegexHelper regexHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly TabHelper tabHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly ProviderFeedbackConfig providerFeedbackConfig;
        protected readonly ProviderFeedbackDataHelper providerFeedbackDatahelper;
        #endregion

        protected ProviderFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            providerFeedbackConfig = context.GetProviderFeedbackConfig<ProviderFeedbackConfig>();
            regexHelper = context.Get<RegexHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            tabHelper = context.Get<TabHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            providerFeedbackDatahelper = context.GetValue<ProviderFeedbackDataHelper>();
            if (verifypage) VerifyPage();
        }

        protected void SelectOptionAndContinue()
        {
            List<string> checkboxList = pageInteractionHelper.FindElements(Labels).Select(x => x.Text).Where(y => !string.IsNullOrEmpty(y)).ToList();

            for (int i = 0; i <= 2; i++)
            {
                var randomoption = providerFeedbackDatahelper.GetRandomElementFromListOfElements(checkboxList);
                formCompletionHelper.SelectCheckBoxByText(Labels, randomoption);
                checkboxList.Remove(randomoption);
            }

            Continue();
        }
    }
}