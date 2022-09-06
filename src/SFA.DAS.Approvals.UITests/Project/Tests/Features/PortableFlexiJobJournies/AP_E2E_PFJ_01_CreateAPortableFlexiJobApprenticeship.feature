@approvals
Feature: AP_E2E_PFJ_01_CreateAPortableFlexiJobApprenticeship

@regression
@e2escenarios
@portableflexijob
Scenario: AP_E2E_PFJ_01 Employer creates a portable flexi-job apprenticeship and provider approves the cohort
	Given an Employer initiates a portable flexi-job apprenticeship creation
	Then the Employer validates Portable flexi-job content on Add Apprentice Details page
	And validates Portable flexi-job tag on Approve Apprentice Details and sends the cohort to the Provider for approval
	And the Provider validates Portable flexi-job content and approves the cohort
