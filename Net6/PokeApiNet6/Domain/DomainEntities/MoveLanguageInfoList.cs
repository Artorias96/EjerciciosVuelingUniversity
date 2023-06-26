using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class MoveLanguageInfoList
    {
        public List<MoveLanguageInfo>? MoveLanguageInfo { get; set; }

        public string GetMovementNameByLanguageId(string languageId)
        {
            return MoveLanguageInfo.FirstOrDefault(languagueInfo => languagueInfo.LanguageName == languageId).MoveName;
        }

        public void SetMovementNameByLanguageId(string v1, string v2)
            {
            throw new NotImplementedException();
        }
    }
}
