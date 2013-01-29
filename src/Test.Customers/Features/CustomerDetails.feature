Feature: CustomerDetails
	In order to other users must to have my all needed information about me. 
	I want to save it

Scenario: SavingDetails
	Given I open the details page
	When I input
		 | FirstName  | LastName   | EmailAdress          | Age | Location      |
		 | Oleg       | Kaminskiy  | olkorule333@mail.ru  | 21  | Kiev, Ukrain  |
	And I press submit
	Then the result should be success on the screen
	Then  my details added to DataBase
