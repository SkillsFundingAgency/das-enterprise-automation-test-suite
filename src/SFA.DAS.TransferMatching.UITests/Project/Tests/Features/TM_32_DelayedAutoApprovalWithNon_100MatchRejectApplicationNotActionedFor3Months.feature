Feature: TM_32_DelayedAutoApprovalWithNon_100MatchRejectApplicationNotActionedFor3Months

@regression
@transfermatching
Scenario:  TM_32 Delayed AutoApproval With Non-100% Match Reject Application Not Actioned For 3 Months   
    Given the levy employer logins using existing transfer matching account 
    Then the levy employer can create anonymous pledge using non default criteria
    Then the levy employer can view pledges from verification page
    When the receiver levy employer applies for the pledge
    Then Application has not been actioned for 3 months
    Then Application should be auto rejected