Feature: FJAA_E2E_08_DeliveryModelDisplayedOnEmployerAndProviderPortals

In this test, an FJAA employer and Training Provider 
both confirm that the Delivery Model sections are displayed on their respective portal pages
when a Flexi Job Delivery model is chosen for an apprentice.

@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
Scenario: FJAA_E2E_08_DeliveryModelDisplayedOnEmployerAndProviderPortals
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the Employer approves the cohorts
	And the employer confirms Delivery Model is displayed as "Flexi-job agency" on Apprentice Details and Edit Apprentice screens
	And the provider confirms Delivery Model is displayed as "Flexi-job agency" on Apprentice Details and Edit Apprentice screens
