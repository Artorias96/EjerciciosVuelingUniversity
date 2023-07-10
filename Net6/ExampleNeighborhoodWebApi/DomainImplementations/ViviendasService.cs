using DomainContracts.DomainEntities;
using DomainContracts.RepositoryContracts;
using DomainContracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainImplementations
{
    public class ViviendasService : IViviendasService
    {
        private readonly IPreciosRepository _preciosRepository;
        private readonly IViviendasRepository _viviendasRepository;
        private readonly IBarriosRepository _barriosRepository;
        private readonly ICacheRepository _cacheRepository;

        public ViviendasService(IPreciosRepository preciosRepository, IViviendasRepository viviendasRepository, IBarriosRepository barriosRepository, ICacheRepository cacheRepository)
        {
            _preciosRepository = preciosRepository;
            _barriosRepository = barriosRepository;
            _viviendasRepository = viviendasRepository;
            _cacheRepository = cacheRepository;
        }
        public async Task<PrecioCasa>GetViviendaById(int id)
        {
            {
            PrecioCasa resultTotalCost = _cacheRepository.GetCache<PrecioCasa>("1");

            if (resultTotalCost != null)
                return resultTotalCost;
            }

            PrecioCasa precioCasa = new PrecioCasa();

            List<Viviendas> viviendasList = await _viviendasRepository.GetAll();
            _viviendasRepository.SaveViviendasInFile(viviendasList);
           
            List<Barrios> barriosList = await _barriosRepository.GetAll();
            _barriosRepository.SaveBarriosInFile(barriosList);

            Viviendas viviendaSelectedById = viviendasList.FirstOrDefault(vivienda => vivienda.Id == id);

            if (viviendaSelectedById == null) return null;

            Barrios barrioSelected = barriosList.FirstOrDefault(barrio => barrio.Id == viviendaSelectedById.IdBarrio);

            Precios preciosZonas = await _preciosRepository.GetAll();
            _preciosRepository.SavePreciosInFile(preciosZonas);

            decimal costeTotal = viviendaSelectedById.M2 * barrioSelected.CosteM2;


            foreach (var añadido in viviendaSelectedById.Añadidos.Keys)
            {
                decimal precioM2Añadido = preciosZonas.Añadidos[añadido].PrecioM2;
                decimal precioBase = preciosZonas.Añadidos[añadido].Precio;

                if(precioM2Añadido != 0)
                {
                    costeTotal += precioM2Añadido * viviendaSelectedById.Añadidos[añadido];
                }
                else
                {
                    costeTotal += precioBase;
                }

            }
            
            precioCasa.Id = id;
            precioCasa.PrecioTotal = costeTotal;

            _cacheRepository.SetCache<PrecioCasa>("1", precioCasa);

            return precioCasa;

        }
    }
}
