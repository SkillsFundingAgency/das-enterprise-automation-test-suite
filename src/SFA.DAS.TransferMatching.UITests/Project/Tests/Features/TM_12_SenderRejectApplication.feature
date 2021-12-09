Feature: TM_12_SenderRejectApplication

@regression
@transfermatching
Scenario: TM_12_SenderRejectApplication
  Given the levy employer logins using existing transfer matching account
  And the levy employer can create pledge using default criteria
  When the levy employer can view pledges from verification page
  Then the receiver levy employer applies for the pledge
  And the levy employer can reject the application
