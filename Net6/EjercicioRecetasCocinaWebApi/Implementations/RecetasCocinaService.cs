using Contracts.DomainEntitites;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;

namespace Implementations
{
    public class RecetasCocinaService : IRecetasCocinaService
    {
        private readonly IAlimentosRepository _alimentosRepository;
        private readonly IPrecioCocinadoRepository _precioCocinadoRepository;
        private readonly IRecetasRepository _recetasRepository;
        private readonly ICacheRepository _cacheRepository;

        public RecetasCocinaService(IAlimentosRepository alimentosRepository, IPrecioCocinadoRepository precioCocinadoRepository, IRecetasRepository recetasRepository, ICacheRepository cacheRepository)
        {
            _alimentosRepository = alimentosRepository;
            _precioCocinadoRepository = precioCocinadoRepository;
            _recetasRepository = recetasRepository;
            _cacheRepository = cacheRepository;
        }
        public CosteTotal GetRecipeByName(string recipeName)
        {
            // Antes de obtener la receta, verifica si hay una caché válida y la utiliza

            CosteTotal resultTotalCost = _cacheRepository.GetCache<CosteTotal>(recipeName);
            
            if (resultTotalCost != null)
            {
                return resultTotalCost;
            }
            List<Alimentos> alimentosFromJson = _alimentosRepository.GetAll();

            PrecioCocinado precioCocinadoPorMinuto = _precioCocinadoRepository.GetPrecioCocinado();

            Recetas receta = _recetasRepository.GetRecipeByName(recipeName);

            if (receta == null) return null;

            decimal costeCocinado = precioCocinadoPorMinuto.CostePorMinuto * receta.MinutosCocinando;
            decimal  precioReceta = 0;
            foreach (var ingrediente in receta.Ingredientes)
            {
                var alimento = alimentosFromJson.FirstOrDefault(a => a.Nombre == ingrediente.Key);
                if (alimento != null)
                {
                    precioReceta += alimento.Precio * ingrediente.Value;
                }
            }
            precioReceta += costeCocinado;

            CosteTotal result = new CosteTotal
            {
                PrecioTotal = precioReceta
            };

            _cacheRepository.SetCache<CosteTotal>(recipeName, result);

            return result;
            // Guarda los productos en la caché
           
        }
    }
}
