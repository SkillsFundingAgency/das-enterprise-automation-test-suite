Feature: RP_AD_AS_03

@roatp
@rpadas03
@roatpassessor
@roatpassessoradmin
@newroatpadmin
@regression
Scenario: RP_AD_AS_03 Assess a Charity type Application via Employer provider route
	When the Assessor1 is on the RoATP assessor applications dashboard
	And selects the Employer provider route application
	Then the Assessor assesses all the sections of the Employer Provider Route application as PASS
	And marks the Application as Ready for moderation
	When the Assessor2 is on the RoATP assessor applications dashboard
	And selects the Employer provider route application
	Then the Assessor assesses all the sections of the Employer Provider Route application as PASS
	And marks the Application as Ready for moderation