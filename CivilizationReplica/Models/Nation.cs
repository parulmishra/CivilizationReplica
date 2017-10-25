using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivilizationReplica.Models
{
    [Table("Nations")]
    public class Nation
    {
        [Key]
        public int Id { get; set; }
        public string NationName { get; set; }
        public string GovernmentType { get; set; }
        public string EconomyType { get; set; }
        public string GeographyType { get; set; }

        public int Capital { get; set; }
        public int Resources { get; set; }
        public int Population { get; set; }
        public int Stability { get; set; }

        public virtual User User { get; set; }

        public Nation(string Nation, string Government, string Economy, string Geography)
        {
            NationName = Nation;
            GovernmentType = Government;
            EconomyType = Economy;
            GeographyType = Geography;
            Capital = 1000;
            Resources = 50;
            Population = 10000;
            Stability = 50;
        }
    }
}
