
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


using Yoyosoft.BookList.BookListManagement.CloludBookLists;
using Yoyosoft.BookList.BookListManagement.CloludBookLists.Dtos;
using Yoyosoft.BookList.BookListManagement.CloludBookLists.DomainService;
using Yoyosoft.BookList.BookListManagement.CloludBookLists.Authorization;


namespace Yoyosoft.BookList.BookListManagement.CloludBookLists
{
    /// <summary>
    /// CloludBookList应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class CloludBookListAppService : BookListAppServiceBase, ICloludBookListAppService
    {
        private readonly IRepository<CloludBookList, long> _entityRepository;

        private readonly ICloludBookListManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public CloludBookListAppService(
        IRepository<CloludBookList, long> entityRepository
        ,ICloludBookListManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取CloludBookList的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(CloludBookListPermissions.Query)] 
        public async Task<PagedResultDto<CloludBookListListDto>> GetPaged(GetCloludBookListsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<CloludBookListListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<CloludBookListListDto>>();

			return new PagedResultDto<CloludBookListListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取CloludBookListListDto信息
		/// </summary>
		[AbpAuthorize(CloludBookListPermissions.Query)] 
		public async Task<CloludBookListListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<CloludBookListListDto>();
		}

		/// <summary>
		/// 获取编辑 CloludBookList
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CloludBookListPermissions.Create,CloludBookListPermissions.Edit)]
		public async Task<GetCloludBookListForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetCloludBookListForEditOutput();
CloludBookListEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<CloludBookListEditDto>();

				//cloludBookListEditDto = ObjectMapper.Map<List<cloludBookListEditDto>>(entity);
			}
			else
			{
				editDto = new CloludBookListEditDto();
			}

			output.CloludBookList = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改CloludBookList的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CloludBookListPermissions.Create,CloludBookListPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateCloludBookListInput input)
		{

			if (input.CloludBookList.Id.HasValue)
			{
				await Update(input.CloludBookList);
			}
			else
			{
				await Create(input.CloludBookList);
			}
		}


		/// <summary>
		/// 新增CloludBookList
		/// </summary>
		[AbpAuthorize(CloludBookListPermissions.Create)]
		protected virtual async Task<CloludBookListEditDto> Create(CloludBookListEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <CloludBookList>(input);
            var entity=input.MapTo<CloludBookList>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<CloludBookListEditDto>();
		}

		/// <summary>
		/// 编辑CloludBookList
		/// </summary>
		[AbpAuthorize(CloludBookListPermissions.Edit)]
		protected virtual async Task Update(CloludBookListEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除CloludBookList信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(CloludBookListPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除CloludBookList的方法
		/// </summary>
		[AbpAuthorize(CloludBookListPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出CloludBookList为excel表,等待开发。
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


