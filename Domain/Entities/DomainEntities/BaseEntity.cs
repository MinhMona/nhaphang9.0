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
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Update date
        /// </summary>
        public double? Updated { get; set; }

        /// <summary>
        /// Account update
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Delete flag
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Active flag
        /// </summary>
        public bool Active { get; set; } = true;

    }
}
