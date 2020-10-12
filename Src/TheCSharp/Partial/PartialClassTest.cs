using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.Partial
{
   public class PartialClassTest
    {
        private readonly PurchaseService purchaseService = new PurchaseService();

        [Fact]
        public void ShouldReturnTodaysPurchaseAmount()
        {
            int todaysPurchase = purchaseService.GetTodyasPurchaseAmount();

            todaysPurchase.Should().Be(10000);
        }

        [Fact]
        public void ShouldReturnYesterdaysPurchaseAmount()
        {
            int yesterdaysPurchase = purchaseService.GetYesterdaysPurchaseAmount();

            yesterdaysPurchase.Should().Be(20000);
        }
    }
}
