Feature: EmployerNotificationSetting

A short summary of the feature


@regression
Scenario: Employer login and modifies notification settings
Given Employer navigates to Apprentices home page
When Employer navigates to notification settings page
Then Employer is able to choose to receive notification emails
And Employer is able to choose No notification emails