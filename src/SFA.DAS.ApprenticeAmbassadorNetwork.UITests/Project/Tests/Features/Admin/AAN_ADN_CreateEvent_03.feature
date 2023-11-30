Feature:AAN_ADN_CreateEvent_03

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_CreateEvent_03 User should be able to successfully create and cancel Online event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully create online event
     Then the system should confirm the event creation
     And the user should be able to successfully cancel event
     And the system should confirm the event cancellation