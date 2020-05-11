using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreServer
{
    class WebHandler
    {
        public string OpenURL(string url)
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Url = url;

            GlobalObject global = GlobalObject.Instance;

            Guid id = Guid.NewGuid();

            global.fileIndex.Add(id.ToString(), driver);

            return id.ToString();
        }

        public int EnterText(string id, string elementId, string text)
        {



            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Url = id;

            driver.FindElement(By.Id("email")).SendKeys(elementId);
            driver.FindElement(By.Id("pass")).SendKeys(text);
            ClickAndWaitForPageToLoad(driver, By.Id("loginbutton"));
            /*

            id = "https://support.google.com/accounts/answer/6010255?hl=en";
            elementId = "csi";
            text="World!";
            GlobalObject global = GlobalObject.Instance;

            IWebDriver driver;

            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is IWebDriver)
            {
                driver = (IWebDriver)tempObject;
            }
            else
            {
                return Result.NOK;
            }

            driver.FindElement(By.Name(elementId)).SendKeys(text);
            */

            return Result.OK;
        }

        public string ReadText(string id, string elementId)
        {
            GlobalObject global = GlobalObject.Instance;

            IWebDriver driver;

            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is IWebDriver)
            {
                driver = (IWebDriver)tempObject;
            }
            else
            {
                return "";
            }

            return driver.FindElement(By.ClassName(elementId)).Text;
        }

        public int ClickButton(string id, string elementId)
        {
            GlobalObject global = GlobalObject.Instance;

            IWebDriver driver;

            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is IWebDriver)
            {
                driver = (IWebDriver)tempObject;
            }
            else
            {
                return Result.NOK;
            }

            driver.FindElement(By.XPath("//input[@type='" + elementId + "']")).Click();

            return Result.OK;
        }

        public int CloseBrowser(string id)
        {
            GlobalObject global = GlobalObject.Instance;

            IWebDriver driver;

            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is IWebDriver)
            {
                driver = (IWebDriver)tempObject;
            }
            else
            {
                return Result.NOK;
            }

            driver.Close();
            driver.Dispose();

            global.fileIndex.Remove(id);

            return Result.OK;
        }


        private void ClickAndWaitForPageToLoad(IWebDriver driver,
                By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var elements = driver.FindElements(elementLocator);
                if (elements.Count == 0)
                {
                    throw new NoSuchElementException(
                        "No elements " + elementLocator + " ClickAndWaitForPageToLoad");
                }
                var element = elements.FirstOrDefault(e => e.Displayed);
                element.Click();
                //wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine(
                    "Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }
    
}


