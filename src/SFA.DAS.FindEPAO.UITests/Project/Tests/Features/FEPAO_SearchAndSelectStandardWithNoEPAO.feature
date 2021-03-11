Feature: FEPAO_SearchAndSelectStandardWithNoEPAO

@findepao
@regression
Scenario: FEPAO_SASSWNE_01_Search for Standard With No EPAO
	Given the user searches a standard 'Aerospace manufacturing electrical' term with no EPAO
	Then the user is able to contact ESFA