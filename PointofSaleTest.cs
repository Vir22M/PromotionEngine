using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngineTest
{
    [TestClass]
    public class PointofSaleTest
    {
        private readonly BackOffice backOffice;

       public PointofSaleTest()
        {
            this.backOffice = new BackOffice();
            this.backOffice.CreateItem("A", 50, 50);
            this.backOffice.CreateItem("B", 30, 50);
            this.backOffice.CreateItem("C", 20, 50);
            this.backOffice.CreateItem("D", 15, 50);
            this.backOffice.CreatePromotion(new[] { "A" }, 130, 3);
            this.backOffice.CreatePromotion(new[] { "B" }, 45, 2);
            this.backOffice.CreatePromotion(new[] { "C", "D" }, 30, 1);
        }
        [TestMethod]
        public void GetCartValue_WhenNoOffer_ShouldReturnActualValue()
        {
            // Arrange
            var pos = new PointOfSale(this.backOffice);
            pos.AddItemToCart("A", 1);
            pos.AddItemToCart("B", 1);
            pos.AddItemToCart("C", 1);

            // Act
            var cartValue = pos.GetCartValue();

            // Assertions 
            Assert.AreEqual(100, cartValue);
        }

        [TestMethod]
        public void GetCartValue_WhenNoClubbedOffer_ShouldReturnOfferValue()
        {
            // Arrange
            var pos = new PointOfSale(this.backOffice);
            pos.AddItemToCart("A", 5);
            pos.AddItemToCart("B", 5);
            pos.AddItemToCart("C", 1);

            // Act
            var cartValue = pos.GetCartValue();

            // Assertions 
            Assert.AreEqual(370, cartValue);
        }

        [TestMethod]
        public void GetCartValue_WhenClubbedOffer_ShouldReturnOfferValue()
        {
            // Arrange
            var pos = new PointOfSale(this.backOffice);
            pos.AddItemToCart("A", 3);
            pos.AddItemToCart("B", 5);
            pos.AddItemToCart("C", 1);
            pos.AddItemToCart("D", 1);

            // Acts
            var cartValue = pos.GetCartValue();

            // Assertions 
            Assert.AreEqual(280, cartValue);
        }
    }
}
