using Business.DTOS;
using Domain.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IStockElementService
    {
        StockElementDto GetElementByClue(string clue);
        void CreateElement(StockElement stockElement);
        bool ValidateClueFormat(string clue);
    }
}
