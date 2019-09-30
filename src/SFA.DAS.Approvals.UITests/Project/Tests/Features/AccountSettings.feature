Feature: AccountSettings

A short summary of the feature


@regression
Scenario: Employer navigates to all settings pages and modifies notification settings
Given Employer navigates to Apprentices home page
Then Employer should be able to navigate to help page
When Employer revisited Apprentices home page
Then Employer should be able to navigate to Your accounts page
When Employer revisited Apprentices home page
Then Employer should be able to navigate to Rename account page
When Employer revisited Apprentices home page
Then Employer should be able to navigate to Change your password page
When Employer revisited Apprentices home page
Then Employer should be able to navigate to Change your email address page
When Employer revisited Apprentices home page
Then Employer should be able to navigate to Notigication settings page
And Employer is able to choose to receive notification emails
And Employer is able to choose No notification emails
When Employer revisited Apprentices home page

@regression
Scenario: Provider login and modifies notification settings
Given Provider navigates to notification settings page
Then Provider is able to choose to receive notification emails
And Provider is able to choose No notification emails
