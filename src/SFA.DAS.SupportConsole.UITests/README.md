**Pipeline URL** - https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=308

# Project Name: Support-Console
Support Console is a backoffice app, used to serve customers (employers and providers) about day to day issues related to their accounts, finances & commitments (apprenticeships)

## Prerequisites to run the tests:
1. Please refer to main read me which has all the initial setup details
2. Please refer to main read me for User secrets

## Pipelines related to the project
* Regression Automation Suite: P2_das-support-console-automation-test-suite
* das-employerapprenticeshipsservice
* das-employer-accounts
* das-apim-endpoints-EmployerAccounts
* das-employer-finance
* das-apim-endpoints-EmployerFinance
* das-commitments
* das-apim-endpoints-Approvals


## Data considerations
* das-{env}-eas-acc-db
* das-{env}-eas-fin-db
* das-{env}-comt-db

## FYIs
This service is only available in TEST & PP environment