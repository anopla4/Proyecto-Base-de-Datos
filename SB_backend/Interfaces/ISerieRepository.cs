using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface ISerieRepository
    {
        List<Serie> GetSeries();
        Serie GetSerie(Guid id, DateTime initDate, DateTime endDate);

        Serie AddSerie(Serie serie);

        bool RemoveSerie(Guid Id, DateTime InitDate, DateTime EndDate);

        Serie UpdateSerie(Serie serie);
    }
}
