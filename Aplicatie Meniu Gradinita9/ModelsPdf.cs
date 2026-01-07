namespace Aplicatie_Meniu_Gradinita9
{
    // Fix for CS0656: Remove 'required' keyword, as it requires .NET 7+ and proper compiler support.
    // Use nullable reference types or constructor initialization instead.

    internal class Raport
    {
        public int Id { get; set; }
        public Gradinita Gradinita { get; set; } // Removed 'required' keyword
        public DateTime Expirare { get; set; }
        public string Name { get; set; }

        public IEnumerable<RaportIntern> RaportInterns { get; set; }
        public decimal Total => RaportInterns.Sum(x => x.Total);

        // Optionally, add a constructor to ensure Gradinita is not null
        public Raport(Gradinita gradinita)
        {
            Gradinita = gradinita ?? throw new ArgumentNullException(nameof(gradinita));
        }
    }
    internal class Gradinita
    {
        // Removed 'required' keyword to fix CS0656 errors.
        public string Logo { get; set; }
        public string Name { get; set; }

    }
    internal class RaportIntern
    {
        public decimal Total { get; set; }
    }

}
