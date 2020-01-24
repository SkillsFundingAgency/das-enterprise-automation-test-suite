using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public partial class ApplicationOverviewPage : RoatpBasePage
    {
        //Access Section

        #region Section2

        public FinancialHealthAssessmentPage Access_Section2_IntroductionWhatYouwillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(FinancialEvidence, FinancialEvidence_1));
            return new FinancialHealthAssessmentPage(_context);
        }

        public AnnualTurnoverPage Access_Section2_YourOrganisationsFinancialEvidence()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(FinancialEvidence, FinancialEvidence_2));
            return new AnnualTurnoverPage(_context);
        }

        public ConsolidatedFinancialStatementsPage Access_Section2_YourUkUltimateParentCompanyFinancialEvidence()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(FinancialEvidence, FinancialEvidence_3));
            return new ConsolidatedFinancialStatementsPage(_context);
        }

        #endregion

        #region Seciton1

        public YourOrganisationPage AccessIntroductionWhatYouWillNeedSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_1));
            return new YourOrganisationPage(_context);
        }

        public UltimateParentCompanyPage AccessYourOrganisationSectionForOrgTypeCompany()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_2));
            return new UltimateParentCompanyPage(_context);
        }
        public ConfrimWhosInControlPage AccessTellUSWhosInControlSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_3));
            return new ConfrimWhosInControlPage(_context);
        }
        public WhatIsYourOrganisationPage AccessDescribeYourOrganisationsForOrgTypeCharity()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_4));
            return new WhatIsYourOrganisationPage(_context);
        }
        public FundedByTheOfficeForStudentsPage AccessExperienceAndAccreditationsSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_5));
            return new FundedByTheOfficeForStudentsPage(_context);
        }

        #endregion

    }

}
