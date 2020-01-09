Feature: RV1_MAF_01

@raa-v1
@regression
Scenario: RV1_MAF_01 - Verify Manage Admin functions
	When a Reviewer is on the Admin functions page
	Then Reviewer is able to select 'Manage Providers' link and view the page
	And Reviewer is able to select 'Manage Provider Sites' link and view the page
	And Reviewer is able to select 'Manage API Users' link and view the page
	And Reviewer is able to select 'Manage Employers' link and view the page
	And Reviewer is able to select 'Sectors' link and view the page
	And Reviewer is able to select 'Standards' link and view the page
	And Reviewer is able to select 'Frameworks' link and view the page