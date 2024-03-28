namespace Application.UseCases.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierValidation: AbstractValidator<UpdateSupplierCommand>
    {

        public UpdateSupplierValidation()
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
