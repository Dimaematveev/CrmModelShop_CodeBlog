namespace CrmBl.Model
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string Name{ get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
