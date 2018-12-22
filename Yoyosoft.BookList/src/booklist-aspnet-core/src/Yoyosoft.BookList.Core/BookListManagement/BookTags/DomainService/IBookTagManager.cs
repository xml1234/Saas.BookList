

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Yoyosoft.BookList.BookListManagement.BookTags;


namespace Yoyosoft.BookList.BookListManagement.BookTags.DomainService
{
    public interface IBookTagManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitBookTag();


        Task<List<BookTag>> GetAll();




    }
}
