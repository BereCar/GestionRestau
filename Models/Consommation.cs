using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{
    public class Consommation
    {
        [Key]
        public int  IDConsommation { get; set; }
       
        public virtual Table tableconso { get; set; }
        public int IDTable  { get; set; }
        public DateTime DateConsommation{ get; set; }
        public int QuantiteConsommation { get; set; }
        public bool Paye { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
        public int IDProduit { get; set; }

    }
}
