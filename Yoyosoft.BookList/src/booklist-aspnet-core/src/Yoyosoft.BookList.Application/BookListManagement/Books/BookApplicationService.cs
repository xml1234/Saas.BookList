
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


using Yoyosoft.BookList.BookListManagement;
using Yoyosoft.BookList.BookListManagement.Dtos;
using Yoyosoft.BookList.BookListManagement.DomainService;
using Yoyosoft.BookList.BookListManagement.Authorization;
using Yoyosoft.BookList.BookListManagement.BookTags.DomainService;
using Yoyosoft.BookList.BookListManagement.Relationships;


namespace Yoyosoft.BookList.BookListManagement
{
    /// <summary>
    /// Book应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BookAppService : BookListAppServiceBase, IBookAppService
    {
        private readonly IRepository<Book, long> _entityRepository;

        private readonly IBookManager _entityManager;

        private readonly IRepository<BookAndBookTag, long> _bookAndBookTagRepository;

        private readonly IBookTagManager _bookTagManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BookAppService(
        IRepository<Book, long> entityRepository
        ,IBookManager entityManager, IRepository<BookAndBookTag, long> bookAndBookTagRepository, IBookTagManager bookTagManager)
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
            _bookAndBookTagRepository = bookAndBookTagRepository;
            _bookTagManager = bookTagManager;
        }


        /// <summary>
        /// 获取Book的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(BookPermissions.Query)] 
        public async Task<PagedResultDto<BookListDto>> GetPaged(GetBooksInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BookListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BookListDto>>();

			return new PagedResultDto<BookListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BookListDto信息
		/// </summary>
		[AbpAuthorize(BookPermissions.Query)] 
		public async Task<BookListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BookListDto>();
		}

		/// <summary>
		/// 获取编辑 Book
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookPermissions.Create,BookPermissions.Edit)]
		public async Task<GetBookForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
            var output = new GetBookForEditOutput();
            BookEditDto editDto;


		    List<long> tagIds = null;
            //获取所有标签
            //哪些是选择了的，哪些是没有选择的
		    var booktagListDtos = (await _bookTagManager.GetAll()).MapTo<List<BookTagSelectListDto>>();

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<BookEditDto>();

                //bookEditDto = ObjectMapper.Map<List<bookEditDto>>(entity);


                tagIds = (await _entityManager.GetTagsByBookId(entity.Id)).Select(a => a.BookTagId).ToList();
                foreach (var bookTag in booktagListDtos)
                {
                    if (tagIds.Exists(a=>a==bookTag.Id))
                    {
                        bookTag.IsSelected = true;
                    }
                }
            }
            else
            {
                editDto = new BookEditDto();
            }

            output.Book = editDto;
		    output.BookTags = booktagListDtos;
            return output;
        }


		/// <summary>
		/// 添加或者修改Book的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookPermissions.Create,BookPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBookInput input)
		{

			if (input.Book.Id.HasValue)
			{
				await Update(input.Book, input.TagIds);
			}
			else
			{
				await Create(input.Book, input.TagIds);
			}
		}


		/// <summary>
		/// 新增Book
		/// </summary>
		[AbpAuthorize(BookPermissions.Create)]
		protected virtual async Task<BookEditDto> Create(BookEditDto input, List<long> tagIds)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Book>(input);
            var entity=input.MapTo<Book>();
			

			var entityId = await _entityRepository.InsertAndGetIdAsync(entity);

		    if (tagIds.Count>0)
		    {
		        await _entityManager.CreateBookAndBookTagRelationship(entityId, tagIds);
		    }

			return entity.MapTo<BookEditDto>();
		}

		/// <summary>
		/// 编辑Book
		/// </summary>
		[AbpAuthorize(BookPermissions.Edit)]
        protected virtual async Task Update(BookEditDto input, List<long> tagIds)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);

            await _entityManager.CreateBookAndBookTagRelationship(entity.Id, tagIds);

        }



        /// <summary>
        /// 删除Book信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(BookPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		    await _bookAndBookTagRepository.DeleteAsync(a => a.BookId == input.Id);
		}



		/// <summary>
		/// 批量删除Book的方法
		/// </summary>
		[AbpAuthorize(BookPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		    await _bookAndBookTagRepository.DeleteAsync(a => input.Contains(a.BookId));
		}


		/// <summary>
		/// 导出Book为excel表,等待开发。
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


