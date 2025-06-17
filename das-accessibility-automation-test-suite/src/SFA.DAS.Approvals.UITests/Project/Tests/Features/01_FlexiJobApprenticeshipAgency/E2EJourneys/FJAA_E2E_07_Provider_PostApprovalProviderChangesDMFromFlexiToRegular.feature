Feature: FJAA_E2E_07_Provider_PostApprovalProviderChangesDMFromFlexiToRegular

In this test, a Training Provider logs into their account and navigates to the 'Manage your apprentices' page. 
Provider then edits an apprentice record changing DM from Flexi to Regular
and submits changes for approval.
FJAA Employer then views changes and approves, later verifying that changes have been saved.

@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
Scenario: FJAA_E2E_07_Provider_PostApprovalProviderChangesDMFromFlexiToRegular
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the Employer approves the cohorts
	When the Provider edits the Delivery Model to Regular in Post Approvals and submits changes
	Then the employer can review and approve the changes
	And the employer confirms Delivery Model is displayed as "Regular" on Apprentice Details and Edit Apprentice screens
	And the provider confirms Delivery Model is displayed as "Regular" on Apprentice Details and Edit Apprentice screens
