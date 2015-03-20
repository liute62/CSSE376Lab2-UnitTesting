using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here
        public readonly DateTime dateThatFlightLeaves = DateTime.Today;
        public readonly DateTime dateThatFlightReturns = Convert.ToDateTime("2015-4-1");
        public DateTime FlightLeaves;
        public DateTime FlightReturns;
        public readonly int someMiles = 1000;
        [Test()]
        public void TestThatFlightInitializes(){

            var target = new Flight(dateThatFlightLeaves,dateThatFlightReturns,someMiles);
            Assert.IsNotNull(target);
        }
    
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDay()
        {
            FlightLeaves = Convert.ToDateTime("2015-3-15");
            FlightReturns = Convert.ToDateTime("2015-3-16");
            var target = new Flight(FlightLeaves,FlightReturns,someMiles);
            Assert.AreEqual(220,target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDays()
        {
            FlightLeaves = Convert.ToDateTime("2015-3-15");
            FlightReturns = Convert.ToDateTime("2015-3-17");
            var target = new Flight(FlightLeaves, FlightReturns, someMiles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDays()
        {
            FlightLeaves = Convert.ToDateTime("2015-3-15");
            FlightReturns = Convert.ToDateTime("2015-3-25");
            var target = new Flight(FlightLeaves, FlightReturns, someMiles);
            Assert.AreEqual(200+20*10, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            new Flight(dateThatFlightLeaves, dateThatFlightReturns, -1);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsInvalidOperation()
        {
            new Flight(dateThatFlightReturns, dateThatFlightLeaves, someMiles);
        }

	}
}
