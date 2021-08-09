using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using LinkGroup1;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Linkgroup1
{
    [Binding]
    public class Feature1Steps
    {
        private readonly IWebDriver _driver;

        public Feature1Steps(IWebDriver driver)
        {
            this._driver = driver;
        }

       
        [Given(@"I open the home page")]
        [When(@"I open the home page")]
        public void WhenIOpenTheHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.linkgroup.eu/");
        }

        [Then(@"the page is displayed")]
        public void ThenThePageIsDisplayed()
        {
            String title = _driver.Title;
            Assert.AreEqual("Home", title);

        }


        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            _driver.FindElement(By.Id("btnAccept")).Click();
            
        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string stringToSearch)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("LinkGroupEU")));

            Actions action = new Actions(_driver);
            //action.MoveToElement(driver.FindElement(By.XPath("//*[@id='img-defer-id-1-6775']"))).Build().Perform(); 
            action.MoveToElement(_driver.FindElement(By.Id("LinkGroupEU"))).Build().Perform();

            _driver.FindElement(By.Id("navbardrop")).Click();
            _driver.FindElement(By.Name("searchTerm")).SendKeys(stringToSearch);
            _driver.FindElement(By.ClassName("btn-outline-default")).Click();
        }

        [Then(@"the search results are displayed")]
        public void ThenTheSearchResultsAreDisplayed()
        {
            string searchResultHeader = _driver.FindElement(By.XPath("//*[@id='SearchResults']/h3")).Text;
            Assert.AreEqual("You searched for:\r\n\"Leeds\"", searchResultHeader);
        }


    }
}

