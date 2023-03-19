using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs.DomainSearchs
{
    public class BaseSearch
    {
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        [DefaultValue(1)]
        public int PageIndex { set; get; }

        /// <summary>
        /// Số lượng item trên 1 trang
        /// </summary>
        [DefaultValue(20)]
        public int PageSize { set; get; }

        /// <summary>
        /// Nội dung tìm kiếm chung
        /// </summary>
        public string? SearchContent { set; get; }

        /// <summary>
        /// Cột sắp xếp
        /// </summary>
        [DefaultValue("Id desc")]
        public string? OrderBy { set; get; }
    }
}
