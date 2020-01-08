Feature: RE_CA_06_CreateLevyAccount

@addpayedetails
@regression
@registration
Scenario: RE_CA_06_Create Levy Account
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


@addpayedetails
Scenario: RE_CA_07_Create Levy Account for past n months
	Given levy declarations is added for past 15 months with levypermonth as 10000
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
	Then I will land in the User Home page
