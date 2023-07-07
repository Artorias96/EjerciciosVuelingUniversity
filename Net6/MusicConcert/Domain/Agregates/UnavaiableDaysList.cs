using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Agregates
{
    public class UnavaiableDaysList
    {
        public List<UnavaiableDaysInfo> List { get; set; } = new List<UnavaiableDaysInfo>();

        public List<string> GetNamesOfPeopleUnavailableByDay(DateTime day)
        {
            List<string> result = new();

            List<UnavaiableDaysInfo> dataFilteredByDay = FilterByDay(day);

            result = dataFilteredByDay.Select(x => x.Name).ToList();

            return result;
        }

        private List<UnavaiableDaysInfo> FilterByDay(DateTime day)
        {
            return List.Where(x => x.UnavaiableDays.Contains(day)).ToList();
        }
    }
}
