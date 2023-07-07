using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs
{
    public class SelectedMusicianDTO
    {
        public SelectedMusicianDTO()
        {
            Name = "";
            Category = "";
        }

        
        public string Name {  get; set; }
        
        public string Category {  get; set; }
    }
}
