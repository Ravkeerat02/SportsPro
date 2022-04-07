using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBC.Models
{

    public class ProductManager
    {

        public int Id { get; set; }

        [StringLength(10, MinimumLength = 3), Required]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }


        [StringLength(60, MinimumLength = 3), Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Column(TypeName = "decimal(18, 2)"), Required]
        public decimal Price { get; set; }

        [Display(Name = "Release Date"), Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
    public class TechManager
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2), Required]
        [Display(Name = "Technician Name")]
        public string TechName { get; set; }


        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Technician Email")]
        public string TechEmail { get; set; }


        [StringLength(10), Required]
        [Display(Name = "Technician Phone")]
        public string TechPhone { get; set; }
    }

    public class CustomerManager
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2), Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }


        [StringLength(60, MinimumLength = 1), Required]
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }


        [StringLength(60, MinimumLength = 1), Required]
        [Display(Name = "Customer City")]
        public string CustomerCity { get; set; }


        [StringLength(60, MinimumLength = 1), Required]
        [Display(Name = "Customer State")]
        public string CustomerState { get; set; }


        [StringLength(6, MinimumLength = 6), Required]
        [Display(Name = "Customer Postal")]
        public string CustomerPostal { get; set; }

        [Display(Name = "Customer Country"), Required]
        public CustomerCountry Country { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Customer Email")]
        public string? CustomerEmail { get; set; }

        [StringLength(10)]
        [Display(Name = "Customer Phone")]
        public string? CustomerPhone { get; set; }

        public enum CustomerCountry
        {
            Canada,
            USA
        }
    }
    public class IncidentPage
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2), Required]
        [Display(Name = "Product Name")]
        public string Product { get; set; }


        [StringLength(60, MinimumLength = 2), Required]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 2), Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Technician Name")]
        public string TechName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Opened"), Required]
        public DateTime DateOpened { get; set; }

        [Display(Name = "Date Closed")]
        [DataType(DataType.Date)]
        public DateTime DateClosed { get; set; }
    }
}

