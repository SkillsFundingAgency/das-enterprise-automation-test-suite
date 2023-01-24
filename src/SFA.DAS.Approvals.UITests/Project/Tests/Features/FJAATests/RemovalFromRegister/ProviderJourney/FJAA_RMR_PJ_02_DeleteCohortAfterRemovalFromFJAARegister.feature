@approvals
@donotexecuteinparallel
Feature: FJAA_RMR_PJ_02_DeleteCohortAfterRemovalFromFJAARegister

In this test, a Training Provider holds a draft cohort with apprentices on
the Flexi-Job Agency delivery model.
Before the cohort is approved, the employer is removed from the FJAA register
and we confirm that the provider is still able to delete cohort

@regression
@flexi-job
@e2escenarios
@rofjaadb
Scenario: FJAA_RMR_PJ_02_DeleteCohortAfterRemovalFromFJAARegister
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When employer selects Flexi-job agency radio button on Select Delivery Model screen 
	Then validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	And validate Flexi-job agency tag on Approve Apprentice Details page and send cohort to Provider for review
	Then the employer is removed from the Flexi-job agency register
	And provider navigates to Approve Apprentice page and deletes Cohort before approval
	

