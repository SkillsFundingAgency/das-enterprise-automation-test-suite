@approvals
Feature: FJAA_E2E_03_Emp_HappyPath_NewEmployerIsOnFJARegister

In this test, a Training Provider,logs in to their account. 
Training Provider adds an apprentice details and selects 'Flexi-job agency' as delivery model,
validates flexi-job content and submits apprentice details for flexi employer to review.
Flexi Employer logs into their account, finds the cohort.
Validates Flexi-job tag on the apprenticeship and can edit the DM.

@regression
@flexi-job
@e2escenarios
Scenario: FJAA_E2E_03_Emp_HappyPath_NewEmployerIsOnFJARegister
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	And employer validates apprentice is Flexi-job and can edit Delivery Model

