﻿namespace API_TD1_1.Models.DTO
{
    public class ProduitDetailDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }
        public string Marque { get; set; }

        public string Description { get; set; }
        public string Nomphoto { get; set; }
        public string Uriphoto { get; set; }
        public int Stock { get; set; }
        public bool EnReappro { get; set; }
    }
}
