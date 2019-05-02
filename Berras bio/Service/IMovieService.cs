using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerrasBio;

namespace BerrasBio
{
    public interface IMovieService
    {
        Task<Movies> GetByID(int id);

        Task<Movies> GetAll();
    }
}
