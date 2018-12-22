
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using Yoyosoft.BookList.BookListManagement.BookTags;

namespace  Yoyosoft.BookList.BookListManagement.BookTags.Dtos
{
    public class BookTagEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// 标签名称
		/// </summary>
		[MaxLength(55, ErrorMessage="标签名称超出最大长度")]
		public string TagName { get; set; }




    }
}