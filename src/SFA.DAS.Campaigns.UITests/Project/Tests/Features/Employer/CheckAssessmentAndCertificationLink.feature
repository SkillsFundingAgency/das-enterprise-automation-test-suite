Feature: CheckAssessmentAndCertificationLink
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 

@campaigns
@regression
Scenario: Check the Assessment And Certification Link
	Given I navigate to Fire It Up home page
	And I click on th Employer option in the Menu header
	And I launch Assessment And Certification page
	Then I verify the title for Assessment And Certification page
