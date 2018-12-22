
using Abp.Runtime.Validation;
using Yoyosoft.BookList.Dtos;
using Yoyosoft.BookList.BookListManagement.BookTags;

namespace Yoyosoft.BookList.BookListManagement.BookTags.Dtos
{
    public class GetBookTagsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
