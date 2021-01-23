using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCrud.Models.Customer
{
    public class CustomerModel
    {
        #region Attributes
        public int Id { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string City { get; set; }


        public string Country { get; set; }


        public string Phone { get; set; }
        #endregion

        #region Constructors
        public CustomerModel() { }
        #endregion
    }
}
