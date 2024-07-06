using MarsQA.Helpers;
using MarsQA.Pages;

namespace MarsSpecFlow.StepDefinitions
{
    [Binding]
    public class LanguageTestStepDefinitions : Driver

    {
        LanguagePage languagePage = new LanguagePage();

        [Given(@"I login to Mars")]
        public void GivenILogIntoMars()

        {
            SignIn.SigninStep();
            SignIn.SuccessfullyNavigateToProfilePageWithSelectedLanguageTab(driver);
        }

        [Given(@"I create a new langauge records with values  '([^']*)' '([^']*)'")]
        public void ThenICreateANewLangaugeRecordsWithValues(string language, string level)

        {
            languagePage.SuccessfullyAddNewLanguage(driver, language, level);
        }

        [Then(@"I should see popup message as '([^']*)'")]
        public void ThenIShouldSeePopupMessageAs(string message)

        {
            languagePage.AssertionPopupMessage(driver, message);
        }

        [Then(@"I should be able to see added language in table  '(.*)' '(.*)'")]
        public void ThenIShouldBeAbleToSeeAddedLanguageInTable(string language, string level)

        {
            languagePage.ViewLanguageInTable(driver, language, level);
        }

        [Given(@"I Edit an existing language '([^']*)' '([^']*)'  to a new record with values '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingLanguageToANewRecordWithValues(string language, string level, string newLanguage, string newLevel)

        {
            languagePage.SuccessfullyEditExistingLanguageAndLanguageLevel(driver, language, level, newLanguage, newLevel);
        }

        [Then(@"I should be able to see updated language in table  '([^']*)' '([^']*)'")]
        public void ThenIShouldBeAbleToSeeUpdatedLanguageInTable(string language, string level)

        {
            languagePage.ViewLanguageInTable(driver, language, level);
        }

        [Given(@"I create a new langauge records with value  '([^']*)' without adding language level")]
        public void ThenICreateANewLangaugeRecordsWithValueWithoutAddingLanguageLevel(string language)

        {
            languagePage.CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(driver, language);
        }

        [Given(@"I Edit an existing language '([^']*)'to a new langauge record with value '([^']*)' without editng language level")]
        public void ThenIEditAnExistingLanguageToANewLangaugeRecordWithValueWithoutEditngLanguageLevel(string language, string newLanguage)

        {
            languagePage.SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(driver, language, newLanguage);
        }

        [Given(@"I Edit an existing language '([^']*)' to a new langauge record by editing language level record form '([^']*)' to '([^']*)' without editng language")]
        public void ThenIEditAnExistingLanguageToANewLangaugeRecordByEditingLanguageLevelRecordFormToWithoutEditngLanguage(string language, string level, string newLevel)

        {
            languagePage.SuccsfullyEditLanguageLevelWithoutEditLanguage(driver, language, level, newLevel);
        }

        [Given(@"I Edit an existing language '([^']*)' '([^']*)' to another existing langauge record with values  '([^']*)' '([^']*)'")]
        public void ThenIEditAnExistingLanguageToAnotherExistingLangaugeRecordWithValues(string language, string level, string newLanguage, string newLevel)

        {
            languagePage.CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(driver, language, level, newLanguage, newLevel);
        }

        [Given(@"I successfully delete existing language '([^']*)'")]
        public void ThenISuccessfullyDeleteExistingLanguage(string language)

        {
            languagePage.SuccessfullydeleteExistingLanguage(driver, language);
        }

        [Then(@"I should not be able to see updated language in table  '([^']*)'")]
        public void ThenIShouldNotBeAbleToSeeUpdatedLanguageInTable(string language)

        {
            languagePage.CannotViewLanguageInTable(driver, language);
        }

        [Given(@"I add languages until I cannot add")]
        public void GivenIAddLanguagesUntilICannotAdd()

        {
            languagePage.WhenIAddLanguagesUntilICannotAddMore(driver);
        }

        [Then(@"I should see the maximum number of languages added")]
        public void ThenIShouldSeeTheMaximumNumberOfLanguagesAdded()

        {
            languagePage.SeeTheMaximumNumberOfLanguagesAdded(driver);
        }

       
    }
}
