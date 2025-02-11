Feature: FEPAO_Accessibility_02

@accessibility
@findepao
@regression
Scenario: FEPAO_Accessibility_02_Search for Standard With No EPAO
	Given the user searches a standard 'Aerospace manufacturing electrical' term with no EPAO
	Then the user is able to contact ESFA