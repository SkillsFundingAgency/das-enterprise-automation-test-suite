Feature: RP_AD_AS_02

@roatp
@rpadas02
@roatpassessoradmin
@newroatpadmin
@regression
Scenario: RP_AD_AS_02 Assess a Soletrader type Application via Supporting provider route
	When the Assessor1 is on the RoATP assessor applications dashboard
	And selects the Supporting Provider Route application
	Then the Assessor assesses all the sections of the application as PASS
	And marks the Application as Ready for moderation
	When the Assessor2 is on the RoATP assessor applications dashboard
	And the Assessor2 selects the same application
	Then the Assessor assesses all the sections of the application as PASS
	And marks the Application as Ready for moderation