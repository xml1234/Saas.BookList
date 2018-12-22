

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;

namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.Dtos
{
    public class CloludBookListListDto : CreationAuditedEntityDto<long> 
    {

        
		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// 简介
		/// </summary>
		public string Intro { get; set; }




    }
}