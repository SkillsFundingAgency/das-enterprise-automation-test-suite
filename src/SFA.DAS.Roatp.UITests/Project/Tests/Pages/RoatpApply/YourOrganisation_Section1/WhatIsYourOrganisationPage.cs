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
            Continue();
            return new DescribeYourOrganisationPage(_context);
        }
        public TypeOfEducationalInstitutePage SelectEducationalInstituteAndContinue()
        { 
            SelectRadioOptionByText("An educational institute");
            Continue();
            return new TypeOfEducationalInstitutePage(_context);
        }
        public DescribeYourOrganisationPage SelectIndependentTrainingProviderAndContinue()
        {
            SelectRadioOptionByText("An Independent Training Provider");
            Continue();
            return new DescribeYourOrganisationPage(_context);
        }
        public TrainApprenticesPage SelectNoneOfTheAboveAndContinue()
        {
            SelectRadioOptionByText("None of the above");
            Continue();
            return new TrainApprenticesPage(_context);
        }
        public DescribeYourOrganisationPage SelectGroupTrainingAssociationAndContinue()
        {
            SelectRadioOptionByText("A Group Training Association");
            Continue();
            return new DescribeYourOrganisationPage(_context);
        }
        public TypeOfBodyPage SelectPublicBodyAndContinue()
        { 
            SelectRadioOptionByText("A public body");
            Continue();
            return new TypeOfBodyPage(_context);
        }
    }
}
