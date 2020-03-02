Feature: AP_CoC_08

@mytag
Scenario: AP_CoC_08ProviderEditsApprenticeDobAndReferenceAndChangesPersist
	Given the Employer has approved apprentice
	When the provider edits Name Dob and Reference
	And the employer accepts these changes
	Then the changes should be displayed on the view apprentice page
