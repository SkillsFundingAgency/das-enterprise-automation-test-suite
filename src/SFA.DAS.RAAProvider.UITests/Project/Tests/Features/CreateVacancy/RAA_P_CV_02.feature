Feature: RAA_P_CV_02

@raa	
@raaprovider	
@regression
Scenario: RAA_P_CV_02 - Create a vacancy navigating through all location types and wage types pages
When the Provider creates a vacancy with "all location types" work locations and "all wage types" wage type
Then the Provider can navigate to Manage your recruitment emails page
And the Provider views the recruitment API key
