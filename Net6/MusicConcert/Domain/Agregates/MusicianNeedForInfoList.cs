using Domain.DomainEntities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Agregates
{
    public class MusicianNeedForInfoList
    {
        public List<MusicianNeedForMeetingInfo> List { get; set; } = new();

        public List <SelectedMusicianDTO> SelectMusicianAccordingToNeeds(MusicianList musiciansInfo)
        {
            List<SelectedMusicianDTO> result = new();

            foreach(MusicianNeedForMeetingInfo musicianForMeetingInfo in List)
            {
                string categoryToFill = musicianForMeetingInfo.Category;
                List< MusiciansInfo> filteredAndOrderedList = musiciansInfo.FilterOrderedByRoleCountAscending(categoryToFill);
                if(filteredAndOrderedList.Count > 0)
                {
                    MusiciansInfo musicianToFill = filteredAndOrderedList[0];
                    result.Add(new SelectedMusicianDTO
                    {
                        Name = musicianToFill.Name,
                        Category = categoryToFill,
                    });
                }
            }


            return result;

        }
    }
}
