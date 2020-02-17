using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public partial class ApplicationOverviewPage : RoatpBasePage
    {
        #region Questions
        private string Yourorganisation => "Your organisation";
        private string YourOrganisation_1 => "Introduction and what you'll need";
        private string YourOrganisation_2 => "Organisation information";
        private string YourOrganisation_3 => "Tell us who's in control";
        private string YourOrganisation_4 => "Describe your organisation";
        private string YourOrganisation_5 => "Experience and accreditation";

        private string FinancialEvidence => "Financial evidence";
        private string FinancialEvidence_1 => "Introduction and what you'll need";
        private string FinancialEvidence_2 => "Your organisation's financial evidence";
        private string FinancialEvidence_3 => "Your UK ultimate parent company's financial evidence";

        private string CriminalAndComplianceChecks => "Criminal and compliance checks";
        private string CriminalAndComplianceChecks_1 => "Introduction and what you'll need";
        private string CriminalAndComplianceChecks_2 => "Checks on your organisation";
        private string CriminalAndComplianceChecks_3 => "Introduction and what you'll need";
        private string CriminalAndComplianceChecks_4 => "Checks on who's in control of your organisation";


        private string ProtectingYourApprentices => "Protecting your apprentices";
        private string ProtectingYourApprentices_1 => "Introduction and what you'll need";
        private string ProtectingYourApprentices_2 => "Continuity plan for apprenticeship training";
        private string ProtectingYourApprentices_3 => "Equality and diversity policy";
        private string ProtectingYourApprentices_4 => "Safeguarding and Prevent duty policy";
        private string ProtectingYourApprentices_5 => "Health and safety policy";

        private string ReadinessToEngage => "Readiness to engage";
        private string ReadinessToEngage_1 => "Introduction and what you'll need";
        private string ReadinessToEngage_2 => "Engaging with employers";
        private string ReadinessToEngage_3 => "Complaints policy";
        private string ReadinessToEngage_4 => "Contract for services template";
        private string ReadinessToEngage_5 => "Commitment statement template";
        private string ReadinessToEngage_6 => "Prior learning of apprentices";
        private string ReadinessToEngage_7 => "Working with subcontractors";

        private string PlanningApprenticeshipTraining => "Planning apprenticeship training";
        private string PlanningApprenticeshipTraining_1 => "Introduction and what you'll need";
        private string PlanningApprenticeshipTraining_2 => "Type of apprenticeship training";
        private string PlanningApprenticeshipTraining_3 => "Supporting apprentices";
        private string PlanningApprenticeshipTraining_4 => "Forecasting starts";
        private string PlanningApprenticeshipTraining_5 => "Off the job training";
        private string PlanningApprenticeshipTraining_6 => "Where will your apprentices be trained";

        private string DeliveringApprenticeshipTraining => "Delivering apprenticeship training";
        private string DeliveringApprenticeshipTraining_1 => "Introduction and what you'll need";
        private string DeliveringApprenticeshipTraining_2 => "Overall accountability for apprenticeships";
        private string DeliveringApprenticeshipTraining_3 => "Management hierarchy for apprenticeships";
        private string DeliveringApprenticeshipTraining_4 => "Quality and high standards in apprenticeship training";
        private string DeliveringApprenticeshipTraining_5 => "Developing and delivering training";
        private string DeliveringApprenticeshipTraining_6 => "Your sectors and employees";
        private string DeliveringApprenticeshipTraining_7 => "Policy for professional development of employees";


        private string EvaluatingApprenticeshipTraining => "Evaluating apprenticeship training";
        private string EvaluatingApprenticeshipTraining_1 => "Introduction and what you'll need";
        private string EvaluatingApprenticeshipTraining_2 => "Process for evaluating the quality of training delivered";
        private string EvaluatingApprenticeshipTraining_3 => "Process of evaluating the quality of apprenticeship training";
        private string EvaluatingApprenticeshipTraining_4 => "Systems and processes to collect apprenticeship data";

        private string Finish => "Finish";
        private string Finish_1 => "Application permissions and checks";
        private string Finish_2 => "'Commercial in confidence' information";
        private string Finish_3 => "Terms and conditions";
        private string Finish_4 => "Submit application";

        #endregion

    }

}
