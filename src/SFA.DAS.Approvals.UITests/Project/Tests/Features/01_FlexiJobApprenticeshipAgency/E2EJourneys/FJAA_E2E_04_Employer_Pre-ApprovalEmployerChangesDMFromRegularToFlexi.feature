Feature: FJAA_E2E_04_Employer_Pre-ApprovalEmployerChangesDMFromRegularToFlexi

In this test, a Training Provider,logs in to their account. 
Training Provider adds an apprentice details and selects 'Regular' as delivery model,
and submits apprentice details for flexi employer to review.
Flexi Employer logs into their account, finds the cohort.
Flexi Employer then changes DM from Regular to Flexi 
and sends back to Provider for Approval.

@regression
@flexijobapprenticeshipagency
@fjaae2escenarios
Scenario: FJAA_E2E_04_Employer_Pre-ApprovalEmployerChangesDMFromRegularToFlexi
	Given an employer who is on Flexi-job agency register logins using exisiting Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds an apprentice on the Regular Delivery Model and sends to Employer for approval
	Then the Employer changes the Delivery Model from Regular to Flexi and sends back to provider to review
	And the provider validates flexi-job content and approves cohort
