Feature: ManageApprentices
	In order to find apprentices that i wish to see
	As an employer
	I need to be able to search for apprentices

@approvals
@regression
Scenario: Employer searches for apprentices
	Given A Employer has navigated to Manage your apprentice page
	When the employer filters by 'Live'
	Then the employer is presented with first page with no filters applied
