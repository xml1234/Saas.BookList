
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;

namespace  Yoyosoft.BookList.BookListManagement.CloludBookLists.Dtos
{
    public class CloludBookListEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
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