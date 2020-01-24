using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public partial class ApplicationOverviewPage : RoatpBasePage
    {
        //Verify Sections 

        #region Section2

        public ApplicationOverviewPage VerifyIntroductionStatus_Section2(string status)
        {
            VerifyElement(GetTaskStatusElement(FinancialEvidence, FinancialEvidence_1), status);
            return this;
        }

        public ApplicationOverviewPage VerifyYourOrganisationsFinancialEvidence_Section2(string status)
        {
            VerifyElement(GetTaskStatusElement(FinancialEvidence, FinancialEvidence_2), status);
            return this;
        }

        public ApplicationOverviewPage VerifyYourUkUltimateParentCompany_Section3(string status)
        {
            VerifyElement(GetTaskStatusElement(FinancialEvidence, FinancialEvidence_3), status);
            return this;
        }

        #endregion

        #region Seciton1

        public ApplicationOverviewPage VerifyIntroductionStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_1), status);
            return this;
        }

        public ApplicationOverviewPage VerifyOrganisationInformation(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_2), status);
            return this;
        }

        public ApplicationOverviewPage VerifyTellUsWhosInControlStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_3), status);
            return this;
        }

        public ApplicationOverviewPage VerifyDescribeYourOrganisationStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_4), status);
            return this;
        }

        public ApplicationOverviewPage VerifyExperienceAndAccreditationsStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_5), status);
            return this;
        }
        #endregion

    }
}
