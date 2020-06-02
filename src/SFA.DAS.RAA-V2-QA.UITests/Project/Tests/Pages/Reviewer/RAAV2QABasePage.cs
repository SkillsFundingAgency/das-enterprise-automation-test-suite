using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public abstract class RAAV2QABasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly ObjectContext objectContext;
        #endregion

        public RAAV2QABasePage(ScenarioContext context) : base(context) 
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage(); 
        }
        
    }
}
