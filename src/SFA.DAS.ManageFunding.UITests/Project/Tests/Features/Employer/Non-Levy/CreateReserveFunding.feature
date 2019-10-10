Feature: CreateReserveFunding

@regression
@reservefunds
Scenario: Reserving funding by a non-levy eoi employer
	Given the Employer reserves funding for an apprenticeship course
	Then the funding is successfully reserved
	And the Employer can add the full apprentice details