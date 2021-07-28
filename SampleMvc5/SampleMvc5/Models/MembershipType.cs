namespace SampleMvc5.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
    }
}