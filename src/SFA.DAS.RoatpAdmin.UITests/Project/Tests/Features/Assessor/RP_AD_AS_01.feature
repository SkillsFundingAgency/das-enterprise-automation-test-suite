Feature: RP_AD_AS_01

@roatp
@rpadas01
@roatpassessoradmin
@newroatpadmin
@regression
Scenario: RP_AD_AS_01 Assess a Company type Application via Main provider route
	When the Assessor1 is on the RoATP assessor applications dashboard
	And selects the Main provider route application
	Then the Assessor assesses all the sections of the Main Provider Route application as PASS
	And marks the Application as Ready for moderation
	When the Assessor2 is on the RoATP assessor applications dashboard
	And selects the Main provider route application
	Then the Assessor assesses all the sections of the Main Provider Route application as PASS
	And marks the Application as Ready for moderation