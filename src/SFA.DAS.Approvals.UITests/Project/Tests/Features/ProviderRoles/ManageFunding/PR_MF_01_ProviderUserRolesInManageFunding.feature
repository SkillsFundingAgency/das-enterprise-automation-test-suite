Feature: PR_MF_01_ProviderUserRolesInManageFunding

@approvals
@regression
@pasproviderrole
Scenario: PR_MF_01_ProviderUserRolesInManageFunding
	Given the provider logs in as a <UserRole>
	When user naviagates to 'Funding for non-levy employers' page
	Then user can <ReserveNewFunding> as defined in the table below
	And user can <DeleteExistingReservations> as defined in the table below
	And user can <AddApprenticesToReservation> as defined in the table below
	


Examples:
	| UserRole                | ReserveNewFunding | DeleteExistingReservations | AddApprenticesToReservation |
	| Viewer                  | false             | false                      | false                       |
	| Contributor             | true              | true                       | true                        |
	| ContributorWithApproval | true              | true                       | true                        |
	| AccountOwner            | true              | true                       | true                        |
