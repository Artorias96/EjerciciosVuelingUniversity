using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class MusicianNeedForMeetingInfo
    {

        public string Category { get; set; } = "";

        public int Amount { get; set; }
    }
}
