Feature: EI_ESD_01

@regression
@employerincentives
@addlevyfunds
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
@addlevyfunds
Scenario: Employer enters an invalid employment start date for phase 2 and a phase 3 apprenticeships
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 10 and Year 2021
	And the Provider approves the apprenticeship request
	And the Employer selects those apprentices on an incentive application
	And the Employer enters an employment start date of '31/03/2021' for the first learner
    And the Employer enters an employment start date of '01/02/2022' for the second learner
	When the Employer selects Continue
	Then the Ineligible Employment Start Date page is displayed
	And the Cancel Application button is displayed

@regression
@employerincentives
@addlevyfunds
Scenario: Employer enters an employment start date in the phase 3 window for a phase 2 commitment
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 09 and Year 2021
	And the Provider approves the apprenticeship request
	And the Employer selects the apprentice on an incentive application
	And the Employer enters an employment start date of '01/10/2021' for the first learner
    When the Employer selects Continue
	Then the Ineligible Employment Start Date page is displayed
	And the Cancel Application button is displayed

@regression
@employerincentives
@addlevyfunds
Scenario: Employer enters an invalid  and valid employment start date in the phase 3 window for a phase 3 commitment
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 12 and Year 2021
	And the Provider approves the apprenticeship request
	And the Employer selects the apprentice on an incentive application
	And the Employer enters an employment start date of '30/09/21' for the first learner
    And the Employer enters an employment start date of '01/10/21 ' for the second learner
	When the Employer selects Continue
    Then the Confirm Apprenticeships page is displayed

@regression
@employerincentives
@addLevyFunds
Scenario: Employer enters an invalid  and valid employment start date in the phase 2 window for a phase 2 commitment
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 09 and Year 2021
	And the Provider approves the apprenticeship request
	And the Employer selects the apprentice on an incentive application
	And the Employer enters an employment start date of '30/9/21' for the first learner
    And the Employer enters an employment start date of '01/12/21 ' for the second learner
	When the Employer selects Continue
    Then the Confirm Apprenticeships page is displayed