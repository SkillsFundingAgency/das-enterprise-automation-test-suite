**Pipeline URL** - https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=414

# **Early Connect GAA - StudentSurveyForm (EC UCAS and Non UCAS)**
Project: The service is about how UCAS and Non UCAS(Others) students will share their data with Apprenticeship Service and how we process them and support the student’s apprenticeship journeys
Currently triaged in three regions in England with their respective LepsCode
North East  
Lancashire 
London*   
 

## **Prerequisites to run the tests**:
* General prerequisities can be gathered from the Main README.md file (https://github.com/SkillsFundingAgency/das-enterprise-automation-test-suite/blob/master/README.md)
* Earlyconnect User secrets are set up (Please refer to the main README.md) Note. For subscription keys for APIM Environments please ask DevOps

## **Pipelines related to the automation project**
* APP1_das-EarlyConnectStudentTriageForms
* APP1_das-earlyconnect-api-automation-test-suite

## **Repos related to the service**
* das-earlyconnect-web   https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3541

## **Repos related to APIMs**
* das-apim-endpoints-EarlyConnect(OuterAPI) https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3495
* das-earlyconnect-api(Inner API)  https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3463
* das-earlyconnect-jobs  https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3542


## **Database Information**
* das-(env)-earlycon-db (Earlyconnect)

## **FYI**
* Testing requires a unique email address of students therefore make use of mailosaur account where an OTP is sent for authenication
* UCAS students data is consumed from Earlyconnect APIs
* Schedule email is sent to uncompleted applications as reminders