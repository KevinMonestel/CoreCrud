using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreCrud.ViewModels.Customer
{
    public class CustomerViewModel
    {
        #region Attributes
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }
        #endregion

        #region Constructors
        public CustomerViewModel() { }
        #endregion
    }
}
