Feature:AAN_ADN_CreateEvent_04

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_CreateEvent_04 User should be able to successfully create InPerson School event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully create inperson school event
     Then the system should confirm the event creation