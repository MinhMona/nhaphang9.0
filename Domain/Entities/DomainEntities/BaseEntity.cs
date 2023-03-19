using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DomainEntities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public TimeSpan Created { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public TimeSpan Updated { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        public string UpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Cờ xóa
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Cờ active
        /// </summary>
        public bool Active { get; set; } = true;
    }
}
