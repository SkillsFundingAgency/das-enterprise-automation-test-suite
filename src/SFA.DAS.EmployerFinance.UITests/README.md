**Pipeline URL** - https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=332

# Project Name: Employer-Finance
Employer Finance is primarily responsible to test sections available under Finance tab in an Employer Account

## Prerequisites to run the tests:
1. Please refer to main read me which has all the initial setup details
2. Please refer to main read me for User secrets

## Pipelines related to the project
* Regression Automation Suite: E2_das-employer-finance-automation-test-suite
* das-employer-finance
* das-apim-endpoints-EmployerFinance
* das-employer-accounts
* das-apim-endpoints-EmployerAccounts


## Data considerations
In the das-{env}-eas-fin-db

## FYIs
Due to lack of Payments and HMRC integration in our test environments, this suite only check superficial elements. Any complex financail rules & corresponding calculations should be validated via exploratory testing or with actual data in MO environment