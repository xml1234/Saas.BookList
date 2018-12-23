

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
using Yoyosoft.BookList.BookListManagement.Relationships;


namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.DomainService
{
    /// <summary>
    /// CloludBookList领域层的业务管理
    ///</summary>
    public class CloludBookListManager :BookListDomainServiceBase, ICloludBookListManager
    {
		
		private readonly IRepository<CloludBookList,long> _repository;

        private readonly IRepository<BookListAndBook, long> _bookListAndBookRepository;

		/// <summary>
		/// CloludBookList的构造方法
		///</summary>
		public CloludBookListManager(
			IRepository<CloludBookList, long> repository, IRepository<BookListAndBook, long> bookListAndBookRepository)
		{
		    _repository =  repository;
		    _bookListAndBookRepository = bookListAndBookRepository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitCloludBookList()
		{
			throw new NotImplementedException();
		}

        public async Task CreateBookListAndBookRelationship(long bookListId, List<long> bookIds)
        {

            await _bookListAndBookRepository.DeleteAsync(a => a.CloudBookListId == bookListId);

            await CurrentUnitOfWork.SaveChangesAsync();

            var InsertdBookIds=new List<long>();

            foreach (var bookId in bookIds)
            {
                if (InsertdBookIds.Exists(a => a == bookId))
                {
                    continue;
                }

                await _bookListAndBookRepository.InsertAsync(new BookListAndBook()
                {
                    BookId = bookId,
                    CloudBookListId = bookListId
                });

                InsertdBookIds.Add(bookId);

            }

        }

        public async Task DeleteByBookId(long? bookId)
        {

            await _bookListAndBookRepository.DeleteAsync(a => a.BookId == bookId.Value);

        }

        public async Task DeleteByBookId(List<long> bookIds)
        {
            await _bookListAndBookRepository.DeleteAsync(a => bookIds.Contains(a.BookId));
        }

        public async Task DeleteByBookListId(long? bookListId)
        {
            await _bookListAndBookRepository.DeleteAsync(a => a.CloudBookListId == bookListId);
        }

        public async Task DeleteByBookListId(List<long> bookListIds)
        {
            await _bookListAndBookRepository.DeleteAsync(a => bookListIds.Contains(a.CloudBookListId));
        }

        // TODO:编写领域业务代码



		 
		  
		 

	}
}
