using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IDirectorRepository
    {
        List<Director> getDirectors();
        Director getDirector(Guid id);

        Director AddDirector(Director director);

        bool RemoveDirector(Director director);

        Director UpdateDirector(Director director);
    }
}
