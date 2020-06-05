using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WhatIsYourOrganisationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What is your organisation?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SaveAndContinue => By.XPath("//button[text()='Save and continue']");

        public WhatIsYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DescribeYourOrganisationPage SelectAnApprenticeshipTrainingAgencyAndContinue()
        {
            SelectRadioOptionByText("An Apprenticeship Training Agency");
            formCompletionHelper.ClickElement(SaveAndContinue);
            return new DescribeYourOrganisationPage(_context);
        }
        public TypeOfEducationalInstitutePage SelectEducationalInstituteAndContinue()
        { 
            SelectRadioOptionByText("An educational institute");
            formCompletionHelper.ClickElement(SaveAndContinue);
            return new TypeOfEducationalInstitutePage(_context);
        }
        public DescribeYourOrganisationPage SelectIndependentTrainingProviderAndContinue()
        {
            SelectRadioOptionByText("An Independent Training Provider");
            formCompletionHelper.ClickElement(SaveAndContinue);
            return new DescribeYourOrganisationPage(_context);
        }
        public TrainApprenticesPage SelectNoneOfTheAboveAndContinue()
        {
            SelectRadioOptionByText("None of the above");
            formCompletionHelper.ClickElement(SaveAndContinue);
            return new TrainApprenticesPage(_context);
        }
        public DescribeYourOrganisationPage SelectGroupTrainingAssociationAndContinue()
        {
            SelectRadioOptionByText("A Group Training Association");
            formCompletionHelper.ClickElement(SaveAndContinue);
            return new DescribeYourOrganisationPage(_context);
        }
        public TypeOfBodyPage SelectPublicBodyAndContinue()
        { 
            SelectRadioOptionByText("A public body");
            formCompletionHelper.ClickElement(SaveAndContinue);
            return new TypeOfBodyPage(_context);
        }
    }
}
