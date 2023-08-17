Feature: FJAA_RMR_EJ_02_DeleteCohortAfterRemovalFromFJAARegister

In this test, an FJAA Employer holds a draft cohort with apprentices on
the Flexi-Job Agency delivery model.
Before the cohort is approved, the employer is removed from the FJAA register
and we confirm that the employer is still able to delete cohort

@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
@rofjaadb
@donotexecuteinparallel
Scenario: FJAA_RMR_EJ_02_DeleteCohortAfterRemovalFromFJAARegister
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the employer is removed from the Flexi-job agency register
	And employer navigates to Approve Apprentice page and deletes Cohort before approval