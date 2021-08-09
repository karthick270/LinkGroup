using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using BoDi;

namespace LinkGroup1
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer container;

        public WebDriverHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-infobars");
            options.AddArguments("--start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            ChromeDriver driver = new ChromeDriver(@"C:\LinkGroup1", options, TimeSpan.FromMinutes(3));
          
            

            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}

