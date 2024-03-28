namespace Application.UseCases.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierValidation : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierValidation()
        {
            RuleFor(x => x.NIT)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.BusinessName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Location)
                .NotNull();

            RuleFor(x => x.ContactInformation)
                .NotNull();


        }
    }
}
