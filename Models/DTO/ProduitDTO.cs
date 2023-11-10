namespace API_TD1_1.Models.DTO
{
    public class ProduitDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }
        public string Marque { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProduitDTO dTO &&
                   this.Id == dTO.Id &&
                   this.Nom == dTO.Nom &&
                   this.Type == dTO.Type &&
                   this.Marque == dTO.Marque;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Nom, this.Type, this.Marque);
        }
    }
}
