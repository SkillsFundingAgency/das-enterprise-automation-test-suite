Feature: AAN_02_NegativePath

@aan
@aan05
@aanreset
@regression
  Scenario: AAN_02_NegativePath User details are not in Staged Apprentice Record
   	Given the non Private beta provider logs into AAN portal
    Then an Access Denied page should be displayed
