using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkLab
{
    public class HotelPage
    {
		IWebDriver webDriver;

		[FindsBy(How = How.XPath, Using = "//input[@id='destination']")]
		private IWebElement hotelCity;
		[FindsBy(How = How.XPath, Using = "//input[@id='origin']")]
		private IWebElement departureCity;
		[FindsBy(How = How.XPath, Using = "//input[@id='departDate']")]
		private IWebElement departDate;
		
		public HotelPage()
        {
			webDriver = DriverSingleton.GetDriver();
		}

		public IWebDriver GetHotelPageWebDriver()
		{
			return webDriver;
		}

		public string GetHotelCity()
		{
            Logger.Log.Info("Get Hotel City");
            return hotelCity.Text;
		}

		public string GetDepartureCity()
		{
            Logger.Log.Info("Get Departure City");
            return departureCity.Text;
		}

		public string GetDestinationCity()
		{
            Logger.Log.Info("Get Destination City");
            return hotelCity.Text;
		}

		public string GetDepartDate()
		{
            Logger.Log.Info("Get Depart Date");
            return departDate.Text;
		}

		public HotelPage Enter()
        {
			return Enter();
        }
	}
}
