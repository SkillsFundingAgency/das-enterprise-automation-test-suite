Feature: MS_03_AddDeleteStandard

@managingstandards
@managingstandards05
@regression
Scenario: MS_03A_Add_Delete_Standard
	Given the provider logs into portal
	When the provider is able to add the standard delivered in one of the training locations
	And the provider is able to delete the standard
	