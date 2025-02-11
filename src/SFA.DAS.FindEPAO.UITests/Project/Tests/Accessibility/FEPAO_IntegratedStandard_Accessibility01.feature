Feature: FEPAO_IntegratedStandard_Accessibility01


@accessibility
@findepao
@regression
Scenario: FEPAO_SASIS_01_Search For An Integrated Standard
	Given the user searches an integrated standard 'Dental nurse (integrated)' term
	When the user selects an EPAO from the list
	Then the user clicks on view other end point organisations