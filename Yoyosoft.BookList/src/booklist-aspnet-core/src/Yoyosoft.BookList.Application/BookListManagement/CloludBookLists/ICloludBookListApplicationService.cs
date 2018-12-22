
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
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using Yoyosoft.BookList.BookListManagement.CloludBookLists.Dtos;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;

namespace Yoyosoft.BookList.BookListManagement.CloludBookLists
{
    /// <summary>
    /// CloludBookList应用层服务的接口方法
    ///</summary>
    public interface ICloludBookListAppService : IApplicationService
    {
        /// <summary>
		/// 获取CloludBookList的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CloludBookListListDto>> GetPaged(GetCloludBookListsInput input);


		/// <summary>
		/// 通过指定id获取CloludBookListListDto信息
		/// </summary>
		Task<CloludBookListListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCloludBookListForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改CloludBookList的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateCloludBookListInput input);


        /// <summary>
        /// 删除CloludBookList信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除CloludBookList
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出CloludBookList为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
