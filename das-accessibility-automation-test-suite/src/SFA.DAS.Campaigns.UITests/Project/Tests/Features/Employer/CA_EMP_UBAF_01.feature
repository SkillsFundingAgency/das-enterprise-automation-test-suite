Feature: CA_EMP_UBAF_01

As the apprenticeship service 

I want to update the calculation for estimating benefit funding used by the Understanding apprenticeship funding and benefits screen (UBAF) 

So that changes to policy are correctly reflected

@campaigns
@employer
@regression
Scenario: CA_EMP_UBAF_01 Verify non levy select under 3 million and calculate results
	Given the user navigates to the Understanding Apprentice benefit and funding page make selection under three million
	
	
