Feature: FJAA_RemoveFromRegister

#In this test, a levy employer, who is on Flexi-job register, 
#has draft apprentices on the "Flexi-job agency" delivery model. 
#Then the employer is removed from the Flexi-Job register,
#and they are prevented from approving the cohort until delivery model is changed to Regular. 
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
	

#In this test, an FJAA Employer holds a draft cohort with apprentices on
#the Flexi-Job Agency delivery model.
#Before the cohort is approved, the employer is removed from the FJAA register
#and we confirm that the employer is still able to delete cohort
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


#In this test, an FJAA Employer, 
#has active apprentices on the "Flexi-job agency" delivery model. 
#Then the FJAA employer is removed from the Flexi-Job register,
#and the apprentice delivery model must remain as Flexi-Job until
#the employer edits the delivery model,
#then the delivery model can no longer be edited.
@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
@rofjaadb
@donotexecuteinparallel
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



#In this test, a Training Provider, 
#has draft apprentices on the "Flexi-job agency" delivery model. 
#Then the FJAA employer is removed from the Flexi-Job register,
#and the Provider is prevented from approving the cohort until delivery model is changed to Regular. 
@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
@rofjaadb
@donotexecuteinparallel
Scenario: FJAA_RMR_PJ_01_Provider_RemovalWithDraftApprentice
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When employer selects Flexi-job agency radio button on Select Delivery Model screen 
	Then validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	And validate Flexi-job agency tag on Approve Apprentice Details page and send cohort to Provider for review
	Then the employer is removed from the Flexi-job agency register
	And the provider can no longer approve the draft cohort
	And provider can edit delivery model and approve


#In this test, a Training Provider holds a draft cohort with apprentices on
#the Flexi-Job Agency delivery model.
#Before the cohort is approved, the employer is removed from the FJAA register
#and we confirm that the provider is still able to delete cohort
@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
@rofjaadb
@donotexecuteinparallel
Scenario: FJAA_RMR_PJ_02_DeleteCohortAfterRemovalFromFJAARegister
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When employer selects Flexi-job agency radio button on Select Delivery Model screen 
	Then validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	And validate Flexi-job agency tag on Approve Apprentice Details page and send cohort to Provider for review
	Then the employer is removed from the Flexi-job agency register
	And provider navigates to Approve Apprentice page and deletes Cohort before approval


#In this test, an Training Provider, 
#has active apprentices on the "Flexi-job agency" delivery model. 
#Then the FJAA employer is removed from the Flexi-Job register,
#and the apprentice delivery model must remain as Flexi-Job until
#the provider edits the delivery model,
#then the delivery model can no longer be edited.
@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
@rofjaadb
@donotexecuteinparallel
Scenario: FJAA_RMR_PJ_03_EditLiveApprenticeAfterRemoval
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the Employer approves the cohorts
	Then the employer is removed from the Flexi-job agency register
	And the provider confirms Delivery Model is displayed as "Flexi-job agency" on Apprentice Details and Edit Apprentice screens
	When the Provider edits the Delivery Model to Regular in Post Approvals and submits changes