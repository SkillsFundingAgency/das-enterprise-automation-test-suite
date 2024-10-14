**Pipeline URL** - https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_release?_a=releases&view=mine&definitionId=348

# **ProvideFeedback **
Project: This service is about how employer and apprentice give reviews for their Training Programme and can be viewed in FindApprenticeshipTraining and aslo a detail version in Provider portal(Overall and Annual rating)
Apprentice Feedback(CMAD): Where apprentice can sign up, confirm their details and give feedback for their training provider(Note detail can be added by employer/provider) 
Employer Feedback(EAS): Where employer add, manage apprentices and give feedback to their affiliate Training Provider
Provider Feedback page(PAS): Where provider can approve apprentice and also view feedback for both Employer and Apprenitice in table and graphic view
FindApprenticeshipTraining(FAT): Where apprentice can view feedback for Training Provider


## **Prerequisites to run the tests**:
* General prerequisities can be gathered from the Main README.md file (https://github.com/SkillsFundingAgency/das-enterprise-automation-test-suite/blob/master/README.md)
* Provide Feedback secrets are set up (Please refer to the main README.md)

## **Pipelines related to the automation project**
* APP1_das-provide-feedback-automation-test-suite

## **Repos related to the service**
* das-providerfeedback-web   https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3675
* das-provide-feedback-employer

## **Repos related to APIMs**
* das-apim-endpoints-ProviderFeedback  https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=3665
* das-apprentice-feedback-api       https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build?definitionId=2783



## **Database Information**
* das-(env)-appfb-db (ApprenticeFeedback)
* das-(env)-pfbe-db (ProviderFeedback)

## **FYI**
* Note: For apprentice reviews to display for a Training Provider, a set of 5 different apprentices has to give reviews for a particular academic year starting September to August
* A prep test has been implemeted to make sure new apprentice sees their Training Provider in CDAM by updating a table in db(reason is due to 3 weeks laps for apprentice to give initial reviews)
* Further details on how apprentice and employer give feedback are in confluence pages 


