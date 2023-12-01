Feature:AAN_ADN_06_CreateAndCancelEvent

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_06 User should be able to successfully create and cancel Hybrid event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully create hybrid event
     Then the system should confirm the event creation
     And the user should be able to successfully cancel event
     And the system should confirm the event cancellation