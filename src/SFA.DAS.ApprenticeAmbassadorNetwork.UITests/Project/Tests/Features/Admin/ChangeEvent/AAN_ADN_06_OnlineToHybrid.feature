Feature:AAN_ADN_06_OnlineToHybrid

@aan
@aanadmin
@aanadmincreateevent
@aanadminchangeevent
@regression
Scenario: AAN_ADN_05 User should be able to successfully change all the event and from Online to Hybrid event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully enters all the details for an Online event
     And changes all the event details
     And changes the event to a hybrid event
     Then the system should confirm the event creation