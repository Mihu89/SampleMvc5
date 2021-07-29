using SampleMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvc5.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}