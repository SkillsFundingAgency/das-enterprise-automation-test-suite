Feature: AP_Pro_04_ProviderSelectsFilterAndPaginationOnManageYourApprenticePage

@approvals
@regression
Scenario: AP_Pro_04 Provider Selects Filter And Pagination
	Given A Provider has navigated to Manage your apprentice page
	When the provider filters by 'Live'
	Then the provider is presented with first page with no filters applied

	

