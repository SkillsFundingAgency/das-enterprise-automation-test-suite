Feature: RAA_E_EN_01

@raa
@raaemployer
@raae2e
@raaemployere2e
@regression
Scenario: RAA_E_EN_01 - Create an advert with registered name, reject the advert and verify email notification
	Given the Employer creates an advert by using a registered name
	And the Reviewer Refer the vacancy
	Then the 'employer' receives 'rejected advert' email notification