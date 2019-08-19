Feature: CreateAccount

A short summary of the feature


Scenario: Create Account without PAYE details
Given I create an Account 
Then I do not add paye details


@addpayedetails
Scenario: Create Non Levy Account with PAYE Details
Given I create an Account 
When I add paye details
And organisation details
When I do not sign the agreement
Then I will land in the User Home page


@addpayedetails
Scenario: Create Levy Account
Given the following levy declarations with english fraction of 1.00 calculated at 2019-04-15
| Year  | Month | LevyDueYTD | LevyAllowanceForFullYear | SubmissionDate |
| 19-20 | 3     | 45000000   | 60000                    | 2019-05-15     |
Given I create an Account 
When I add paye details
And organisation details
When I do not sign the agreement
Then I will land in the User Home page
