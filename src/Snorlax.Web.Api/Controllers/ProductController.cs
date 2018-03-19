using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Snorlax.Repository;
using Snorlax.Utilities;

namespace Snorlax.Web.Api.Controllers
{
    [Route("api/products")]
    public class ProductController
        : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICategoryRepository _categoryRepository;
        // private readonly IMapper IMapper;
        public ProductController(
            ILogger logger,
            // IMapper mapper,
            IProductRepository productRepository,
            ISupplierRepository supplierRepository,
            ICategoryRepository categoryRepository) 
            : base(logger)
        {
            // this.IMapper=mapper;
            this._productRepository=productRepository;
            this._supplierRepository=supplierRepository;
            this._categoryRepository=categoryRepository;
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<ApiResponse<List<Core.Model.Product>>> List(int pageIndex=0,int pageSize=20)
        {
            ApiResponse<List<Core.Model.Product>> result=new ApiResponse<List<Core.Model.Product>>();
            IEnumerable<Repository.Model.Product> products = await _productRepository.GetListWithPaginationAsync(pageIndex,pageSize);
            if(products!=null)
            {
                // result.Success("finded",products.Select(x=>Mapper.Map<Repository.Model.Product,Core.Model.Product>(x)));
                result.Success("finded",products.Select(x=>new Core.Model.Product(x)).ToList());
            }
            return result;
        }

        [HttpPost("")]
        public async Task<ApiResponse<Core.Model.Product>> Post([FromBody]Models.Request.ProductPostModel data)
        {
            ApiResponse<Core.Model.Product> result=new ApiResponse<Core.Model.Product>();
            Snorlax.Validator.IValidator postModelValidator=new Validators.ProductPostModelValidator(_categoryRepository,_supplierRepository);
            Validator.ValidatorResult validatorResult=postModelValidator.Valid(data);
            if(validatorResult)
            {
                await _productRepository.AddOneAsync(data.ToRepositoyModel(Models.Request.RequestType.POST));
                result.Success("ürün başarılı bir şekilde eklendi.");
            }else{
                result.Error(validatorResult);
            }
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<Core.Model.Product>> Get(string id)
        {
            ApiResponse<Core.Model.Product> result=new ApiResponse<Core.Model.Product>();
            Repository.Model.Product repositoryProduct=await _productRepository.GetByIdAsync(id);
            if(repositoryProduct!=null){
                result.Success("",new Core.Model.Product(repositoryProduct));
            }else{
                result.Error("ürün bulunamadı");
            }
            return result;
        }
    }
}