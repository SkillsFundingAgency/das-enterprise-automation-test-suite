Feature: FEPAO_SearchAndSelectIntegratedStandard

@findepao
@regression
Scenario: FEPAO_SASIS_01_Search For An Integrated Standard
	Given the user searches an integrated standard 'Dental nurse (integrated)' term
	When the user selects an EPAO from the list
	And the user clicks on view other end point organisations
	Then  the user is able to click back to homepage