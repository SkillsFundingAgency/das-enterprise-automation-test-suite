Feature: RE_MT_01

@registration
@addpayedetails
Scenario: RE_MT_01_Create a Levy Account for a specific period
	Given the following levy declarations with english fraction of 1.00 calculated at 2019-01-15
		| Year  | Month | LevyDueYTD | LevyAllowanceForFullYear | SubmissionDate |
		| 19-20 | 1     | 42000      | 60000                    | 2019-05-15     |
		| 19-20 | 2     | 44000      | 60000                    | 2019-05-15     |
		| 19-20 | 3     | 48000      | 60000                    | 2019-05-15     |
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
	Then I will land in the User Home page