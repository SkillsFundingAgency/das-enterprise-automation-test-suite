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
Scenario: Create Levy Account with PAYE Details
Given the following Levy Declarations
| Year  | Month | LevyDueYTD | LevyAllowanceForFullYear | SubmissionDate |
| 17-18 | 1     | 45000000   | 60000                    | 2017-05-15     |
Given I create an Account 
When I add paye details
And organisation details
When I do not sign the agreement
Then I will land in the User Home page
