Feature: AAN_A_02_NegativePath

@aan
@aanaprentice
@aan05
@aanreset
@regression
  Scenario: AAN_A_02_NegativePath User details are not in Staged Apprentice Record
   	Given the non Private beta apprentice logs into AAN portal
    Then an Access Denied page should be displayed
