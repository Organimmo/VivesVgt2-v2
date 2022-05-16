using System.ComponentModel.DataAnnotations;

namespace Organimmo.Services.Model
{
    public class ItemDto
    {
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Base Text")]
        public string BaseText { get; set; }

        [Display(Name = "Current Text")]
        public string CurrentText { get; set; }
    }

    
}