namespace CrmBl.Model
{
    class Check
    {
        public int CheckId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
