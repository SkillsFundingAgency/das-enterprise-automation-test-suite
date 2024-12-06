Feature: PR_PAS_02_HomePageNavigation

@regression
@pasproviderrole
Scenario: PR_PAS_02_HomePageNavigation
	Given the provider logs in as a <UserRole>
	Then user can view <AddNewApprentices> page as defined in the table below
	And user can view <AddAnEmployer> page as defined in the table below
	And user can view <GetFundingForNonLevyEmployers> page as defined in the table below
	And user can view <ViewEmployersAndManagePermissions> page as defined in the table below
	And user can view <ApprenticeRequests> page as defined in the table below
	And user can view <ManageYourFundingReservedForNonLevyEmployers> page as defined in the table below
	And user can view <ManageYourApprentices> page as defined in the table below
	And user can view <RecruitApprentices> page as defined in the table below
	And user can view <YourStandardsAndTrainingVenues> page as defined in the table below
	And user can view <DeveloperAPIs> page as defined in the table below
	And user can view <YourFeedback> page as defined in the table below
	And user can view <ViewEmployerRequestsForTraining> page as defined in the table below



Examples:
	| UserRole                | AddNewApprentices | AddAnEmployer | GetFundingForNonLevyEmployers | ViewEmployersAndManagePermissions | ApprenticeRequests | ManageYourFundingReservedForNonLevyEmployers | ManageYourApprentices | RecruitApprentices | YourStandardsAndTrainingVenues | DeveloperAPIs | YourFeedback | ViewEmployerRequestsForTraining	|
	| Viewer                  | false             | false         | false                         | true                              | true               | true                                         | true                  | true               | true                           | true          | true         | true								|
	| Contributor             | true              | true          | true                          | true                              | true               | true                                         | true                  | true               | true                           | true          | true         | true								|
	| ContributorWithApproval | true              | true          | true                          | true                              | true               | true                                         | true                  | true               | true                           | true          | true         | true								|
	| AccountOwner            | true              | true          | true                          | true                              | true               | true                                         | true                  | true               | true                           | true          | true         | true								|
