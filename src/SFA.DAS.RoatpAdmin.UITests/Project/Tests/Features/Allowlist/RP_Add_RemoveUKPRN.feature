Feature: RP_Add_RemoveUKPRN


@roatp
@roatpadmin
@newroatpadmin
@rpallowlist
@rpadallowlist01
@regression
Scenario: RP_AD_Add_Remove_Validate_UKPRN_In_Allowlist_Table
	Given the admin lands on the Dashboard 
	When the admin access the Allowlist
	Then the admin is able to add a ukprn to Allow list 
	And the admin is not able to add a ukprn exists in allow list
	And the admin is able to remove a ukprn from the allow list
