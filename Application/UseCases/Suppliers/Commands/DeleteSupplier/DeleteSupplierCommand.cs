namespace Application.UseCases.Suppliers.Commands.DeleteSupplier
{
    public record  DeleteSupplierCommand(string Id):IRequest<Response<string>>;
   
}
