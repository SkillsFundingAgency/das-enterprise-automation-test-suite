using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        #region Section-1
        private static string OrganisationChecks => "1. Organisation checks";
        private static string OrganisationChecks_1 => "1 application in 12 months";
        private static string OrganisationChecks_2 => "Legal name";
        private static string OrganisationChecks_3 => "Trading name";
        private static string OrganisationChecks_4 => "Organisation status";
        private static string OrganisationChecks_5 => "Address";
        private static string OrganisationChecks_6 => "ICO registration number";
        private static string OrganisationChecks_7 => "Website address";
        private static string OrganisationChecks_8 => "Organisation high risk";
        #endregion

        #region Section-2
        private static string PeopleInControlChecks => "2. People in control checks";
        private static string PeopleInControlChecks_1 => "People in control";
        private static string PeopleInControlChecks_2 => "People in control high risk";
        #endregion

        #region Section-3
        private static string RegisterChecks => "3. Register checks";
        private static string RegisterChecks_1 => "RoATP";
        private static string RegisterChecks_2 => "Register of end-point assessment organisations";
        #endregion

        #region Section-4
        private static string ExperienceAndAccreditationChecks => "4. Experience and accreditation checks";
        private static string ExperienceAndAccreditationChecks_1 => "Office for Student";
        private static string ExperienceAndAccreditationChecks_2 => "Initial teacher training";
        private static string ExperienceAndAccreditationChecks_3 => "Ofsted";
        private static string ExperienceAndAccreditationChecks_4 => "Subcontractor declaration";
        #endregion

        #region Section-5
        private static string OrganisationsCriminalAndComplianceChecks => "5. Organisation's criminal and compliance checks";
        private static string OrganisationsCriminalAndComplianceChecks_1 => "Composition with creditors";
        private static string OrganisationsCriminalAndComplianceChecks_2 => "Failed to pay back funds";
        private static string OrganisationsCriminalAndComplianceChecks_3 => "Contract terminated early by a public body";
        private static string OrganisationsCriminalAndComplianceChecks_4 => "Withdrawn from a contract with a public body";
        private static string OrganisationsCriminalAndComplianceChecks_5 => "Register of Training Organisations (RoTO)";
        private static string OrganisationsCriminalAndComplianceChecks_6 => "Funding removed from any education bodies";
        private static string OrganisationsCriminalAndComplianceChecks_7 => "Removed from any professional or trade registers";
        private static string OrganisationsCriminalAndComplianceChecks_8 => "Initial Teacher Training accreditation";
        private static string OrganisationsCriminalAndComplianceChecks_9 => "Removed from any charity register";
        private static string OrganisationsCriminalAndComplianceChecks_10 => "Investigated due to safeguarding issues";
        private static string OrganisationsCriminalAndComplianceChecks_11 => "Investigated by the ESFA or other public body or regulator";
        private static string OrganisationsCriminalAndComplianceChecks_12 => "Insolvency or winding up proceedings";
        #endregion

        #region Section-6
        private static string PeopleInControlsCriminalAndComplianceChecks => "6. People in control's criminal and compliance checks";
        private static string PeopleInControlsCriminalAndComplianceChecks_1 => "Unspent criminal convictions";
        private static string PeopleInControlsCriminalAndComplianceChecks_2 => "Failed to pay back funds";
        private static string PeopleInControlsCriminalAndComplianceChecks_3 => "Investigated for fraud or irregularities";
        private static string PeopleInControlsCriminalAndComplianceChecks_4 => "Ongoing investigations for fraud or irregularities";
        private static string PeopleInControlsCriminalAndComplianceChecks_5 => "Contract terminated early by a public body";
        private static string PeopleInControlsCriminalAndComplianceChecks_6 => "Withdrawn from a contract with a public body";
        private static string PeopleInControlsCriminalAndComplianceChecks_7 => "Breached tax payments or social security contributions";
        private static string PeopleInControlsCriminalAndComplianceChecks_8 => "Register of Removed Trustees";
        private static string PeopleInControlsCriminalAndComplianceChecks_9 => "Been made bankrupt";
        private static string PeopleInControlsCriminalAndComplianceChecks_10 => "Prohibition order from Teaching Regulation Agency";
        private static string PeopleInControlsCriminalAndComplianceChecks_11 => "Ban from management or governance of schools";
        #endregion

        #region Section-7
        private static string OverallGatewayOutcome => "7. Overall gateway outcome";
        private static string OverallGatewayOutcome_1 => "Confirm gateway outcome";
        #endregion
    }
}