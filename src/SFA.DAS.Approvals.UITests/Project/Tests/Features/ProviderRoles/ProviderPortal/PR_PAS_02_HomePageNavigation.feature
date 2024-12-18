Feature: PR_PAS_02_HomePageNavigation

@regression
@pasproviderrole
Scenario: PR_PAS_02_HomePageNavigation
	Given the provider logs in as a <UserRole>
	Then user can view Add New Apprentices page as defined in the table below <AddNewApprentices>
	And user can view Add An Employer page as defined in the table below <AddAnEmployer>
	And user can view Get Funding For NonLevy Employers page as defined in the table below <GetFundingForNonLevyEmployers>
	And user can view View Employers And Manage Permissions page
	And user can view Apprentice Requests page
	And user can view Manage Your Funding Reserved For NonLevy Employers page
	And user can view Manage Your Apprentices page
	And user can view Recruit Apprentices page
	And user can view Your Standards And Training Venues page
	And user can view Your Feedback page
	And user can view View Employer Requests For Training page
	And user can view Developer APIs page as defined in the table below <DeveloperAPIs>



Examples:
	| UserRole                | AddNewApprentices | AddAnEmployer | GetFundingForNonLevyEmployers | DeveloperAPIs |
	| Viewer                  | false             | false         | false                         | false         |
	| Contributor             | true              | true          | true                          | false         |
	| ContributorWithApproval | true              | true          | true                          | false         |
	| AccountOwner            | true              | true          | true                          | true          |
