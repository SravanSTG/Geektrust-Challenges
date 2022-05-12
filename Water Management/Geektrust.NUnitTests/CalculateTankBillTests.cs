using NUnit.Framework;

namespace Geektrust.NUnitTests
{
    public class CalculateTotalWaterTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void CalculateTotalWaterTests_EqualTest()
        {
            // Assign
            int corporateWater1 = 270, borewellWater1 = 630, tankWater1 = 1500; // Testcase 1
            int corporateWater2 = 1000, borewellWater2 = 500, tankWater2 = 1500; // Testcase 2
            int corporateAndBorewellWater1 = 0;
            int corporateAndBorewellWater2 = 0;

            // Act
            // Testcase 1
            corporateAndBorewellWater1 = corporateWater1 + borewellWater1;
            int totalWater1 = corporateAndBorewellWater1 + tankWater1;

            //Testcase 2
            corporateAndBorewellWater2 = corporateWater2 + borewellWater2;
            int totalWater2 = corporateAndBorewellWater2 + tankWater2;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(2400, totalWater1, "Testcase 1");
                Assert.AreEqual(3000, totalWater2, "Testcase 2");
            });
        }
    }

    public class CalculateTotalBillTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void CalculateTotalBillTests_EqualTest()
        {
            // Assign
            int tankWater = 1500;
            int corporateBill1 = 270, borewellBill1 = 945; // Testcase 1
            int corporateBill2 = 1000, borewellBill2 = 750; // Testcase 2

            // Act
            int tankBill1 = Program.CalculateTankBill(tankWater);
            int tankBill2 = Program.CalculateTankBill(tankWater);

            int totalBill1 = Program.CalculateTotalBill(corporateBill1, borewellBill1, tankBill1);
            int totalBill2 = Program.CalculateTotalBill(corporateBill2, borewellBill2, tankBill2);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(5215, totalBill1, "Testcase 1");
                Assert.AreEqual(5750, totalBill2, "Testcase 2");
            });
        }
    }
}