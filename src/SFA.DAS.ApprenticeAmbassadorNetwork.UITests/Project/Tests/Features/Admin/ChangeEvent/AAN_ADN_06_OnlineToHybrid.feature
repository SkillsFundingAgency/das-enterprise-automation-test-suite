Feature:AAN_ADN_06_OnlineToHybrid

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_05 User should be able to successfully change Online to Hybrid event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully enters all the details for an Online event
     And changes the event to a hybrid event
     Then the system should confirm the event creation