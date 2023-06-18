using Infrastructure.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Business.ServiceImplementations
{
    public class CommonService
    {
        public async Task<DittoModel> ServiceMethod()
        {
            DittoModel result = await new CommonRepository().repoMethod();

            return result;
        }
    }
}
