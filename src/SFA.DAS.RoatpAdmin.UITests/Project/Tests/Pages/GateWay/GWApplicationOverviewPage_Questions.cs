using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        #region Section-1
        private string OrganisationChecks => "1. Organisation checks";
        private string OrganisationChecks_1 => "1 application in 12 months";
        private string OrganisationChecks_2 => "Legal name";
        private string OrganisationChecks_3 => "Trading name";
        private string OrganisationChecks_4 => "Organisation status";
        private string OrganisationChecks_5 => "Address";
        private string OrganisationChecks_6 => "ICO registration number";
        private string OrganisationChecks_7 => "Website address";
        private string OrganisationChecks_8 => "Organisation high risk";
        #endregion

        #region Section-2
        private string PeopleInControlChecks => "2. People in control checks";
        private string PeopleInControlChecks_1 => "People in control";
        private string PeopleInControlChecks_2 => "People in control high risk";
        #endregion

        #region Section-3
        private string RegisterChecks => "3. Register checks";
        private string RegisterChecks_1 => "RoATP";
        private string RegisterChecks_2 => "Register of end-point assessment organisations";
        #endregion

        #region Section-4
        private string ExperienceAndAccreditationChecks => "4. Experience and accreditation checks";
        private string ExperienceAndAccreditationChecks_1 => "Office for Student";
        private string ExperienceAndAccreditationChecks_2 => "Initial teacher training";
        private string ExperienceAndAccreditationChecks_3 => "Ofsted";
        private string ExperienceAndAccreditationChecks_4 => "Subcontractor declaration";
        #endregion

        #region Section-5
        private string OrganisationsCriminalAndComplianceChecks => "5. Organisation's criminal and compliance checks";
        private string OrganisationsCriminalAndComplianceChecks_1 => "Composition with creditors";
        private string OrganisationsCriminalAndComplianceChecks_2 => "Failed to pay back funds";
        private string OrganisationsCriminalAndComplianceChecks_3 => "Contract terminated early by a public body";
        private string OrganisationsCriminalAndComplianceChecks_4 => "Withdrawn from a contract with a public body";
        private string OrganisationsCriminalAndComplianceChecks_5 => "Register of Training Organisations (RoTO)";
        private string OrganisationsCriminalAndComplianceChecks_6 => "Funding removed from any education bodies";
        private string OrganisationsCriminalAndComplianceChecks_7 => "Removed from any professional or trade registers";
        private string OrganisationsCriminalAndComplianceChecks_8 => "Initial Teacher Training accreditation";
        private string OrganisationsCriminalAndComplianceChecks_9 => "Removed from any charity register";
        private string OrganisationsCriminalAndComplianceChecks_10 => "Investigated due to safeguarding issues";
        private string OrganisationsCriminalAndComplianceChecks_11 => "Investigated due to whistleblowing issues";
        private string OrganisationsCriminalAndComplianceChecks_12 => "Insolvency or winding up proceedings";
        #endregion

        #region Section-6
        private string PeopleInControlsCriminalAndComplianceChecks => "6. People in control's criminal and compliance checks";
        private string PeopleInControlsCriminalAndComplianceChecks_1 => "Unspent criminal convictions";
        private string PeopleInControlsCriminalAndComplianceChecks_2 => "Failed to pay back funds";
        private string PeopleInControlsCriminalAndComplianceChecks_3 => "Investigated for fraud or irregularities";
        private string PeopleInControlsCriminalAndComplianceChecks_4 => "Ongoing investigations for fraud or irregularities";
        private string PeopleInControlsCriminalAndComplianceChecks_5 => "Contract terminated early by a public body";
        private string PeopleInControlsCriminalAndComplianceChecks_6 => "Withdrawn from a contract with a public body";
        private string PeopleInControlsCriminalAndComplianceChecks_7 => "Breached tax payments or social security contributions";
        private string PeopleInControlsCriminalAndComplianceChecks_8 => "Register of Removed Trustees";
        private string PeopleInControlsCriminalAndComplianceChecks_9 => "Been made bankrupt";
        #endregion

        #region Section-7
        private string OverallGatewayOutcome => "7. Overall gateway outcome";
        private string OverallGatewayOutcome_1 => "Confirm gateway outcome";
        #endregion
    }
}