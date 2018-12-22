

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
using Yoyosoft.BookList.BookListManagement;
using Yoyosoft.BookList.BookListManagement.Relationships;


namespace Yoyosoft.BookList.BookListManagement.DomainService
{
    /// <summary>
    /// Book领域层的业务管理
    ///</summary>
    public class BookManager :BookListDomainServiceBase, IBookManager
    {
		
		private readonly IRepository<Book,long> _repository;

        private readonly IRepository<BookAndBookTag, long> _bookAndBookTagRepository;

		/// <summary>
		/// Book的构造方法
		///</summary>
		public BookManager(
			IRepository<Book, long> repository, IRepository<BookAndBookTag, long> bookAndBookTagRepository)
		{
		    _repository =  repository;
		    _bookAndBookTagRepository = bookAndBookTagRepository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitBook()
		{
			throw new NotImplementedException();
		}

        public async Task<List<BookAndBookTag>> GetTagsByBookId(long bookId)
        {
            var list = await _bookAndBookTagRepository.GetAll().AsNoTracking().Where(a => a.BookId == bookId)
                .ToListAsync();
            return list;
        }

        public async Task<List<BookAndBookTag>> GetBooksByTagId(long bookId)
        {
            var list = await _bookAndBookTagRepository.GetAll().AsNoTracking().Where(a => a.BookId == bookId)
                .ToListAsync();
            return list;
        }

        public async Task CreateBookAndBookTagRelationship(long bookId, List<long> tagIds)
        {
            await _bookAndBookTagRepository.DeleteAsync(a => a.BookId == bookId);
            await CurrentUnitOfWork.SaveChangesAsync();//手动处理掉数据

            var newBookTags=new List<long>();
            foreach (var tagId in tagIds)
            {
                if (newBookTags.Exists(a=>a==tagId))
                {
                    continue;
                }

                await _bookAndBookTagRepository.InsertAsync(new BookAndBookTag()
                {
                    BookId = bookId,
                    BookTagId = tagId
                });

                newBookTags.Add(tagId);
            }
        }

        // TODO:编写领域业务代码



		 
		  
		 

	}
}
