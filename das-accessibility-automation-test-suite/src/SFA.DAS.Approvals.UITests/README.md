**Pipeline URL** - 
* https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=300
* https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=409
* https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=408

# Project Name: Approvals
Approvals journeys deal with onboarding apprentices by capturing their personal (name, DoB, Email etc) and course related (course, start & end date, cost etc) information and get it approved by both the Employer and Training Provider. 
The Post-Approval parts deal with change of circumstances in an apprenticeship record e.g. changing name, dob, employer or provider etc.

## Prerequisites to run the tests:
1. Please refer to main read me which has all the initial setup details
2. Please refer to main read me for User secrets

## Pipelines related to the project
* Regression Automation Suite: E2_das-approvals-automation-test-suite | E2_das-post-approvals-automation-test-suite | E2_das-flexijob-apprenticeship-agency-automation-test-suite
* das-commitments
* das-employercommitments-v2
* das-providerapprenticeshipservice
* das-providercommitments
* das-provider-relationships
* das-reservations
* das-reservations-api
* das-reservations-jobs
* das-apim-endpoints-Approvals
* das-apim-endpoints-Reservations
* das-apim-endpoints-RoatpCourseManagement
* das-pr-api
* das-pr-jobs
* das-employer-pr-web
* das-apim-endpoints-ProviderPR



## Data considerations
* das-{env}-comt-db
* das-{env}-rsrv-db
* das-{env}-prel-db

## FYIs
Please refer to following wiki document for its release process:
* https://skillsfundingagency.atlassian.net/wiki/spaces/NDL/pages/4105732145/Approvals+WOW