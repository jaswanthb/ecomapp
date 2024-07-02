using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.ViewModels
{
    public class ResponseMessage
    {
        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

    }
}
