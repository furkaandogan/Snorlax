using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Snorlax.Repository;
using Snorlax.Validator;

namespace Snorlax.Web.Api.Validators
{
    public class ProductPostModelValidator
        : AbstractValidator<Models.Request.ProductPostModel>, Validator.IValidator
    {
        private readonly ICategoryRepository _catoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        public ProductPostModelValidator(
            ICategoryRepository categoryRepository,
            ISupplierRepository supplierRepository)
        {
            _catoryRepository=categoryRepository;
            _supplierRepository=supplierRepository;

            RuleFor(m=>m.Name)
                .NotEmpty()
                .WithMessage("ürün adı girmelisiniz.");
            RuleFor(m=>m.UnitPrice)
                .GreaterThan(0)
                .WithMessage("0 TL değerinden düşük fiyat giremezsiniz.");
            RuleFor(m=>m.CategoryId)
                .NotEmpty()
                .WithMessage("lütfen bir kategori seçiniz.")
                .MustAsync(CategoryIdValidAsync)
                .WithMessage("geçerli bir kategori seçmelisiniz.");
            RuleFor(m=>m.SupplierId)
                .NotEmpty()
                .WithMessage("lütfen tedarikçi bilgisini seçiniz")
                .MustAsync(SupplerIdValidAsync)
                .WithMessage("geçerli bir tedarikçi seçmelisiniz.");
        }

        private Task<bool> SupplerIdValidAsync(string supplierId, CancellationToken cancellationToken)
        {
            return _supplierRepository.ExistsByIdAsync(supplierId);
        }

        private Task<bool> CategoryIdValidAsync(string categoryId, CancellationToken cancellationToken)
        {
            return _catoryRepository.ExistsByIdAsync(categoryId);
        }

        public ValidatorResult Valid(object obj)
        {
            ValidationResult validationResult=base.Validate((Models.Request.ProductPostModel)obj);
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