namespace MyClassesTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyClasses;
    using MyClasses.Interfaces;
    using MyClasses.Services;
    using NSubstitute;

    [TestClass]
    public class CustomerServiceTest
    {
        public TestContext TestContext { get; set; }

        private ICustomerRepository customerRepository;
        private CustomerService customerService;

        #region Test Initialize and Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            this.customerRepository = Substitute.For<ICustomerRepository>();
            this.customerService = new CustomerService(this.customerRepository);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }
        #endregion

        [TestMethod]
        public void WhenGetFullNameIsCalledShouldReturnCustomerFullName()
        {
            var customer = new Customer
            {
                FirstName = "Regis",
                LastName = "Lima"
            };

            this.customerRepository.GetCustomerById(1).Returns(customer);
            Assert.AreEqual("Regis Lima", this.customerService.GetFullName(1));
        }
    }
}
