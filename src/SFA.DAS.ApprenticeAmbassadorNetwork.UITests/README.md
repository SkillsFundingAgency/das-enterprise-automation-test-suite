**Pipeline URL** - https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_release?definitionId=405&view=mine&_a=releases

# **ApprenticeAmbassadorNetwork **
Project: This service is about Apprenticeship Ambassador Network, where administrator can manage ambassadors and events for ambassadors(apprentices and employers) to promote the following;
   **develop their skills and experience
   **build their professional network
   **champion apprenticeships in their region and across England
Apprentice - AmbassorNetworkHub(CMAD/AAN): Where apprentice can sign up, confirm their details and join ambassador network 
Employer - AmbassorNetwork(EAS/AAN): Where employer become a member of the network to find relevant events, latest news and networking opportunities
AAN Admin - (ADMINAAN): A hub where Admins can set notifications, manage network events, ambassadors in their region and data on past activities.



## **Prerequisites to run the tests**:
* General prerequisities can be gathered from the Main README.md file (https://github.com/SkillsFundingAgency/das-enterprise-automation-test-suite/blob/master/README.md)
* Provide Feedback secrets are set up (Please refer to the main README.md)

## **Pipelines related to the automation project**
* APP1_das-apprentice-ambassador-network-automation-test-suite

## **Repos related to the service**
* das-admin-aan-web   https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3341
* das-provide-feedback-employer

## **Repos related to APIMs**
* das-aan-hub-api    				https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=2974
* das-apim-endpoints-AdminAAN		https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3334


## **AzureFunctions**
* das-test-aanhubwkr-fa  'EventSignUpNotificationFunction'  publishes emails to ambassordors and Admins after sign up
* das-test-aanhubwkr-fa   'SendNotificationsFunction'       triggers emails to ambassordors and Admins after ambassordors cancel attending or events cancelled


## **Database Information**
* das-(env)-aanhub-db (AmbassadorNetwork)


## **FYI**
* Further details on how apprentice and employer can become ambassadors are in confluence pages 
