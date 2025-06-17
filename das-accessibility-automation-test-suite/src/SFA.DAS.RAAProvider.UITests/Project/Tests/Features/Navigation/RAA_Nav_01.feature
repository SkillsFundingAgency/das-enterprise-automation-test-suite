Feature: RAA_P_Nav_01

@regression
@raaprovider
@raa
Scenario: RAA_P_Nav_01_Navigate to PAS sub sites from Recruit Page
	When the Provider navigates to 'Recruit' Page
	Then the Provider can navigate to Reports page
	Then the Provider can navigate to Manage your recruitment emails page
	And the Provider can navigate to apprentice requests page
	And the Provider can navigate to manage funding page
	And the Provider can navigate to manage your apprentices page
	And the Provider can navigate to organisations and agreements page
	Then the Provider can navigate to recruit notification settings page
	And the Provider can navigate to change your sign in details settings page
