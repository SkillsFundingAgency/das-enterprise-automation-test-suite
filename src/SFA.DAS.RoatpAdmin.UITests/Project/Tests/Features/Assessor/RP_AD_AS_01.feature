Feature: RP_AD_AS_01

@roatp
@rpadas01
@roatpassessor
@newroatpadmin
@regression
Scenario: RP_AD_AS_01 Assess a Company type Application via Main provider route
	When the Assessor1 is on the RoATP assessor applications dashboard
	Then Assessor1 selects the Main provider route application
	And assesses all the sections of the Main provider application as PASS
	When the Assessor2 is on RoATP assessor applications dashboard
	Then Assessor2 selects the Main provider route application
	And assesses all the sections of the Main provider application as PASS