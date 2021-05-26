using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface ISerieRepository
    {
        List<Serie> getSeries();
        Serie getSerie(Guid id);

        Serie AddSerie(Serie serie);

        bool RemoveSerie(Serie serie);

        Serie UpdateSerie(Serie serie);
    }
}
