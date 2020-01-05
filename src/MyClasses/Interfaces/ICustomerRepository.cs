namespace MyClasses.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerId);
    }
}
