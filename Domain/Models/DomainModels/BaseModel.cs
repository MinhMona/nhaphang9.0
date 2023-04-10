using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DomainModels
{
    public class BaseModel
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public double? Created { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public double? Updated { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Cờ xóa
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Cờ active
        /// </summary>
        public bool Active { get; set; }

    }
}
