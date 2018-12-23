

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;
using Yoyosoft.BookList.BookListManagement.Relationships;


namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.DomainService
{
    public interface ICloludBookListManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitCloludBookList();


        Task CreateBookListAndBookRelationship(long bookListId, List<long> bookIds);


        Task DeleteByBookId(long? bookId);

        Task DeleteByBookId(List<long> bookIds);

        Task DeleteByBookListId(long? bookListId);

        Task DeleteByBookListId(List<long> bookListIds);


        Task<List<BookListAndBook>> GetByBookListId(long? bookListId);

        Task<List<BookListAndBook>> GetByBookId(long? bookId);


    }
}
