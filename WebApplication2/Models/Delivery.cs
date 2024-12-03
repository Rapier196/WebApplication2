namespace WebApplication2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("delivery")]
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }

        [Required]
        [Column("delivery_id")]
        public int DeliveryId { get; set; }

        [StringLength(100)]
        [Column("service_status")]
        public string ServiceStatus { get; set; } = string.Empty; // Исправлено

        [StringLength(255)]
        [Column("delivery_status")]
        public string? DeliveryStatus { get; set; }

        [StringLength(255)]
        [Column("sending_from")]
        public string? SendingFrom { get; set; }

        [StringLength(255)]
        [Column("sending_where")]
        public string? SendingWhere { get; set; }
    }
}
