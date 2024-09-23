**Pipeline URL** - https://sfa-gov-uk.visualstudio.com/Digital%20Apprenticeship%20Service/_release?definitionId=322&view=mine&_a=releases

# Apply to join the apprenticeship provider and assessment register (APAR)
Service that manages the registration of training providers

## Prerequisites to run the tests:
1. General prerequisities from the Main read me
2. ROATP User secrets set up (Please refer to the main read me)

## Pipelines related to the project
* Regression Automation SFA.DAS.RoATP.UITests
* das-roatp-automation-test-suite
* QNA (Question and Answer Service): das-qna-api (NOTE: Shared with EPAO/CI team)
* Apply Service : das-apply-service 
* Roatp Service: das-roatp-service 
* Administration dashboard: das-admin-service (NOTE: Shared with EPAO/CI team)
* Gateway services: das-roatp-gateway 
* Financial: das-roatp-finance 
* Assessor Services: das-roatp-assessor 
* Oversight Services: das-roatp-oversight 
* Lookup services: 
* Charities API: das-charities-api 
* Other repositories that are the responsibility of the RoATP Team:
* roatp daily functions: das-roatp-functions 
* Download service: das-download-service 
* das-{env}-qna-db
* das-{env}-roatp-db
* das-{env}-apply-db


## Data considerations
None

## FYIs
* Download service is a code repository for a public-facing download service for RoATP and RoEPAO.
* See Public Download of Registers (RoATP and RoEAPO)  for more details
* For Prod Data fix scripts please follow the below link
https://skillsfundingagency.atlassian.net.mcas.ms/wiki/spaces/NDL/pages/3530752166/Data+Fixes+for+Live+Support