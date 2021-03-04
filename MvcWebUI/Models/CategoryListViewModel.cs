using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categorys { get; set; }
        public int CurrentCategory { get; set; }
    }
}
