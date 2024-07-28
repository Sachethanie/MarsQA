using MarsQA.Pages;
using RazorEngine;
using System.Reflection.Emit;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class SkillTestStepDefinitions

    {
       private SkillPage skillPage;
        private readonly ScenarioContext _scenarioContext;
       
        public SkillTestStepDefinitions(ScenarioContext scenarioContext)
        {
            this.skillPage = new SkillPage();
            _scenarioContext = scenarioContext;
        }

        [Given(@"I select skills tab")]
        public void ThenISelectSkillsForm()
        {
            SkillPage.NavigateToSkillForm();
        }

        [Then(@"I create a new skill records with values  '([^']*)' '([^']*)'")]
        public void ThenICreateANewSkillRecordsWithValues(string skill, string level)
        {
            skillPage.SuccessfullyAddNewSkill(skill, level);
            _scenarioContext["Skill"] = skill;
        }

        [Then(@"I create a new skill records with values  '([^']*)' '([^']*)' again")]
        public void ThenICreateANewSkillRecordsWithValuesAgain(string skill, string level)
        {
            skillPage.SuccessfullyAddNewSkill(skill, level);
            _scenarioContext["Skill"] = skill;
        }


        [Then(@"I should be able to see added skill in table '([^']*)' '([^']*)'")]
        public void ThenIShouldBeAbleToSeeAddedSkillInTable(string skill, string level)
        {
            skillPage.ViewSkillInTable(skill , level);
        }

        [Then(@"I Edit an existing skill '([^']*)' '([^']*)'  to a new record with values '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingSkillToANewRecordWithValues(string skill, string level, string newSkill, string newLevel)
        {
            skillPage.SuccessfullyEditExistingSkillAndSkillLevel(skill, level, newSkill, newLevel);
            _scenarioContext["Skill"] = newSkill;
        }

        [Then(@"I should be able to see updated skill in table  '([^']*)' '([^']*)'")]
        public void ThenIShouldBeAbleToSeeUpdatedSkillInTable(string newSkill, string newLevel)
        {
           skillPage.ViewSkillInTable(newSkill,newLevel);
        }

        [Then(@"I create a new skill records with value  '([^']*)' without adding skill level")]
        public void ThenICreateANewSkillRecordsWithValueWithoutAddingSkillLevel(string newSkill)
        {
            skillPage.CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(newSkill);
        }

        [Then(@"I Edit an existing skill '([^']*)'to a new skill record with value '([^']*)' without editng skill level")]
        public void ThenIEditAnExistingSkillToANewSkillRecordWithValueWithoutEditngSkillLevel(string skill, string newSkill)
        {
            skillPage.SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel(skill, newSkill);
            _scenarioContext["Skill"] = newSkill;
        }

        [Then(@"I Edit an existing skill '([^']*)' to a new skill record by editing skill level record '([^']*)' to '([^']*)' without editng skill")]
        public void ThenIEditAnExistingSkillToANewSkillRecordByEditingSkillLevelRecordToWithoutEditngSkill(string skill, string level, string newLevel)
        {
            skillPage.SuccsfullyEditSkillLevelWithoutEditSkill(skill, level, newLevel);
            _scenarioContext["Skill"] = skill;
        }

        [Then(@"I Edit an existing skill '([^']*)' '([^']*)' to another existing skill record with values '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingSkillToAnotherExistingSkillRecordWithValues(string skill, string level, string newSkill, string newLevel)
        {
            skillPage.CannotBeAbleToEditExistngSkillAndSkillLevelToAnotherExistingSkill(skill,level,newSkill,newLevel);
        }

        [Then(@"I successfully delete existing skill '([^']*)'")]
        public void ThenISuccessfullyDeleteExistingSkill(string skill)
        {
            skillPage.SuccesffullydeleteExistingSkill(skill);
        }

        [Then(@"I should not be able to see deleted skill in table '([^']*)'")]
        public void ThenIShouldNotBeAbleToSeeUpdatedSkillInTable(string skill)
        {
            skillPage.CannotViewSkillInTable(skill);
        }

        [Then(@"I click the cancel button")]
        public void ThenIClickTheCancelButton()
        {
            skillPage.SuccessfullyClickCancelButton();
        }

        [Then(@"I should not be able to see updated skill in table  '([^']*)','([^']*)', but I can see it\. therefore this could be a bug\.")]
        public void ThenIShouldNotBeAbleToSeeUpdatedSkillInTableButICanSeeIt_ThereforeThisCouldBeABug_(string skill, string level)
        {
            skillPage.ViewSkillInTable(skill, level);
            _scenarioContext["Language"] = skill;
        }


    }
}

