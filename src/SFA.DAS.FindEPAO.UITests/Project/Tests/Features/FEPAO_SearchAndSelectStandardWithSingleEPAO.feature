Feature: FEPAO_SearchAndSelectStandardWithSingleEPAO

@findepao
@regression
Scenario: FEPAO_SASSWSE_01_Search for Standard With Single EPAO
	Given the user searches a standard 'Aerospace engineer (degree)' term with single EPAO
	Then  the user is able to click back to the search apprenticeship page