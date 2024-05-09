Feature: AP_Pro_04_ProviderSelectsFilterAndPaginationOnManageYourApprenticePage

@approvals
@regression
@provideraddapprentice
Scenario: AP_Pro_04 Provider Selects Filter And Pagination
	Given A Provider has navigated to Manage your apprentice page
	When the provider filters by 'Live'
	Then the provider is presented with first page with no filters applied
	And Provider is able to download the results in a csv file
	And Provider can confirm number of rows in Apprentices csv file