Feature: CheckPreparingAndMonitoring
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 


@regression
Scenario: Check the Preparing And Monitoring Link
	Given I navigate to Fire It Up home page
	And I launch Preparing And Monitoring page
	Then I verify the title for Preparing And Monitoring page
