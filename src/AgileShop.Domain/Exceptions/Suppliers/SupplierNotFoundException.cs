namespace AgileShop.Domain.Exceptions.Suppliers;

public class SupplierNotFoundException : NotFoundException
{
    public SupplierNotFoundException()
    {
        this.TitleMessage = "Supplier not found!";
    }
}
