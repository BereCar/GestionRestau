using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{
    public class Table
    {
        [Key]
        public int IDTable { get; set; }
        public int NumeroTable { get; set; }
        public int NbPlacesTable { get; set; }
        public virtual Serveur serveur { get; set; }
        public int IDServeur { get; set; }
        public bool OccupationTable { get; set; }
        public string EmplacementTable { get; set; }

        public virtual ICollection<Consommation> Consommations { get; set; }


    }
}
