using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Corte2025.FormationFred.DataContracts
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public required String Title { get; set; }
    }
}
