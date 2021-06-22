﻿using System.Linq;
using Chinook.Domain.Supervisor;
using Xunit;

namespace Chinook.UnitTest.Supervisor
{
    public class InvoiceRepositoryTest
    {
        private readonly IChinookSupervisor _super;

        public InvoiceRepositoryTest()
        {
        }

        [Fact]
        public void InvoiceGetAll()
        {
            // Act
            var invoices = _super.GetAllInvoice().ToList();

            // Assert
            Assert.True(invoices.Count > 1, "The number of invoices was not greater than 1");
        }
    }
}