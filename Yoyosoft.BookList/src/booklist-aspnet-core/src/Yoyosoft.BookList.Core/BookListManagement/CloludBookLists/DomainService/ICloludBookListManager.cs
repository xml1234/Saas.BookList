

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;


namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.DomainService
{
    public interface ICloludBookListManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitCloludBookList();



		 
      
         

    }
}
