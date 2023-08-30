Feature: FJAA_RMR_EJ_01_RemovalWithDraftApprentices

In this test, a levy employer, who is on Flexi-job register, 
has draft apprentices on the "Flexi-job agency" delivery model. 
Then the employer is removed from the Flexi-Job register,
and they are prevented from approving the cohort until delivery model is changed to Regular. 

@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
@rofjaadb
@donotexecuteinparallel
Scenario: FJAA_RMR_EJ_01_RemovalWithDraftApprentices
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And employer selects Flexi-job agency radio button on Select Delivery Model screen
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the employer is removed from the Flexi-job agency register
	And the previously registered FJAA employer can no longer approve the draft cohort
	And the previously registered FJAA employer can edit delivery model and then approve
	