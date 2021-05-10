using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmApprenticePage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm this is the correct apprentice";
        private readonly ScenarioContext _context;

        public AS_ConfirmApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhichVersionPage GoToWhichVersionPage(string enrolledStandard)
        {
            SelectStandard(enrolledStandard);

            return new AS_WhichVersionPage(_context);
        }


        public AS_WhichVersionPage GoToDeclaraionPage(string enrolledStandard)
        {
            SelectStandard(enrolledStandard);

            return new AS_WhichVersionPage(_context);
            
        }

        public AS_WhichLearningOptionPage GoToDeclaraionPage1(string enrolledStandard)
        {
            SelectStandard(enrolledStandard);

            return new AS_WhichLearningOptionPage(_context);

        }


        private void SelectStandard(string enrolledStandard)
        {
            switch (enrolledStandard)
            {
                case "additional learning option":
                    SelectStandardWithAdditionalLearningOption();
                    break;
                case "more than one":
                    SelectFirstStandardFromMultipleOptions();
                    break;
                default:
                    break;
                        
            }

            Continue();
        }


        private void SelectStandardWithAdditionalLearningOption()
        {
            SelectRadioOptionByForAttribute("standard_6");
        }

        private void SelectFirstStandardFromMultipleOptions()
        {
            SelectRadioOptionByForAttribute("standard_239");
        }
    }
}