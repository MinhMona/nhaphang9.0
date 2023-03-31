using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities.DomainEntities
{
    public class BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        /// <summary>
        /// Primary key
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        public double? Created { get; set; }

        /// <summary>
        /// Account create
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Update date
        /// </summary>
        public double? Updated { get; set; }

        /// <summary>
        /// Account update
        /// </summary>
        public string UpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Delete flag
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Active flag
        /// </summary>
        public bool Active { get; set; } = true;

        /// <summary>
        /// Auto increase number id
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int NumberId { get; set; }
    }
}
