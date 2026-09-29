namespace BlazorApp1_Demo.Data
{
    public interface ICustomerService
    {
        string Uid { get; set; }
        Customer GetCustomerById(int id);
    }
}
