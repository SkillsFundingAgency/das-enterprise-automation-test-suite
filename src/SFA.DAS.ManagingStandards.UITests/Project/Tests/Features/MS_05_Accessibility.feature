Feature: MS_05_Accessibility

@managingstandards
@managingstandards05
@accessibility
Scenario: MS_05_Accessibility_Test
	Given the provider logs into employer portal
	When the provider navigates to Review your details 
	And the provider is able to add the standard delivered in one of the training locations
	And the provider is able to delete the standard
	