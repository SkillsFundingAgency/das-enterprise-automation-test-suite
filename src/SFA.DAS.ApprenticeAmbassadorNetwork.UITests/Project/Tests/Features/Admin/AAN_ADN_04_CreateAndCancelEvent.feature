Feature:AAN_ADN_04_CreateAndCancelEvent

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_04 User should be able to successfully create and cancel InPerson School event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully create inperson school event
     Then the system should confirm the event creation
     And the user should be able to successfully cancel event
     And the system should confirm the event cancellation