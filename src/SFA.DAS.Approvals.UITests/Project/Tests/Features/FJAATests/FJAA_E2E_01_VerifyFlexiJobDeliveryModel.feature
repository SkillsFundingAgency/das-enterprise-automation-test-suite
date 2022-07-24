@approvals
Feature: FJAA_E2E_01_VerifyFlexiJobDeliveryModel

In this test, A levy Employer, who is on Flexi-job register logs in to their employer account. 

1. Add steps in the precondition to check if the user is on the register if they are not then add them

@regression
@flexi-job
@e2escenarios
Scenario: FJAA_E2E_01_VerifyFlexiJobDeliveryModel_EmployerAddsApprenticeDetails
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	And employer selects Flexi-job agency radio button on Select Delivery Model screen 

