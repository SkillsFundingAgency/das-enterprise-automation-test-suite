using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public  class ProviderSelectAStandardPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Select a standard";
        private By AddStandardsDDL => By.Id("SelectedLarsCode");
        private By FirstItemInTheList => By.Id("SelectedLarsCode__option--0");

        public ProviderSelectAStandardPage(ScenarioContext context) : base(context) { }

        public ProviderAddStandardGenericPage AddStandard()
        {
            formCompletionHelper.Click(AddStandardsDDL);
            formCompletionHelper.Click(FirstItemInTheList);
            Continue();
            return new ProviderAddStandardGenericPage(context);
        }



 
    }
}
