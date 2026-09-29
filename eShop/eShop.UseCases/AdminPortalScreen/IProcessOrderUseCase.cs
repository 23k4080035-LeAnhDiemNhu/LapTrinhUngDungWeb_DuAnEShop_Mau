namespace eShop.UseCases.AdminPortalScreen
{
    public interface IProcessOrderUseCase
    {
        bool Execute(int orderId, string adminUserName);
    }
}
