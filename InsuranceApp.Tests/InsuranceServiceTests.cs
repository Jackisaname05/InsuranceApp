using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using InsuranceApp;

namespace InsuranceApp.Tests
{
    [TestFixture]
    public class InsuranceServiceTests
    {
        private Mock<IDiscountService> _mockDiscountService;
        private InsuranceService _insuranceService;

        [SetUp]
        public void Setup()
        {
            _mockDiscountService = new Mock<IDiscountService>();
            _mockDiscountService.Setup(ds => ds.GetDiscount()).Returns(0.8); // 20% discount
            _insuranceService = new InsuranceService(_mockDiscountService.Object);
        }

        [TestCase(25, "casual", 5.0)]
        [TestCase(35, "casual", 3.5)]
        [TestCase(17, "casual", 0.0)]
        [TestCase(25, "hardcore", 6.0)]
        [TestCase(40, "hardcore", 5.0)]
        [TestCase(16, "hardcore", 0.0)]
        [TestCase(55, "casual", 2.8)] // 3.5 * 0.8
        [TestCase(60, "hardcore", 4.0)] // 5.0 * 0.8
        [TestCase(25, "unknown", 0.0)]
        public void TestCalcPremium(int age, string mode, double expected)
        {
            var result = _insuranceService.CalcPremium(age, mode);
            Assert.AreEqual(expected, result);
        }
    }
}
