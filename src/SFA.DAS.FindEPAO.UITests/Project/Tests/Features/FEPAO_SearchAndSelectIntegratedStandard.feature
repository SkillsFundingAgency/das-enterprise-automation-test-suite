Feature: FEPAO_SearchAndSelectIntegratedStandard

@fepao
@regression
Scenario: FEPAO_SASIS_01_Search For An Integrated Standard
	Given the user searches an integrated standard 'Dental nurse' term
	Then  the user is able to click back from integrated apprenticeship page