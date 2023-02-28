@approvals
@donotexecuteinparallel
Feature: FJAA_RMR_PJ_01_Provider_RemovalWithDraftApprentice

In this test, a Training Provider, 
has draft apprentices on the "Flexi-job agency" delivery model. 
Then the FJAA employer is removed from the Flexi-Job register,
and the Provider is prevented from approving the cohort until delivery model is changed to Regular. 

@regression
@flexi-job
@e2escenarios
@rofjaadb
Scenario: FJAA_RMR_PJ_01_Provider_RemovalWithDraftApprentice
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When employer selects Flexi-job agency radio button on Select Delivery Model screen 
	Then validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	And validate Flexi-job agency tag on Approve Apprentice Details page and send cohort to Provider for review
	Then the employer is removed from the Flexi-job agency register
	And the provider can no longer approve the draft cohort
	And provider can edit delivery model and approve
