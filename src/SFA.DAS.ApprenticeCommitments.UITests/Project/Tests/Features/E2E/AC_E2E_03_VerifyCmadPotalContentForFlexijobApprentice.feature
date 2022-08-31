Feature: AC_E2E_03_VerifyCmadPotalContentForFlexijobApprentice

This test verifies the content of the CMAD account for a Flexijob apprentice

@apprenticecommitments
@regression
@flexi-job
@e2escenarios
Scenario: AC_E2E_03_VerifyCmadPotalContentForFlexijobApprentice
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When employer selects Flexi-job agency radio button on Select Delivery Model screen 
	Then validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	And validate Flexi-job agency tag on Approve Apprectice Details page then notify Provider
	And the provider validates Flexi-job content, adds Uln and approves the cohorts
	And the apprentice creates their CMAD account
	And the apprentice can navigate to CMAD Details confirmation page and confirm their apprenticeship is flexijob

