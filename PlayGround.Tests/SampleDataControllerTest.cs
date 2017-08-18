using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayGround.Controllers;

namespace PlayGround.Tests
{
    [TestClass]
    [TestCategory("SampleDataController")]
    public class SampleDataControllerTest
    {
        

        [TestMethod]
        public void WeatherForecastsTest()
        {

            SampleDataController testController = new SampleDataController();

            var returnWeather = testController.WeatherForecasts();

            Assert.IsNotNull(returnWeather);




        }
    }
}
