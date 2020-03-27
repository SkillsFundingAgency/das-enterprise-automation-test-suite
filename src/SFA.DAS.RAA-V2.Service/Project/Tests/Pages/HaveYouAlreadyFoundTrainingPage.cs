using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class HaveYouAlreadyFoundTrainingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Have you already found apprenticeship training?";

        #region Helpers And Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By YesRadioButton => By.Id("has_training_yes");

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");


        public HaveYouAlreadyFoundTrainingPage(ScenarioContext context):base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ApprenticeshipTrainingPage SelectYes()
        {
            _formCompletionHelper.SelectRadioOptionByLocator(YesRadioButton);
            Continue();
            return new ApprenticeshipTrainingPage(_context);
        }
    }
}
