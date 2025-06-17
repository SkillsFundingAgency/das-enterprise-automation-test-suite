**Pipeline URL** - https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=402

# Project Name: Payments Simplification
Payments Simplification serves for the below purposes:
1. a) Simpler data administration to avoid duplicate data entry across multiple systems b) releasing due payments in a timely fashion
2. Flexibility in AS to enhance/modify funding calculation quickly based on emerging policy themes

## Prerequisites to run the tests:
1. Please refer to main read me which has all the initial setup details
2. Please refer to main read me for User secrets
3. Ensure the UKPRN (if using a new one) in use, is whitelisted in das-providercommitments and das-providerapprenticeshipsservice

## Pipelines related to the project
* das-commitments
* das-apim-endpoints-approvals
* das-employercommitments_v2
* das-providercommitments
* das-apprenticeships-approvals-eventhandlers
* das-apprenticeships
* das-apim-endpoints-apprenticeships
* das-apprenticeships-web
* das-funding-apprenticeship-earnings
* das-apim-endpoints-Funding
* das-provider-funding-web

## Dbs related to the project
* Database :- das-{env}-comt-db
* Database :- das-{env}-apps-db
* Database :- das-{env}-funappern-db

## Data considerations
None