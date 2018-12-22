

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using Yoyosoft.BookList;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;


namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.DomainService
{
    /// <summary>
    /// CloludBookList领域层的业务管理
    ///</summary>
    public class CloludBookListManager :BookListDomainServiceBase, ICloludBookListManager
    {
		
		private readonly IRepository<CloludBookList,long> _repository;

		/// <summary>
		/// CloludBookList的构造方法
		///</summary>
		public CloludBookListManager(
			IRepository<CloludBookList, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitCloludBookList()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
