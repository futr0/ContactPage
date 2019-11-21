using System.ComponentModel.DataAnnotations;

namespace ContactPage.Models
{
    public partial class ContactMessages
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(200, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(200, MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [StringLength(22, MinimumLength = 9)]
        [Phone(ErrorMessage = "Phone number is invalid")]
        public string Phone { get; set; }

        [Display(Name = "Area of interest:")]
        [Required]
        public int AreaOfInterest { get; set; }

        [Display(Name = "Contact message")]
        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string ContactMessage { get; set; }

        public virtual MessagesAreaOfInterest AreaOfInterestNavigation { get; set; }
    }
}
