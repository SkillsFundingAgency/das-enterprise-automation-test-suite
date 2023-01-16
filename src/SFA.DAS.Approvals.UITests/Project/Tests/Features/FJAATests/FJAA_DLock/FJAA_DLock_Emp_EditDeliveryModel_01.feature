@approvals
Feature: FJAA_DLock_Emp_EditDeliveryModel_01

In this test, an FJAA Employer logs into their account and navigates to the 'Manage your apprentices' page. 
Employer then edits an apprentice record that has been successfully data locked
changing DM from Flexi to Regular and submits changes for approval.
Training Provider then views changes and approves, later verifying that changes have been saved.

@regression
@flexi-job
@e2escenarios
Scenario: FJAA_DLock_Emp_EditDeliveryModel_01
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider selects Flexi-job agency radio button on Select Delivery Model screen 
	Then provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details
	Then the Employer approves the cohorts
	Given the datalock has been successful
	When the employer edits apprentice delivery model to Regular in Post Approvals and Submits changes
	Then the provider can review and approve the changes
	And the provider confirms Delivery Model is displayed as "Regular" on Apprentice Details and Edit Apprentice screens
	And the employer confirms Delivery Model is displayed as "Regular" on Apprentice Details and Edit Apprentice screens
