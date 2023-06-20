using Business.RepositoryContracts;
using Domain.EntitiesDomain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class StockManagementRepository : IStockManagementRepository
    {
        private readonly string _localDbRelPath;

        public StockManagementRepository()
        {
            _localDbRelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "StockDatabase.txt");
        }

        public void Insert(StockEntityDomain entity)
        {

        }

        public List <string> GetIds()
        {
            string textInFile = File.ReadAllText(_localDbRelPath);
            
            if(textInFile != "")
            {
                List<StockEntityDomain> domainlist = JsonConvert.DeserializeObject<List<StockEntityDomain>>(textInFile);

                List<string> ids = new List<string>();

                foreach(StockEntityDomain stock in domainlist)
                {
                    domainlist.Add(stock);
                }
                return ids;
            }
            else
            {
                return new List<string>();
            }
        }

        public string InsertIntoFile(StockEntityDomain stockdomain)
        {
            string textInFile = File.ReadAllText(_localDbRelPath);

            if (textInFile != "")
            {
                List<StockEntityDomain> domainlist = JsonConvert.DeserializeObject<List<StockEntityDomain>>(textInFile);

                domainlist.Add(stockdomain);

                string domainstring = JsonConvert.SerializeObject(domainlist);

                File.WriteAllText(_localDbRelPath, domainstring);

                return stockdomain.


            }
            else
            {
                return new List<string>();
            }

        }
        
    }
}
