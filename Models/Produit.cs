using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{
    public class Produit
    {
        [Key]
        public int IDProduit { get; set; }
        public string NameProduit { get; set; }
        public string DescriptionProduit { get; set; }
        public float PrixProduit { get; set; }
        public string CategorieProduit { get; set; }
        public string StatutProduit { get; set; }
        public string CentreDeRevenuProduit { get; set; }
        public int NbPersonnesProduit { get; set; }
        public virtual ICollection<Consommation> Consommations { get; set; }
    }
}
