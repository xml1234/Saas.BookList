
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using Yoyosoft.BookList.BookListManagement.BookTags;
using Yoyosoft.BookList.BookListManagement.BookTags.Dtos;
using Yoyosoft.BookList.BookListManagement.BookTags.DomainService;
using Yoyosoft.BookList.BookListManagement.BookTags.Authorization;


namespace Yoyosoft.BookList.BookListManagement.BookTags
{
    /// <summary>
    /// BookTag应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BookTagAppService : BookListAppServiceBase, IBookTagAppService
    {
        private readonly IRepository<BookTag, long> _entityRepository;

        private readonly IBookTagManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BookTagAppService(
        IRepository<BookTag, long> entityRepository
        ,IBookTagManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取BookTag的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(BookTagPermissions.Query)] 
        public async Task<PagedResultDto<BookTagListDto>> GetPaged(GetBookTagsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BookTagListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BookTagListDto>>();

			return new PagedResultDto<BookTagListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BookTagListDto信息
		/// </summary>
		[AbpAuthorize(BookTagPermissions.Query)] 
		public async Task<BookTagListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BookTagListDto>();
		}

		/// <summary>
		/// 获取编辑 BookTag
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookTagPermissions.Create,BookTagPermissions.Edit)]
		public async Task<GetBookTagForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetBookTagForEditOutput();
BookTagEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BookTagEditDto>();

				//bookTagEditDto = ObjectMapper.Map<List<bookTagEditDto>>(entity);
			}
			else
			{
				editDto = new BookTagEditDto();
			}

			output.BookTag = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改BookTag的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookTagPermissions.Create,BookTagPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBookTagInput input)
		{

			if (input.BookTag.Id.HasValue)
			{
				await Update(input.BookTag);
			}
			else
			{
				await Create(input.BookTag);
			}
		}


		/// <summary>
		/// 新增BookTag
		/// </summary>
		[AbpAuthorize(BookTagPermissions.Create)]
		public virtual async Task<BookTagEditDto> Create(BookTagEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <BookTag>(input);
            var entity=input.MapTo<BookTag>();

		    var result = await CheckForDuplicateNamesAsync(entity.TagName);
		    if (!result.result)
		    {

		        var entityid = await _entityRepository.InsertAndGetIdAsync(entity);
		        entity.Id = entityid;
		        return entity.MapTo<BookTagEditDto>();
            }
		    else
		    {
		        return result.entity.MapTo<BookTagEditDto>();
		    }

		}

		/// <summary>
		/// 编辑BookTag
		/// </summary>
		[AbpAuthorize(BookTagPermissions.Edit)]
		protected virtual async Task Update(BookTagEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

		    var result = await CheckForDuplicateNamesAsync(entity.TagName);
		    if (result.result)
		    {
		        throw new UserFriendlyException("标签名称重复！");
		    }

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}

        private async Task<(bool result,BookTag entity)> CheckForDuplicateNamesAsync(string tagName)
        {
            var model = await _entityRepository.FirstOrDefaultAsync(a => a.TagName == tagName);
            if (model!=null)
            {
                return (result: true, entity: model);
            }

            return (result: false, entity: new BookTag());
        }



        /// <summary>
		/// 删除BookTag信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookTagPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BookTag的方法
		/// </summary>
		[AbpAuthorize(BookTagPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出BookTag为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


