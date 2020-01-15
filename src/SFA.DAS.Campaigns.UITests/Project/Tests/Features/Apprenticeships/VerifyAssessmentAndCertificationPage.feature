Feature: VerifyAssessmentAndCertificationPage
	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

@campaign
@regression
Scenario: Check all the links and content of ASSESSMENT AND CERTIFICATION screen
	Given I navigate to Fire It Up home page
	And I launch the Find An Apprentice page
	And I Focus on the link Getting Started link
	And I launch the Assessment And Certification page
	Then I verify the content under Get assured and get your certificate section
	Then I verify the content under Complete your apprenticeship section