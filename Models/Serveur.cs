using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{
    public class Serveur
    {
        [Key]
        public int IDServeur{ get; set; }
        public string NameServeur { get; set; }
        public string PhoneServeur { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
        

    }
}
