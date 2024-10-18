Feature: Notifications

A short summary of the feature

@aan
@aanadmin
@aanadminnotifications
@regression
Scenario: AAN_ADN_N01 User should be able to successfully subscribe to email notification
	Given an admin logs into the AAN portal
	 And user select notification settings on dashboard
     Then the user select Yes for emails and confirm notification saved
