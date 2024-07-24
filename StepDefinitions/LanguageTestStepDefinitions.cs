using MarsQA.Pages;

namespace MarsSpecFlow.StepDefinitions
{
    [Binding]
    public class LanguageTestStepDefinitions 
    {
        private LanguagePage languagePage;
        private readonly ScenarioContext _scenarioContext;
        public LanguageTestStepDefinitions(ScenarioContext scenarioContext) 
        {
            this.languagePage = new LanguagePage();
            _scenarioContext = scenarioContext;
        }
        
        
        [Given(@"I create a new langauge records with values  '([^']*)' '([^']*)'")]
        public void ThenICreateANewLangaugeRecordsWithValues(string newLanguage, string newLevel)
        {
            languagePage.SuccessfullyAddNewLanguage(newLanguage, newLevel);
            _scenarioContext["Language"] = newLanguage;
        }

        [Then(@"I create a new langauge records with values  '([^']*)' '([^']*)' again")]
        public void ThenICreateANewLangaugeRecordsWithValuesAgain(string newLanguage, string newLevel)
        {
            languagePage.SuccessfullyAddNewLanguage(newLanguage, newLevel);
            _scenarioContext["Language"] = newLanguage;
        }



        [Then(@"I should see popup message as '([^']*)'")]
        public void ThenIShouldSeePopupMessageAs(string message)
        {
            languagePage.AssertionPopupMessage(message);
        }

        [Then(@"I should be able to see added language in table  '(.*)' '(.*)'")]
        public void ThenIShouldBeAbleToSeeAddedLanguageInTable(string newLanguage, string newLevel)
        {
            languagePage.ViewLanguageInTable(newLanguage, newLevel);
        }

        [Then(@"I Edit an existing language '([^']*)' '([^']*)'  to a new record with values '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingLanguageToANewRecordWithValues(string language, string level, string newLanguage, string newLevel)
        {
            languagePage.SuccessfullyEditExistingLanguageAndLanguageLevel(language, level, newLanguage, newLevel);
            _scenarioContext["Language"] = newLanguage;
        }

        [Then(@"I should be able to see updated language in table  '([^']*)' '([^']*)'")]
        public void ThenIShouldBeAbleToSeeUpdatedLanguageInTable(string language, string level)
        {
            languagePage.ViewLanguageInTable(language, level);
        }

        [Given(@"I create a new langauge records with value  '([^']*)' without adding language level")]
        public void ThenICreateANewLangaugeRecordsWithValueWithoutAddingLanguageLevel(string language)
        {
            languagePage.CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(language);
        }

        [Then(@"I Edit an existing language '([^']*)'to a new langauge record with value '([^']*)' without editing language level")]
        public void ThenIEditAnExistingLanguageToANewLangaugeRecordWithValueWithoutEditngLanguageLevel(string language, string newLanguage)
        {
            languagePage.SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(language, newLanguage);
            _scenarioContext["Language"] = newLanguage;
        }

        [Then(@"I Edit an existing language '([^']*)' to a new langauge record by editing language level record form '([^']*)' to '([^']*)' without editing language")]
        public void ThenIEditAnExistingLanguageToANewLangaugeRecordByEditingLanguageLevelRecordFormToWithoutEditngLanguage(string language, string level, string newLevel)
        {
            languagePage.SuccsfullyEditLanguageLevelWithoutEditLanguage(language, level, newLevel);
            _scenarioContext["Language"] = language;
        }

        [Then(@"I Edit an existing language '([^']*)' '([^']*)' to another existing langauge record with values  '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingLanguageToAnotherExistingLangaugeRecordWithValues(string language, string level, string newLanguage, string newLevel)
        {
            languagePage.CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(language, level, newLanguage, newLevel);
        }

        [Then(@"I successfully delete existing language '([^']*)'")]
        public void ThenISuccessfullyDeleteExistingLanguage(string language)
        {
            languagePage.SuccessfullydeleteExistingLanguage(language);
        }

        [Then(@"I should not be able to see updated language in table  '([^']*)'")]
        public void ThenIShouldNotBeAbleToSeeUpdatedLanguageInTable(string language)
        {
            languagePage.CannotViewLanguageInTable(language);


        }

        [Given(@"I add languages until I cannot add")]
        public void GivenIAddLanguagesUntilICannotAdd()
        {
            languagePage.WhenIAddLanguagesUntilICannotAddMore();
        }

        [Then(@"I should see the maximum number of languages added")]
        public void ThenIShouldSeeTheMaximumNumberOfLanguagesAdded()
        {
            languagePage.SeeTheMaximumNumberOfLanguagesAdded();
        }

        [Then(@"I click cancel button")]
        public void ThenIClickCancelButton()
        {
            languagePage.SuccessfullyClickCancelButton();
        }

       
        [Then(@"I should not be able to see updated language in table  '([^']*)','([^']*)', but I can see it\. therefore this could be a bug\.")]
        public void ThenIShouldNotBeAbleToSeeUpdatedLanguageInTableButICanSeeIt_ThereforeThisCouldBeABug_(string language, string level)
        {
            languagePage.ViewLanguageInTable(language, level);
            _scenarioContext["Language"] = language;
        }

    }
}
