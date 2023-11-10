namespace API_TD1_1.Models.DTO
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

        public override bool Equals(object obj)
        {
            return obj is ProduitDetailDTO dTO &&
                   this.Id == dTO.Id &&
                   this.Nom == dTO.Nom &&
                   this.Type == dTO.Type &&
                   this.Marque == dTO.Marque &&
                   this.Description == dTO.Description &&
                   this.Nomphoto == dTO.Nomphoto &&
                   this.Uriphoto == dTO.Uriphoto &&
                   this.Stock == dTO.Stock &&
                   this.EnReappro == dTO.EnReappro;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.Nom);
            hash.Add(this.Type);
            hash.Add(this.Marque);
            hash.Add(this.Description);
            hash.Add(this.Nomphoto);
            hash.Add(this.Uriphoto);
            hash.Add(this.Stock);
            hash.Add(this.EnReappro);
            return hash.ToHashCode();
        }
    }
}
