Feature: This test suite contains test scenarios for Skill Form Tests


Scenario: A. Create a new skill record
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And  I create a new skill record with values '<skill>' '<level>'
	Then I should see popup message as '<skill> has been added to your skills'
	And I should be able to see added skill in table  '<skill>' '<level>'
	Examples: 
	| skill | level        |
	|QA     | Intermediate |
	| C#    | Beginner     |

	Scenario:B. Edit an existing skill to a new skill record
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And I Edit an existing skill to a new skill record with values '<skill>' '<level>'
	Then I should see popup message as '<skill> has been updated to your skills'
	And I should be able to see updated skill in table  '<skill>' '<level>'
	Examples: 
	| skill | level          |
	|Java  | Expert |

	Scenario: C. Cannot be able to add new skill without adding skill level
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And I create a new skill record with value '<skill>' without adding skill level 
	Then I should see popup message as 'Please enter skill and level'
	
	Examples: 
	| skill  | 
	| Python | 

	Scenario: D. Cannot be able to add existing skill and level as new skill 
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And I create a new skill record with values '<skill>' '<level>'
	Then I should see popup message as 'This skill is already exist in your skill list.'
	
	Examples: 
	| skill | level |
	| Java  | Expert |

	Scenario:E. Edit an existing skill to a new skill without editing skill level
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And I Edit an existing skill to a new skill record with value '<skill>' without editng skill level 
	Then I should see popup message as '<skill> has been updated to your skills'
	And I should be able to see updated skill in table '<skill>' '<level>'
	Examples: 
	| skill | 
	| QA    | 

	Scenario:F. Edit an existing skill level record without editing skill 
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And I Edit an existing skill with skill level value '<level>' without editng skill  
	Then I should see popup message as '<skill> has been updated to your skills'
	And I should be able to see updated skill in table '<skill>' '<level>'
	Examples: 
	| level  | 
	| Basic  | 

	Scenario:G. Edit an existing skill and level to another existing skill record
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And I Edit an existing skill to another existing skill record with values '<skill>' '<level>'
	Then I should see popup message as 'This skill is already added to your skill list.'
	And I should be able to see updated skill in table  '<skill>' '<level>'
	Examples: 
	| language| level |
	| Arabic  | Fluent|

	Scenario: H. Delete an existing skill
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	Then I click on the skill tab
	And I delete existing skill