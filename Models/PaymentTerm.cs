namespace Phoenix.Models
{
    public class PaymentTerm    {
        public int Id { get; set; }

        public string ? Name { get; set; }

        public int Installments { get; set; }

        public int Period { get; set; }

        public float Fees { get; set; }


    }
}
