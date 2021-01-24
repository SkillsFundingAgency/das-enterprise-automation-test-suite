Feature: FEPAO_SearchAndSelectStandardWithEPAO

@fepao
@regression
Scenario: FEPAO_SASSWE_01_Search for Standard With EPAO
	Given the user searches a standard with 'software tester' term
	Then the user selects an EPAO from the list