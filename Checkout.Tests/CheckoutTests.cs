using NUnit.Framework;

namespace Checkout.Tests
{
    public class ExampleTests
    {

        [Test]
        public void Test0()
        {
            // Arrange
            Till till = new Till();
            
            // Act
            // Scan nothing
            
            // 
            NUnit.Framework.Assert.AreEqual(0, till.Total());
        }

        
        [Test]
        public void Given_A_TotalPrice_ShouldBe_50()
        {
            // Arrange
            var till = new Till();
            
            // Act
            till.Scan("A");
            
            // NUnit.Framework.Assert
            NUnit.Framework.Assert.AreEqual(50.0, till.Total());
        }
    
        [Test]
        public void Given_AB_TotalPrice_ShouldBe_80()
        {
            // Arrange
            var till = new Till();

            // Act
            till.Scan("AB"); //scanning on the till in the "till" variable
            
            // Assert
            Assert.AreEqual(80.0, till.Total());
        }    

        [Test]
        public void Given_CDBA_TotalPrice_ShouldBe_110()
        {
            Till till = new Till();
            till.Scan("CDBA");
            NUnit.Framework.Assert.AreEqual(110.0, till.Total()); //it should be 110 as per the instructions
        }

        [Test]
        public void Given_TwoItemsOfTypeA_TotalPrice_ShouldBe_100()
        {
            // Arrange
            Till till = new Till();
            
            // Act
            till.Scan("AA"); //extra scan removed
            
            Assert.AreEqual(100, till.Total());
        }

        [Test]
        public void Given_TwoItemsOfTypeB_TotalPrice_ShouldBe_45()
        {
            // Arrange
            Till till = new Till();
            
            // Act
            till.Scan("BB");
            
            // Assert
            Assert.AreEqual(45, till.Total());
        }

        public void Given_ThreeItemsOfTypeA_TotalPrice_ShouldBe_130()
        {
            // Arrange
            Till till = new Till();
            
            // Act
            till.Scan("AAA");
            
            // Assert
            Assert.AreEqual(130, till.Total());
        }

                [Test]
        public void Given_TwoAAItems_TotalPrice_ShouldBe_180()
        {
            // Arrange
            Till till = new Till();
            
            // Act
            till.Scan("AA");
			till.Scan("AA");//two AA scans would give 180
            
            // Assert
            Assert.AreEqual(180, till.Total());
        }
    }
}