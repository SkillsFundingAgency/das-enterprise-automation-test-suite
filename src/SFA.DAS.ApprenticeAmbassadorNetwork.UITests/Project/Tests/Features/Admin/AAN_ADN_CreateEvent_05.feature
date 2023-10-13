Feature:AAN_ADN_CreateEvent_05

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_CreateEvent_05 User should be able to successfully create InPerson event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully create inperson event
     Then the system should confirm the event creation