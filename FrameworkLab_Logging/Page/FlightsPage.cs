using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkLab
{
    public class FlightsPage
    {
		IWebDriver webDriver;
		private const string url = "https://www.aviasales.com/";

		[FindsBy(How = How.XPath, Using = "//input[@id='origin']")]
        	private IWebElement departureCity;
        	[FindsBy(How = How.XPath, Using = "//input[@id='destination']")]
        	private IWebElement destinationCity;
		[FindsBy(How = How.XPath, Using = "//input[@id='departDate']")]
		private IWebElement departDate;
		[FindsBy(How = How.XPath, Using = "//div[@class='date-input__input-wrap --error']")]
		private IWebElement departDateErrorMessage;
		[FindsBy(How = How.XPath, Using = "//div[@class='autocomplete__input-wrapper --error']")] 
		private IWebElement destinationErrorMessage;
		[FindsBy(How = How.XPath, Using = "//div[@class='minimized-calendar-matrix__item --cheap is-current']/span")]
		private IWebElement currentPrice;
		[FindsBy(How = How.XPath, Using = "//span[@class='locale-selector__label-text']")]
		private IWebElement currentCurrency;
		[FindsBy(How = How.XPath, Using = "//div[@class='filter__header --payment_methods']")]
		private IWebElement paymentMethods;
		[FindsBy(How = How.XPath, Using = "//div[@class='checkboxes-list__item']")]
		private IWebElement checkboxAll;
		[FindsBy(How = How.XPath, Using = "//div[@class='filter-message__title']")]
		private IWebElement messageFlightsPage;
		[FindsBy(How = How.XPath, Using = "//li[@class='form-tabs__item --hotel']")]
		private IWebElement hotelButton;
		
		public FlightsPage()
        	{
			webDriver = DriverSingleton.GetDriver();
			webDriver.Navigate().GoToUrl(url);
			Logger.Log.Info($"Followed {url}");
		}

		public FlightsPage Enter()
		{
			return Enter();
		}

		public FlightsPage EnterDepartureCity(string city)
		{
			Logger.Log.Info("Departure city entered");
			departureCity.Clear();
			departureCity.SendKeys(city);
			return this;
		}

		public FlightsPage EnterDestinationCity(string city)
		{
			Logger.Log.Info("Destination city entered");
			destinationCity.Clear();
			destinationCity.SendKeys(city);
			return this;
		}

		public FlightsPage EnterDepartDate(string date)
		{
			Logger.Log.Info("Departure date entered");
			departDate.Clear();
			departDate.SendKeys(date);
			return this;
		}

		public string GetDepartDateErrorMessage()
		{
			Logger.Log.Info("Get depart date error message from FlightsPage if exist");
			if (webDriver.FindElements(By.TagName(departDateErrorMessage.TagName)).Count > 0)
				return departDateErrorMessage.Text;
			else
				return "";
		}

		public string GetDestinationErrorMessage()
		{
			Logger.Log.Info("Get destination error message from FlightsPage if exist");
			if (webDriver.FindElements(By.TagName(destinationErrorMessage.TagName)).Count > 0)
				return destinationErrorMessage.Text;
			else
				return "";
		}

		public string GetDepartureCity()
		{
			Logger.Log.Info("Get departure city from FlightsPage");
			return departureCity.Text;
		}

		public string GetDestinationCity()
		{
			Logger.Log.Info("Get destination city from FlightsPage");
			return destinationCity.Text;
		}

		public string GetDepartDate()
		{
			Logger.Log.Info("Get depart date from FlightsPage");
			return departDate.Text;
		}

		public HotelPage ClickHotelButton()
		{
			Logger.Log.Info("Click hotel button");
			hotelButton.Click();
			return new HotelPage();
		}

		public FlightsPage ClickPaymentMethods()
		{
			Logger.Log.Info("Click payment methods");
			paymentMethods.Click();
			return this;
		}

		public FlightsPage UncheckAllCheckbutton()
		{
			Logger.Log.Info("Uncheck all checkbutton");
			checkboxAll.Click();
			return this;
		}

		public string GetMessageFlightsPage()
		{
			Logger.Log.Info("Get FlightsPage message");
			return new string(messageFlightsPage.Text.ToCharArray().Where(n => !char.IsDigit(n)).ToArray());
		}
	}
}
