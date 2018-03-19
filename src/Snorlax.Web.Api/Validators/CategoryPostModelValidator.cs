using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Snorlax.Repository;
using Snorlax.Validator;
using Snorlax.Web.Api.Models.Request;

namespace Snorlax.Web.Api.Validators
{
    public class CategoryPostModelValidator
        : AbstractValidator<Models.Request.CategoryPostModel>, Validator.IValidator
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryPostModelValidator(
            ICategoryRepository categoryRepository,RequestType requestType)
        {
            this._categoryRepository=categoryRepository;

            RuleFor(m=>m.Name)
                .NotEmpty()
                .WithMessage("kategori adı girmelisiniz.");
            if(requestType==RequestType.POST){
                RuleFor(m=>m.Name)
                    .MustAsync(CategoryNameValidAsync)
                    .WithMessage("bu isimde bir kategori zaten ekli");
            }
        }

        private async Task<bool> CategoryNameValidAsync(string categoryName, CancellationToken cancellationToken)
        {
            return !(await _categoryRepository.ExistsByNameAsync(categoryName));
        }

        public ValidatorResult Valid(object obj)
        {
            ValidationResult validationResult=base.Validate((Models.Request.CategoryPostModel)obj);
            return new ValidatorResult(){
                IsValid=validationResult.IsValid,
                Errors=validationResult.Errors.Select(x=>new ErrorModel(){
                    Code=x.ErrorCode,
                    UserMessage=x.ErrorMessage
                }).ToList()
            };
        }
    }
}