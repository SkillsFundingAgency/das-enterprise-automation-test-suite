Feature:AAN_ADN_01_HybridToOnline

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_01 User should be able to successfully change Hybrid to Online event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully enters all the details for hybrid event
     And changes the event to an online event
     Then the system should confirm the event creation