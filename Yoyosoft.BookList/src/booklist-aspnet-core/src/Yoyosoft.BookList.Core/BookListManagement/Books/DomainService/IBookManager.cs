

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Yoyosoft.BookList.BookListManagement;
using Yoyosoft.BookList.BookListManagement.Relationships;


namespace Yoyosoft.BookList.BookListManagement.DomainService
{
    public interface IBookManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitBook();



        Task<List<BookAndBookTag>> GetTagsByBookId(long bookId);

        Task<List<BookAndBookTag>> GetBooksByTagId(long bookId);

        Task CreateBookAndBookTagRelationship(long bookId, List<long> tagIds);



    }
}
