using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.ViewModels
{
    public class DeleteOrderVM
    {
        public int OrderID { get; set; }

        public bool IsActive { get; set; }

        public List<KeyValuePair<int,bool>> OrderDetails { get; set;}


    }
}
