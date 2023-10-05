namespace Pizza.Domain.Repositories
{
    public interface IProduct
    {
        string Name { get; }
        string GetImagePath();
        int GetPrice();
    }
}
