Feature: EI_P3_04_ExistingLevyAc_AddVRF

@regression
@employerincentives
@vrfservice
Scenario: EI_P3_04_ExistingLevyAc_AddVRF
	Given the Employer logins using existing EI Levy Account to add vrf
	Then the Employer can add organisation and finance details
	