Feature: CreateLevyAccount

A short summary of the feature


@addpayedetails
Scenario: Create Levy Account
Given the following levy declarations with english fraction of 1.00 calculated at 2019-01-15
| Year  | Month | LevyDueYTD | LevyAllowanceForFullYear | SubmissionDate |
| 19-20 | 1     | 42000      | 60000                    | 2019-05-15     |
| 19-20 | 2     | 44000      | 60000                    | 2019-05-15     |
| 19-20 | 3     | 48000      | 60000                    | 2019-05-15     |
Given I create an Account 
When I add paye details
And organisation details
When I do not sign the agreement
Then I will land in the User Home page



@addpayedetails
Scenario: Create Levy Account For Approvals
Given I have levy declarations for past 3 months

