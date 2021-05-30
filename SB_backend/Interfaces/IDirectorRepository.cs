using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IDirectorRepository
    {
        List<Director> GetDirectors();
        Director GetDirector(Guid id);

        Director AddDirector(Director director);

        bool RemoveDirector(Guid Id);

        Director UpdateDirector(Director director);
    }
}
