using SQLite;
using System;

namespace Farm
{
    public class CropSale
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string CropName { get; set; }

        [NotNull]
        public string Quantity { get; set; }

        [NotNull]
        public string Unit { get; set; }
        [Ignore]
        public string QuantityDisplay { get; set; }


        public DateTime HarvestDate { get; set; }
    }
}
