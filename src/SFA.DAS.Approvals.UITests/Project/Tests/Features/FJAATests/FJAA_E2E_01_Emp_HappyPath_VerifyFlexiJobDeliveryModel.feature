@approvals
Feature: FJAA_E2E_01_VerifyFlexiJobDeliveryModel

In this test, a levy employer, who is on Flexi-job register, logs in to their employer account. 
Flexi employer adds an apprentice details and selects 'Flexi-job agency' as delivery model,
validates flexi-job content and submits apprentice details for provider to review.
Provider logs into their account, finds the cohort, adds ULN for the apprentice.
Validates Flexi-job tag on the apprenticeship and approves the cohort.  

@regression
@flexi-job
@e2escenarios
Scenario: FJAA_E2E_01_VerifyFlexiJobDeliveryModel_EmployerAddsApprenticeDetails
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When employer selects Flexi-job agency radio button on Select Delivery Model screen 
	Then validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	And validate Flexi-job agency tag on Approve Apprentice Details page and send cohort to Provider for review
	And the provider validates Flexi-job content, adds Uln and approves the cohorts

