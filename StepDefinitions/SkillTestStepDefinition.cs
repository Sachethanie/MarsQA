using MarsQA.Helpers;
using MarsQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class SkillTestStepDefinitions : Driver

    {
        SkillPage skillPage = new SkillPage();
        

        [Given(@"I login to Mars")]
        public void GivenILogIntoMars()
        {
            SignIn.SigninStep();
            SignIn.SuccessfullyNavigateToProfilePageWithSelectedLanguageTab(driver);
        }

        [Given(@"I select skills tab")]
        public void ThenISelectSkillsForm()

        {
            skillPage.NavigateToSkillForm(driver);
        }

        [Then(@"I create a new skill records with values  '([^']*)' '([^']*)'")]
        public void ThenICreateANewSkillRecordsWithValues(string skill, string level)

        {
            skillPage.SuccessfullyAddNewSkill(driver,skill, level);
        }

        [Then(@"I should be able to see added skill in table '([^']*)' '([^']*)'")]
        public void ThenIShouldBeAbleToSeeAddedSkillInTable(string skill, string level)

        {
            skillPage.ViewSkillInTable(driver,skill , level);
        }

        [Then(@"I Edit an existing skill '([^']*)' '([^']*)'  to a new record with values '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingSkillToANewRecordWithValues(string skill, string level, string newSkill, string newLevel)

        {
            skillPage.SuccessfullyEditExistingSkillAndSkillLevel(driver, skill, level, newSkill, newLevel);
        }

        [Then(@"I should be able to see updated skill in table  '([^']*)' '([^']*)'")]
        public void ThenIShouldBeAbleToSeeUpdatedSkillInTable(string newSkill, string newLevel)

        {
           skillPage.ViewSkillInTable(driver,newSkill,newLevel);
        }

        [Then(@"I create a new skill records with value  '([^']*)' without adding skill level")]
        public void ThenICreateANewSkillRecordsWithValueWithoutAddingSkillLevel(string newSkill)

        {
            skillPage.CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(driver,newSkill);
        }

        [Then(@"I Edit an existing skill '([^']*)'to a new skill record with value '([^']*)' without editng skill level")]
        public void ThenIEditAnExistingSkillToANewSkillRecordWithValueWithoutEditngSkillLevel(string skill, string newSkill)

        {
            skillPage.SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel(driver,skill, newSkill);
        }

        [Then(@"I Edit an existing skill '([^']*)' to a new skill record by editing skill level record '([^']*)' to '([^']*)' without editng skill")]
        public void ThenIEditAnExistingSkillToANewSkillRecordByEditingSkillLevelRecordToWithoutEditngSkill(string skill, string level, string newLevel)

        {
            skillPage.SuccsfullyEditSkillLevelWithoutEditSkill(driver, skill, level, newLevel);
        }

        [Then(@"I Edit an existing skill '([^']*)' '([^']*)' to another existing skill record with values '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingSkillToAnotherExistingSkillRecordWithValues(string skill, string level, string newSkill, string newLevel)

        {
            skillPage.CannotBeAbleToEditExistngSkillAndSkillLevelToAnotherExistingSkill(driver, skill,level,newSkill,newLevel);
        }

        [Then(@"I successfully delete existing skill '([^']*)'")]
        public void ThenISuccessfullyDeleteExistingSkill(string skill)

        {
            skillPage.SuccesffullydeleteExistingSkill(driver,skill);
        }

        [Then(@"I should not be able to see deleted skill in table '([^']*)'")]
        public void ThenIShouldNotBeAbleToSeeUpdatedSkillInTable(string skill)

        {
            skillPage.CannotViewSkillInTable(driver,skill);
        }
    }
}

