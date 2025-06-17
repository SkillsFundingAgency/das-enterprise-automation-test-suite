Feature: FJAA_E2E_09_DeliveryModelNotDisplayedForNonFJAAEmp

In this test, a Non-FJAA employer and Training Provider 
both confirm that the Delivery Model sections are not displayed on their respective portal pages
against their current apprentice.

@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
Scenario: FJAA_E2E_09_DeliveryModelNotDisplayedForNonFJAAEmp
	Given the Employer logins using existing Levy Account
	When the Employer adds 1 apprentices and sends to provider
	And the provider adds Ulns and approves the cohorts and sends to employer
	Then the Employer approves the cohorts
	And the employer confirms Delivery Model is not displayed on Apprentice Details Screen
