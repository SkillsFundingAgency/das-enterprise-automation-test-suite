@approvals
Feature: FJAA_RMR_EJ_03_EditLiveApprenticeAfterRemoval

In this test, an FJAA Employer, 
has active apprentices on the "Flexi-job agency" delivery model. 
Then the FJAA employer is removed from the Flexi-Job register,
and the apprentice delivery model must remain as Flexi-Job until
the employer edits the delivery model,
then the delivery model can no longer be edited.

@regression
@flexi-job
@e2escenarios
@rofjaadb
Scenario: FJAA_RMR_EJ_03_EditLiveApprenticeAfterRemoval
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the Employer approves the cohorts
	Then the employer is removed from the Flexi-job agency register
	And the employer confirms Delivery Model is displayed as "Flexi-job agency" on Apprentice Details and Edit Apprentice screens
	When the employer edits apprentice delivery model to Regular in Post Approvals and Submits changes
	Then the provider can review and approve the changes


	
