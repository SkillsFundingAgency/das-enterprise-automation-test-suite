Feature: PR_MF_01_ProviderUserRolesInManageFunding

@approvals
@regression
@pasproviderrole
@mfatest
Scenario: PR_MF_01_ProviderUserRolesInManageFunding
	Given Provider Account Owner can make a reservation
	Then user can signout from their account
	When the provider logs in as a <UserRole>	
	When user naviagates to 'Funding for non-levy employers' page
	Then user can Reserve New Funding as defined in the table below <ReserveNewFunding>
	And user can Delete Existing Reservations as defined in the table below <DeleteExistingReservations>
	And user can Add Apprentices To Reservation as defined in the table below <AddApprenticesToReservation>
	


Examples:
	| UserRole                | ReserveNewFunding | DeleteExistingReservations | AddApprenticesToReservation |
	#| Viewer                  | false             | false                      | false                       |
	#| Contributor             | true              | true                       | true                        |
	#| ContributorWithApproval | true              | true                       | true                        |
	| AccountOwner            | true              | true                       | true                        |
