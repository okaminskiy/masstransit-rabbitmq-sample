Feature: Templates
	In order to use diferent elements in one page
	I must to be able to choose with which element I will work

@templates
Scenario: Next step
	Given I am in step1
	When I press next
	Then I am in step2
	When I press next
	Then I am in step3
	When I press next
	Then I am in step3
	When I press back
	Then I am in step2
	When I press back
	Then I am in step1
	
	  