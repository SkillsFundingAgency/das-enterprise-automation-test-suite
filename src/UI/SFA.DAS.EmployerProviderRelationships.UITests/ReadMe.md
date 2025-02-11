**Pipeline URL** - https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?definitionId=415&view=mine&_a=releases

# ProviderRelationships (PR) 
Provider relationships is the service that controls the permissions granted by employers to providers which allow for certain tasks to be carried out by providers on behalf of the employer like creating cohorts and adversts.

## Prerequisites to run the tests:
1. General prerequisities from the Main read me
2. EPR User secrets set up (Please refer to the main read me)
## Pipelines related to the project
* Regression Automation SFA.DAS.EmployerPropviderRelationships.UITests
* P1_das-employer-provider-relationships-automation-test-suite
* Provider web :- das-provider-pr-web
* Employer web :- das-employer-pr-web
* Inner API :-das-pr-api
* Jobs :- das-pr-jobs
* Outer API employer :- das-apim-endpoints-employerPR
* Puter API Provider :- das-apim-endpoints-providerPR
* Database :- das-{env}-prel-db

## Data considerations
None

## FYIs
The Project is still WIP (Full E2E journey's yet to be completed)
