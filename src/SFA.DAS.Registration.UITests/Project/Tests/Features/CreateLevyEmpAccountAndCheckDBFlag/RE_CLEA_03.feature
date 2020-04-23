Feature: RE_CLEA_03

@registration
@addpayedetails
Scenario: RE_CLEA_03_Create a Levy Account for a specific period
	Given the following levy declarations with english fraction of 1.00 calculated at 2019-01-15
		| Year  | Month | LevyDueYTD | LevyAllowanceForFullYear | SubmissionDate |
		| 19-20 | 1     | 42000      | 60000                    | 2019-05-15     |
		| 19-20 | 2     | 44000      | 60000                    | 2019-05-15     |
		| 19-20 | 3     | 48000      | 60000                    | 2019-05-15     |
	Then a Levy Employer Account with Company Type Org is created and agreement is Signed