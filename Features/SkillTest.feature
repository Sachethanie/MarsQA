Feature: This test suite contains test scenarios for Skill Form Tests

Scenario: A. Create a new skill record		
	Given I select skills tab
	Then  I create a new skill records with values  '<skill>' '<level>'
	Then I should see popup message as '<skill> has been added to your skills'
	And I should be able to see added skill in table '<skill>' '<level>'
	Examples: 
	| skill | level        |
	| QA    | Intermediate |
	| C#    | Beginner     |

	Scenario:B. Edit an existing skill to a new skill record	
	Given I select skills tab
	Then I Edit an existing skill '<skill>' '<level>'  to a new record with values '<newSkill>' '<newLevel>'
	Then I should see popup message as '<newSkill> has been updated to your skills'
	And I should be able to see updated skill in table  '<newSkill>' '<newLevel>'
	Examples: 
	| skill | newSkill |  level       | newLevel |	
	|  QA   |   Java   | Intermediate | Expert   |

	Scenario: C. Cannot be able to add new skill without adding skill level		
	Given I select skills tab
	Then I create a new skill records with value  '<newSkill>' without adding skill level 
	Then I should see popup message as 'Please enter skill and experience level'
	
	Examples: 
	| newSkill | 
	| QA       | 

	Scenario: D. Cannot be able to add existing skill and level as new skill 	
	Given I select skills tab
	Then I create a new skill records with values  '<newSkill>' '<newLevel>'
	Then I should see popup message as 'This skill is already exist in your skill list.'
	
	Examples: 
	| newSkill | newLevel |
	| C#       | Beginner |

	Scenario:E. Edit an existing skill to a new skill record without editing skill level	
	Given I select skills tab
	Then I Edit an existing skill '<skill>'to a new skill record with value '<newSkill>' without editng skill level 
	Then I should see popup message as '<newSkill> has been updated to your skills'
	And I should be able to see updated skill in table  '<newSkill>' '<level>'
	Examples: 
	| skill | newSkill |  level |  
	|  Java |    QA    | Expert |

	Scenario:F. Edit an existing skill level record without editing skill 	
	Given I select skills tab
	Then I Edit an existing skill '<skill>' to a new skill record by editing skill level record '<level>' to '<newLevel>' without editng skill 
	Then I should see popup message as '<skill> has been updated to your skills'
	And I should be able to see updated skill in table  '<skill>' '<newLevel>'
	Examples: 
	| skill | level  | newLevel     |  
	| QA    | Expert | Intermediate |

	Scenario:G. Edit an existing skill and level to another existing skill record	
	Given I select skills tab
	Then I Edit an existing skill '<skill>' '<level>' to another existing skill record with values '<newSkill>' '<newLevel>'
	Then I should see popup message as 'This skill is already added to your skill list.'	
	Examples: 
	| skill | newSkill |level         | newLevel |
	| QA    | C#       | Intermediate | Beginner |

	Scenario: H. Delete an existing skill		
	Given I select skills tab
	Then I successfully delete existing skill '<skill>'
	Then I should see popup message as '<skill> has been deleted'	
	And I should not be able to see deleted skill in table '<skill>'
	Examples: 
	| skill |
	| QA    |
	| C#    |

	