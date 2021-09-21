Feature: EI_ESD_02
    Show new agreement shutter page

@regression
@employerincentives
@addLevyFunds
Scenario: Employer on version 6 enters invalid employment start date for phase 2 legal Agreement
    Given an Employer creates a Levy Account and Signs the Agreement version 6
    And the Employer adds an apprentices Aged16to24 as of 01AUG2020 with start date as Month 10 and Year 2021
    And the Provider approves the apprenticeship request
    And the Employer selects those apprentices on an incentive application
    And the Employer enters an employment start date of '01/10/2021' for the first learner - eligible = 'true'
    When the Employer selects Continue
    Then the New Agreement Version needs signing page is displayed

@regression
@employerincentives
@addLevyFunds
Scenario: Employer on version 7 enters invalid employment start date for phase 3 legal Agreement
    Given an Employer creates a Levy Account and Signs the Agreement version 7
    And the Employer adds an apprentices Aged16to24 as of 01AUG2020 with start date as Month 10 and Year 2021
    And the Provider approves the apprenticeship request
    And the Employer selects those apprentices on an incentive application
    And the Employer enters an employment start date of '01/02/2022' for the first learner - eligible = 'false'
    When the Employer selects Continue
    Then the Ineligible Employment Start Date page is displayed
    And the Cancel Application button is displayed

@regression
@employerincentives
@addLevyFunds
Scenario: Employer on version 7 enters valid employment start date for phase 3 legal Agreement 
    Given an Employer creates a Levy Account and Signs the Agreement version 7
    And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 11 and Year 2021
    And the Provider approves the apprenticeship request
    And the Employer selects those apprentices on an incentive application
    And the Employer enters an employment start date of '30/10/2021' for the first learner - eligible = 'true'
    And the Employer enters an employment start date of '31/12/2021' for the second learner - eligible = 'true'
    When the Employer selects Continue
    Then the Confirm Apprenticeships page is displayed

@regression
@employerincentives
@addLevyFunds
Scenario: Employer on version 6 enters valid employment start date for phase 2 and a phase 3 apprenticeships
   Given an Employer creates a Levy Account and Signs the Agreement version 6
    And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 10 and Year 2021
    And the Provider approves the apprenticeship request
    And the Employer selects those apprentices on an incentive application
    And the Employer enters an employment start date of '01/04/2021' for the first learner - eligible = 'true'
    And the Employer enters an employment start date of '31/01/2022' for the second learner - eligible = 'true'
    When the Employer selects Continue
    Then the New Agreement Version needs signing page is displayed