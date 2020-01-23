Feature: RegisterMyInterest
	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can Register My Interest

@campaigns
@regression
Scenario: User Wants To Register My Interest on The Fire It Up Site
	Given I navigate to Fire It Up home page
	And I Click On The Register My Interest Button
	And I Enter My First Name, Last Name And Email
	And I Tick The Radio Button For I Want to Become An Apprentice
	And I Tick The Check Box for To Recieve More Information Via Email
	And I Click The Register My Interest Button
	Then I Should Recieve a Success Message
