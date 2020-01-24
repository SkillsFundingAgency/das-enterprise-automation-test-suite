using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class End2EndStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly YourOrganisationSectionHelper yourOrganisationSectionHelper;

        public End2EndStepsHelper(ScenarioContext context)
        {
            _context = context;
            yourOrganisationSectionHelper = new YourOrganisationSectionHelper();
        }

        internal TermsConditionsMakingApplicationPage SubmitValidUserDetails()
        {
            return new ServiceStartPage(_context)
                .ClickApplyNow()
                .SelectingNoOptionForFirstTimeSignInAndContinue()
                .SubmitValidUserDetails();
        }

        internal EnterUkprnPage AcceptAndContinue(TermsConditionsMakingApplicationPage page) => page.AcceptAndContinue();

        internal ApplicationOverviewPage CompleteProviderRouteSection(EnterUkprnPage enterUkprnPage)
        {
            return enterUkprnPage.EnterOrgTypeCompanyProvidersUkprn()
                .ClickConfirmAndContinue()
                .SelectApplicationRouteAsMain()
                .VerifyIntroductionStatus(StatusHelper.StatusNext);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = yourOrganisationSectionHelper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = yourOrganisationSectionHelper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = yourOrganisationSectionHelper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = yourOrganisationSectionHelper.CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = yourOrganisationSectionHelper.CompleteYourOrganisationSection_5(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section2_IntroductionWhatYouwillNeed()
                .ContinueOnFinancialHealthAssessment()
                .VerifyIntroductionStatus_Section2(StatusHelper.StatusCompleted)
                .Access_Section2_YourOrganisationsFinancialEvidence()
                .SelectYesOnAnnualTurnOverAndContinue()
                .SelectNoOnFundingFromEsfaAndContinue()
                .EnterInputsForFinancialEvidenceAndContinue()
                .SelectNoForLatestFullFinancialForTwelveMonthsAndContinue()
                .ClickYesForFinancialStatementsCoveringAnyPeriodAndContinue()
                .ContinueOnWhatYouNeedToUploadForFinancialStatementsAndManagementAccounts()
                .UploadFinancialFileAndContinue()
                .UploadManagementAccountsFileAndContinue()
                .SelectAnEmployeeInYourOrganisationOnWhoPreparedAnswersAndUploadPageAndContinue()
                .VerifyYourOrganisationsFinancialEvidence_Section2(StatusHelper.StatusCompleted)
                .Access_Section2_YourUkUltimateParentCompanyFinancialEvidence()
                .ClickNoOnConsolidatedFinancialStatements()
                .ClickNoOnOtherSubsidiaryCompanies()
                .UploadFullFinancialStatementsForTwelveMonthsAndContinue()
                .VerifyYourUkUltimateParentCompany_Section3(StatusHelper.StatusCompleted);
        }
    }
}
