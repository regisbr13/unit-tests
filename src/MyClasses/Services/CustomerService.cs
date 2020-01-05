namespace MyClasses.Services
{
    using MyClasses.Interfaces;

    public class CustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public string GetFullName(int customerId)
        {
            Customer customer = this._customerRepository.GetCustomerById(customerId);
            return string.Format("{0} {1}", customer.FirstName, customer.LastName);
        }
    }
}
