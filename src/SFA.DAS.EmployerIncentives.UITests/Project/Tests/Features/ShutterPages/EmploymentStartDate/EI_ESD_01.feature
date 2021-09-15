Feature: EI_ESD_01

@regression
@employerincentives
@addLevyFunds
Scenario: Employer enters valid employment start date for phase 2 and a phase 3 apprenticeships
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 10 and Year 2021
	And the Provider approves the apprenticeship request
	And the Employer selects those apprentices on an incentive application
	And the Employer enters an employment start date of '30/09/2021' for the first learner
    And the Employer enters an employment start date of '01/10/2021' for the second learner
	When the Employer selects Continue
	Then the Confirm Apprenticeships page is displayed

@regression
@employerincentives
@addLevyFunds
Scenario: Employer enters an invalid employment start date for phase 2 and a phase 3 apprenticeships
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 10 and Year 2021
	And the Provider approves the apprenticeship request
	And the Employer selects those apprentices on an incentive application
	And the Employer enters an employment start date of '31/03/2021' for the first learner
    And the Employer enters an employment start date of '01/02/2021' for the second learner
	When the Employer selects Continue
	Then the Ineligible Employment Start Date page is displayed