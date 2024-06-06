using FluentValidation;

namespace Application.Requests;

public class GetByIdRequestValidator : AbstractValidator<GetByIdRequest>
{
    public GetByIdRequestValidator()
        => RuleFor(req => req.Id).NotNull().NotEmpty();
}