Feature: RE_PR_02

@regression
@registration
@addnonlevyfunds
@providerleadregistration
Scenario: RE_PR_02 Provider Lead Registration
	Given the provider invite an employer
	Then the invited employer status in "Account creation not started"
	And change the details before resend invitation for status "Account creation not started"
