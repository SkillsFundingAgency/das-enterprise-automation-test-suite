@approvals
Feature: FJAA_DLock_03_Pro_EditDeliveryModel_FlexiToRegular

In this test, a Training Provider logs into their account and navigates to the 'Manage your apprentices' page. 
Provider then edits an apprentice record that has been successfully data locked
changing DM from Flexi to Regular and submits changes for approval.
FJAA Employer then views changes and approves, later verifying that changes have been saved.

@regression
@flexi-job
@e2escenarios
Scenario: FJAA_DLock_03_Pro_EditDeliveryModel_FlexiToRegular
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the Employer approves the cohorts
	Given the datalock has been successful
	When the Provider edits the Delivery Model to Regular in Post Approvals and submits changes
	Then the employer can review and approve the changes

