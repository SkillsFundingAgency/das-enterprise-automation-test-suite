Feature: RE_MT_01

@registration
@addpayedetails
Scenario: RE_MT_01_Create a Levy Account for a specific period
	Given the following levy declarations with english fraction of 1.00 calculated at 2019-01-15
		| Year  | Month | LevyDueYTD | LevyAllowanceForFullYear | SubmissionDate |
		| 19-20 | 1     | 42000      | 60000                    | 2019-05-15     |
		| 19-20 | 2     | 44000      | 60000                    | 2019-05-15     |
		| 19-20 | 3     | 48000      | 60000                    | 2019-05-15     |
	And an User Account is created
	When the User adds PAYE details
	And adds Organisation details
	And the Employer does not sign the Agreement
	Then the Employer Home page is displayed