using Organimmo.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organimmo.Services.Model
{
    public class RootDto
    {
        [Display(Name = "Id")]
        public string? id { get; set; }

        [Display(Name = "Application Name")]
        public string? ApplicationName { get; set; }

        [Display(Name = "Application Version")]
        public string? ApplicationVersion { get; set; }

        [Display(Name = "Customer")]
        public string? Customer { get; set; }

        [Display(Name = "UserName")]
        public string? Username { get; set; }

        [Display(Name = "Language")]
        public string? Language { get; set; }

        [Display(Name = "Window")]
        public List<Window>? Window { get; set; }
    }
}
