@approvals
Feature: FJAA_E2E_06_Pro_PreApprovalProviderChangesDMFromRegularToFlexi

In this test, an FJAA Employer,logs in to their account. 
Employer adds apprentice details and selects 'Regular' as delivery model,
and submits apprentice details for Training Provider to review.
Training Provider logs into their account, finds the cohort.
Training Provider then changes DM from Regular to Flexi 
and sends back to Employer for Approval.

@regression
@flexi-job
@e2escenarios
Scenario: FJAA_E2E_06_Pro_PreApprovalProviderChangesDMFromRegularToFlexi
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When employer selects Regular radio button on Select Delivery Model screen
	Then validate Regular content on Add Apprentice Details page and submit valid details
	And validate Flexi-job agency tag is not displayed on Approve Apprentice Details page and send cohort to provider for review
	And the Provider changes the Delivery Model from Regular to Flexi and sends back to employer to review
	And the employer validates Flexi-Job content and approves

