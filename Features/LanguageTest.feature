Feature: This test suite contains test scenarios for Language Form Tests


Scenario: A. Create a new lungauge record
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	And  I create a new langauge records with values  '<language>' '<level>'
	Then I should see popup message as '<language> has been added to your languages'
	And I should be able to see added language in table  '<language>' '<level>'
	Examples: 
	| language | level  |
	| English  | Fluent |
	| Arabic   | Basic  |

	Scenario:B. Edit an existing language to a new langauge record
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	And I Edit an existing language '<language>' '<level>'  to a new record with values '<newLanguage>' '<newLevel>'
	Then I should see popup message as '<newLanguage> has been updated to your languages'
	And I should be able to see updated language in table  '<newLanguage>' '<newLevel>'
	Examples: 
	| language | newLanguage |  level   |  newLevel        |	
	|  English |   Sinhala   | Fluent   | Conversational   |

	Scenario: C. Cannot be able to add new language without adding language level
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	And I create a new langauge records with value  '<language>' without adding language level 
	Then I should see popup message as 'Please enter language and level'
	
	Examples: 
	| language | 
	| English  | 

	Scenario: D. Cannot be able to add existing language and level as new language 
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	And I create a new langauge records with values  '<language>' '<level>'
	Then I should see popup message as 'This language is already exist in your language list'
	
	Examples: 
	| language | level |
	| Arabic   | Basic |

	Scenario:E. Edit an existing language to a new langauge record without editing language level
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	And I Edit an existing language '<language>'to a new langauge record with value '<newLanguage>' without editng language level 
	Then I should see popup message as '<newLanguage> has been updated to your languages'
	And I should be able to see updated language in table  '<newLanguage>' '<level>'
	Examples: 
	| language | newLanguage |  level           |  
	|  Sinhala |    Spanish  | Conversational   |

	Scenario:F. Edit an existing language level record without editing language 
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	And I Edit an existing language '<language>' to a new langauge record by editing language level record form '<level>' to '<newLevel>' without editng language 
	Then I should see popup message as '<language> has been updated to your languages'
	And I should be able to see updated language in table  '<language>' '<newLevel>'
	Examples: 
	| language | level           | newLevel |  
	|  Spanish | Conversational  | Fluent   |

	Scenario:G. Edit an existing language and level to another existing language record
	Given I login to Mars
	Then  I navigate to profile page and language tab shoud be selected 
	And I Edit an existing language '<language>' '<level>' to another existing langauge record with values  '<newLanguage>' '<newLevel>'
	Then I should see popup message as 'This language is already added to your language list.'	
	Examples: 
	| language | newLanguage |level  | newLevel |
	| Arabic   | Spanish     | Basic | Fluent   |
	
