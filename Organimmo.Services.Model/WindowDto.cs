using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organimmo.DAL;

namespace Organimmo.Services.Model
{
    public class WindowDto
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Items")]
        public List<Item> Items { get; set; }
    }
}
