Feature: MS_04_TribalUpdateProviderInfo

@managingstandards
@regression
Scenario: MS_04_TribalUpdateProviderInfo
	Given the tribal user searches for provider with UKPRN
	When the tribal user chooses to change the provider details
	Then the tribal user is allowed to make the change