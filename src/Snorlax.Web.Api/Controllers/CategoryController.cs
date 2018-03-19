using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Snorlax.Repository;
using Snorlax.Utilities;
using System.Linq;
using Snorlax.Web.Api.Models.Request;

namespace Snorlax.Web.Api.Controllers
{
    [Route("api/categories")]
    public class CategoryController
        : BaseController
    {
        private readonly ICategoryRepository _categoryRespository;
        public CategoryController(
            ILogger logger,
            ICategoryRepository categoryRespository) 
            : base(logger)
        {
            this._categoryRespository=categoryRespository;
        }

        [HttpPost("")]
        public async Task<ApiResponse<Core.Model.Category>> Post([FromBody]Models.Request.CategoryPostModel data)
        {
            ApiResponse<Core.Model.Category> result=new ApiResponse<Core.Model.Category>();
            Snorlax.Validator.IValidator postModelValidator=new Validators.CategoryPostModelValidator(_categoryRespository,RequestType.POST);
            Validator.ValidatorResult validatorResult=postModelValidator.Valid(data);
            if(validatorResult)
            {
                await _categoryRespository.AddOneAsync(data.ToRepositoyModel(Models.Request.RequestType.POST));
                result.Success("kategori başarılı bir şekilde eklendi.");
            }else{
                result.Error(validatorResult);
            }
            return result;
        }
        
        [HttpPut("{id}")]
        public async Task<ApiResponse<Core.Model.Category>> Update(string id,[FromBody]Models.Request.CategoryPostModel data)
        {
            data.Id=id;
            ApiResponse<Core.Model.Category> result=new ApiResponse<Core.Model.Category>();
            Snorlax.Validator.IValidator postModelValidator=new Validators.CategoryPostModelValidator(_categoryRespository,RequestType.PUT);
            Validator.ValidatorResult validatorResult=postModelValidator.Valid(data);
            if(validatorResult)
            {
                await _categoryRespository.UpdateOneAsync(data.ToRepositoyModel(Models.Request.RequestType.PUT));
                result.Success("kategori başarılı bir şekilde güncellendi.");
            }else{
                result.Error(validatorResult);
            }
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(string id)
        {
            ApiResponse result=new ApiResponse();
            if(!string.IsNullOrEmpty(id))
            {
               int deletedCount= await _categoryRespository.DeleteAsync(new Repository.Model.Category(id));
               if(deletedCount>0){
                   result.Success("kategori kalıcı olarak silindi.");
               }
            }
            else
            {
                result.Error(new ErrorModel(){
                    UserMessage="geçersi kategori id"
                });
            }
            return result;
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<ApiResponse<IEnumerable<Core.Model.Category>>> List(int pageIndex,int pageSize)
        {
            ApiResponse<IEnumerable<Core.Model.Category>> result=new ApiResponse<IEnumerable<Core.Model.Category>>();
            IEnumerable<Repository.Model.Category> categories = await _categoryRespository.GetListWithPaginationAsync(pageIndex,pageSize);
            if(categories!=null)
            {
                result.Success("finded",categories.Select(x=>new Core.Model.Category(x)).ToList());
            }
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<Core.Model.Category>> Get(string id)
        {
            ApiResponse<Core.Model.Category> result=new ApiResponse<Core.Model.Category>();
            Repository.Model.Category repositoryCategory=await _categoryRespository.GetByIdAsync(id);
            if(repositoryCategory!=null)
            {
                result.Success("finded",new Core.Model.Category(repositoryCategory));
            }else{
                result.Error("kategori bulunamadı");
            }
            return result;
        }

    }
}