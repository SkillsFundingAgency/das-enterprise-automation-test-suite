Feature: EPAO_AP_04_StageTwoCancelStandard
	
@epao
@epaoapply
@epaostagetwostdcancellation
@regression
Scenario: EPAO_AP_04_StageTwo_CancelStandard
	Given Stage one approved EPAO logs in to apply for a first standard
	When  Starts the journey to apply for the first standard
	Then  EPAO cancels the standard using cancel link as incorrect standard selected	