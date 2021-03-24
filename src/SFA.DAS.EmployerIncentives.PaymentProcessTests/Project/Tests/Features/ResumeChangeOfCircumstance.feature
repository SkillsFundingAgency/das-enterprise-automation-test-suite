Feature: ResumeLearningChangeOfCircumstance
    Learnering resumes after a pause

@employerincentivesPaymentsProcess
Scenario: Resume 1 - Learner Stopped COC triggered and then Resumed in later period 
    Given an existing apprenticeship incentive with learning starting on 15-Oct-2020 and ending on 31-Jul-2021
    And a payment of £1000 sent in Period R06 2021
    When Learner data is updated with PE End Date which is before the due date of the paid earning in Period R08 2021
    And the Learner Match is run in Period R08 2021
    And the Unpaid Earnings are Archived
    And the paid earnings of £1000 is marked as required a clawback in the currently active Period R08 2021
    And Learner data is updated with PriceEpisode Start Date which is on or after Previous PE start date AND on or before the Previous PE end date
    And the Learner Match is run in Period R08 2021
    And ILR Learner Resumed COC is occurred in Period R08 2021
    And the Learner Match is run in Period R08 2021
    And the earnings are recalculated
    Then a new first pending payment of £1000 is created for Period R10 2021
    Then a new second pending payment of £1000 is created for Period R07 2122
