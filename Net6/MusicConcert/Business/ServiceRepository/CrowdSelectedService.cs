using Business.ServiceContracts;
using Domain.Agregates;
using DTOs;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceRepository
{
    public class CrowdSelectedService : ICrowdSelectedService
    {
        private readonly IUnavaiableDaysRepository _unavaiableDaysRepository;
        private readonly IMusiciansRepository _musiciansRepository;
        private readonly IPeopleNeedForMeetingRepository _peopleNeedForMeetingRepository;
        public CrowdSelectedService(IUnavaiableDaysRepository unavaiableDaysRepository, IMusiciansRepository musiciansRepository, IPeopleNeedForMeetingRepository peopleNeedForMeetingRepository)
        {
            _unavaiableDaysRepository = unavaiableDaysRepository;
            _musiciansRepository = musiciansRepository;
            _peopleNeedForMeetingRepository = peopleNeedForMeetingRepository;
        }
        public List<SelectedMusicianDTO> SelectCrowdForMeeting(DateTime dayOfMeeting)
        {
            List<SelectedMusicianDTO> result = new();

            UnavaiableDaysList unavaiableDaysFromCrowd = _unavaiableDaysRepository.GetAll();

            List<string> peopleUnavailableForGivenDay = unavaiableDaysFromCrowd.GetNamesOfPeopleUnavailableByDay(dayOfMeeting);

            MusicianList listOfMusician = _musiciansRepository.GetAll();
            MusicianList listOfMusicianFiltered = new()
            {
                musicianList = listOfMusician.FilterByNotContainedInNameList(peopleUnavailableForGivenDay),
            };


            MusicianNeedForInfoList musicianNeeds = _peopleNeedForMeetingRepository.GetAll();
            result = musicianNeeds.SelectMusicianAccordingToNeeds(listOfMusicianFiltered);

            return result;
        }
    }
}
