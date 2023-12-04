Feature:AAN_ADN_04_InPersonToOnline

@aan
@aanadmin
@aanadmincreateevent
@regression
Scenario: AAN_ADN_04 User should be able to successfully change In Person to Online event
	 Given an admin logs into the AAN portal
     When the user should be able to successfully enters all the details for InPerson event
     And changes the event to an online event
     Then the system should confirm the event creation