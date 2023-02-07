namespace BuberBreakfast.Entities
{
    public class BreakFast
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;  
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
