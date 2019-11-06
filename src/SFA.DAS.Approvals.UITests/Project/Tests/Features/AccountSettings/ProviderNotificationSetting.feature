@approvals
Feature: ProviderNotificationSetting

@regression
Scenario: Provider login and modifies notification settings
	Given Provider navigates to notification settings page
	Then Provider is able to choose to receive notification emails
	And Provider is able to choose No notification emails