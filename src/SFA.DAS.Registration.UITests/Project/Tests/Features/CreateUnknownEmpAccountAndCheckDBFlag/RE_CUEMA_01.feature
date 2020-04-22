Feature: RE_CUEMA_01

@regression
@registration
@addpayedetails
Scenario: RE_CUEMA_01_Create unknown employer account and verify DB flag
	Given an Employer creates an Account by skipping the add PAYE part
	Then ApprenticeshipEmployerType in Account table is marked as 2