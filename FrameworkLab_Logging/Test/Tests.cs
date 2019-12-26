using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FrameworkLab
{
	[TestFixture]
	public class Tests
	{
		private IWebDriver webDriver;

		[SetUp]
		public void OpenBrowserAndGoToSite()
		{
			Logger.InitLogger();
		}

		[TearDown]
		public void StopBrowser()
		{
			if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
			{
				CreatorOfScreenshot.TakeScreenshot();
			}
			DriverSingleton.CloseDriver();
		}

		[Test]
		public void SearchTicketsWithoutDateInput()
		{
			FlightsPage flightsPage = new FlightsPage()
				.EnterDepartureCity("Minsk")
				.EnterDestinationCity("Moscow")
				.Enter();
			Assert.AreEqual("Pick a date", flightsPage.GetDepartDateErrorMessage());
		}

		[Test]
		public void SearchTicketsWithoutDestinationInput()
		{
			FlightsPage flightsPage = new FlightsPage()
				.EnterDepartureCity("Minsk")
				.EnterDepartDate("28 December, Sa")
				.Enter();
			Assert.AreEqual("Select destination", flightsPage.GetDestinationErrorMessage());
		}

		[Test]
		public void EnterEqualDepartureAndDestinationCity()
		{
			string city = "Minsk National Airport";

			FlightsPage flightsPage = new FlightsPage()
				.EnterDepartureCity(city)
				.EnterDestinationCity(city)
				.EnterDepartDate("28 December, Sa")
				.Enter();

			Assert.AreEqual("Origin and destination cannot be the same", flightsPage.GetDestinationErrorMessage());
		}

		[Test]
		public void AreEqualInputInfoAndInfoInSearchPage()
		{
			string expextedDepartureCity = "Minsk";
			string expectedDestinationCity = "Moscow";
			string expectedDepartDate = "28 December, Sa";

			FlightsPage flightsPage = new FlightsPage()
				.EnterDepartureCity(expextedDepartureCity)
				.EnterDestinationCity(expectedDestinationCity)
				.EnterDepartDate(expectedDepartDate)
				.Enter();

			string[] expectedList = { expextedDepartureCity, expectedDestinationCity, expectedDepartDate };
			string[] actualList = { flightsPage.GetDepartureCity(), flightsPage.GetDestinationCity(), flightsPage.GetDepartDate() };

			Assert.AreEqual(expectedList, actualList);
		}

		[Test]
		public void AreEqualCurrentCurrencyAndPriceCurrency()
		{
			FlightsPage flightsPage = new FlightsPage()
				.EnterDepartureCity("Minsk")
				.EnterDestinationCity("Moscow")
				.EnterDepartDate("28 December, Sa")
				.Enter();

			Assert.AreEqual(flightsPage.GetCurrentCurrency(), flightsPage.GetPriceCurrency());
		}

		[Test]
		public void AreAqualHotelCityAndDestinationCity()
		{
			string expectedDestinationCity = "Moscow";
			string expectedDepartDate = "28 December, Sa";

			HotelPage hotelPage = new FlightsPage()
				.EnterDepartureCity("Minsk")
				.EnterDestinationCity(expectedDestinationCity)
				.EnterDepartDate(expectedDepartDate)
				.ClickHotelButton();

			string[] expectedList = { expectedDestinationCity, expectedDepartDate };
			string[] actualList = { hotelPage.GetDestinationCity(), hotelPage.GetDepartDate() };

			Assert.AreEqual(expectedList, actualList);
		}

		[Test]
		public void EnterCombinationNotMatchFilters()
		{
			FlightsPage flightsPage = new FlightsPage()
				.EnterDepartureCity("Minsk")
				.EnterDestinationCity("Moscow")
				.EnterDepartDate("28 December, Sa")
				.Enter()
				.ClickPaymentMethods()
				.UncheckAllCheckbutton();
			Assert.AreEqual("We found  flights, but none of them match your filters.", flightsPage.GetMessageFlightsPage());
		}
	}
}