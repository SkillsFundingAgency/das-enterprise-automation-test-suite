Feature: CreateReserveFunding

@regression
@reservefunds
Scenario: Reserving funding by a non-levy eoi employer
	Given the Employer login using existing eoi account
	When the Employer reserves funding for an apprenticeship course
	Then Verify funding is successfully reserved