using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhatIsYourOrganisationPage : RoatpBasePage
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
    }
}
