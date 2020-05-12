using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        #region Section-1
        private string OrganisationChecks => "1. Organisation checks";
        private string OrganisationChecks_1 => "Legal name";
        private string OrganisationChecks_2 => "Trading name";
        private string OrganisationChecks_3 => "Organisation status";
        private string OrganisationChecks_4 => "Address";
        private string OrganisationChecks_5 => "ICO registration number";
        private string OrganisationChecks_6 => "Website address";
        private string OrganisationChecks_7 => "Organisation high risk";
        #endregion

        #region Section-2
        private string PeopleincontrolChecks => "2. People in control checks";
        private string PeopleincontrolChecks_1 => "People in control";
        private string PeopleincontrolChecks_2 => "People in control high risk";
        #endregion

        #region Section-3
        private string RegisterChecks => "3. Register checks";
        private string RegisterChecks_1 => "RoATP";
        private string RegisterChecks_2 => "Register of end-point assessment organisations";
        #endregion

        #region Section-4
        private string ExperienceAndAccreditationChecks => "4. Experience and accreditation checks";
        private string ExperienceAndAccreditationChecks_1 => "Office for Student(OfS)";
        private string ExperienceAndAccreditationChecks_2 => "Initial teacher training(ITT)";
        private string ExperienceAndAccreditationChecks_3 => "Ofsted";
        private string ExperienceAndAccreditationChecks_4 => "Subcontractor declaration";
        #endregion

        #region Section-5
        private string OrganisationsCriminalandComplianceChecks => "5. Organisation’s criminal and compliance checks";
        private string OrganisationsCriminalandComplianceChecks_1 => "Composition with creditors";
        private string OrganisationsCriminalandComplianceChecks_2 => "Failed to pay back funds";
        private string OrganisationsCriminalandComplianceChecks_3 => "Contract terminated early by a public body";
        private string OrganisationsCriminalandComplianceChecks_4 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_5 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_6 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_7 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_8 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_9 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_10 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_11 => "Legal name";
        private string OrganisationsCriminalandComplianceChecks_12 => "Legal name";
        #endregion

        #region Section-6
        private string PeopleinControlsCriminalandComplianceChecks => "6. People in control’s criminal and compliance checks";
        private string PeopleinControlsCriminalandComplianceChecks_1 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_2 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_3 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_4 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_5 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_6 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_7 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_8 => "Legal name";
        private string PeopleinControlsCriminalandComplianceChecks_9 => "Legal name";
        #endregion

        #region Section-7
        private string OverallGatewayOutcome => "7. Overall gateway outcome";
        private string OverallGatewayOutcome_1 => "Legal name";
        #endregion
    }
}