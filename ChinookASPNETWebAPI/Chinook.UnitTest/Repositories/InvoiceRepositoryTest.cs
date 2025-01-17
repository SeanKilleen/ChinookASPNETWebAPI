﻿using Chinook.Domain.Repositories;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class InvoiceRepositoryTest
    {
        private readonly IInvoiceRepository _repo;

        public InvoiceRepositoryTest(IInvoiceRepository i) => _repo = i;

        [Fact]
        public void InvoiceGetAll()
        {
            // Act
            var invoices = _repo.GetAll();

            // Assert
            Assert.True(invoices.Count > 1, "The number of invoices was not greater than 1");
        }
    }
}