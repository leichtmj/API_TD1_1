namespace API_TD1_1.Models.DTO
{
    public class MarqueDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int NbProduits { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MarqueDTO dTO &&
                   this.Id == dTO.Id &&
                   this.Nom == dTO.Nom &&
                   this.NbProduits == dTO.NbProduits;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Nom, this.NbProduits);
        }
    }
}
