Feature: Notifications

As an AAN Admin User
I want to be able to access and update my notification settings
So that I can update my email preferences if required.

@aan
@aanadmin
@aanadminnotifications
@regression
Scenario: AAN_ADN_N01 User should be able to successfully subscribe to email notification
	Given an admin logs into the AAN portal
	 And user select notification settings on dashboard
     Then the user select Yes for emails and confirm notification saved


@aan
@aanadmin
@aanadminnotifications
@regression
Scenario: AAN_ADN_N02 User should be able to unsuccessfully subscribe to email notification
 Given an admin logs into the AAN portal
 And user select notification settings on dashboard
 Then the user select No for emails and confirm notification saved
