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

        public WhatIsYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DescribeYourOrganisationPage SelectAnApprenticeshipTrainingAgencyAndContinue()
        {
            SelectRadioOptionByText("An Apprenticeship Training Agency");
           SaveAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
        public TypeOfEducationalInstitutePage SelectEducationalInstituteAndContinue()
        { 
            SelectRadioOptionByText("An educational institute");
           SaveAndContinue();
            return new TypeOfEducationalInstitutePage(_context);
        }
        public DescribeYourOrganisationPage SelectIndependentTrainingProviderAndContinue()
        {
            SelectRadioOptionByText("An Independent Training Provider");
           SaveAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
        public DescribeYourOrganisationPage SelectARailFranchiseOperatorAndContinue()
        {
            SelectRadioOptionByText("A rail franchise operator, licensed and acting on behalf of the Department for Transport");
           SaveAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
        public DescribeYourOrganisationPage SelectNoneOfTheAboveAndContinue()
        {
            SelectRadioOptionByText("None of the above");
           SaveAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
        public DescribeYourOrganisationPage SelectGroupTrainingAssociationAndContinue()
        {
            SelectRadioOptionByText("A Group Training Association");
           SaveAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
        public TypeOfBodyPage SelectPublicBodyAndContinue()
        { 
            SelectRadioOptionByText("A public body");
           SaveAndContinue();
            return new TypeOfBodyPage(_context);
        }
        public DescribeYourOrganisationPage SelectEmployerTrainingInOtherOrganisations()
        {
            SelectRadioOptionByText("An employer training apprentices in other organisations");
           SaveAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }

        private void SaveAndContinue() => formCompletionHelper.ClickButtonByText(ContinueButton, "Save and continue");
    }
}
