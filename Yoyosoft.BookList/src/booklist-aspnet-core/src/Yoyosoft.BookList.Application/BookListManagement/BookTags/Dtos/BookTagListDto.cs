

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using Yoyosoft.BookList.BookListManagement.BookTags;

namespace Yoyosoft.BookList.BookListManagement.BookTags.Dtos
{
    public class BookTagListDto : CreationAuditedEntityDto<long> 
    {

        
		/// <summary>
		/// 标签名称
		/// </summary>
		[MaxLength(55, ErrorMessage="标签名称超出最大长度")]
		public string TagName { get; set; }




    }
}