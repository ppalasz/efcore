using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoviesApp.DAL.Models
{
    public enum Sex { Male, Female }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Sex Sex { get; set; }


        [ForeignKey("AddressID")]
        public int AddressID { get; set; } //będzie unique  index -> relacja 1:1
        public Address Address
        {
            get;
            set;
        }
    }
}
