using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section2Helper
    {
        private readonly ScenarioContext _context;

        public Assessor_Section2Helper(ScenarioContext context) => _context = context;

        public ApplicationAssessmentOverviewPage PassEngagingWithEmployers(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section2_EngagingWithEmployers()
                    .SelectPassAndContinueInEngagingWithEmployersPage()
                    .SelectPassAndContinueInManagingRelationshipWithEmployersPage()
                    .SelectPassAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection2Link1Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassComplaintsPolicy(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section2_ComplaintsPolicy()
                    .SelectPassAndContinueInComplaintsPolicyPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link2Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection2Link2Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassContractForServicesTemplate(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section2_ContractForServicesTemplate()
                    .SelectPassAndContinue()
                    .VerifySection2Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection2Link3Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassCommitmentStatementTemplate(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01") || _context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section2_CommitmentStatementTemplate()
                    .SelectPassAndContinue()
                    .VerifySection2Link4Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection2Link4Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassPriorLearningOfApprentices(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01") || _context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section2_PriorLearningOfApprentices()
                    .SelectPassAndContinueInPriorLearningOfApprenticesPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link5Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection2Link5Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassWorkingWithSubcontractors(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01") || _context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section2_WorkingWithSubcontractors()
                    .SelectPassAndContinueInWorkingWithSubcontractorsPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link6Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection2Link6Status(StatusHelper.NotRequired);
            }
        }
    }
}
