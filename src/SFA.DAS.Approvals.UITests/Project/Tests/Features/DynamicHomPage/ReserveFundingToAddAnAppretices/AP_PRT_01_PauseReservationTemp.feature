Feature: AP_PRT_01_PauseReservationTemp
	As a NonLevy Employer, I can't able to reserve funding due to temporary pause 


@regression
@dynamichomepage
@addnonlevyfunds
@pausereservation
Scenario: AP_PRT_01 Pause Reservation Temporary
	Given The User creates NonLevyEmployer account and sign an agreement
	Then The NonLevyEmployer reserves funding should able to see pause message  
	