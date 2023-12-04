Feature:AAN_ADN_02_HybridToInPerson

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_02 User should be able to successfully change Hybrid to In Person event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully enters all the details for hybrid event
     And changes the event to a in person event
     Then the system should confirm the event creation