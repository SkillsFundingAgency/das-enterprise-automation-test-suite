Feature: FAT_CheckBackLinksInTrainingProviderSearch_01

@fat
@regression
Scenario: FAT_BLTPS_01_Validate BackLinks in Training Provider search journey
	Given the User has searched only for a Training Provider by querying Northampton
	Then User is able to navigate back to the beginning of the Training Provider search