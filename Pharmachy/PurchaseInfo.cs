using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pharmachy
{
    class PurchaseInfo
    {
        private String _purchaseDate;
        private String _updateDate;

        public String User { get; set; }
        public String PurchaseId { get; set; }
        public String SupplierId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public String PurchaseDate
        {
            get { return _purchaseDate; }
        }

        public String AddedBy { get; set; }
        public String AddedComputer { get; set; }
        public String UpdateBy { get; set; }
        public String UpdateComputer { get; set; }

        public String MedicineId { get; set; }

        public String UpdateDate
        {
            get { return _updateDate; }
        }


        public void AddPurchaseDate(String purchaseDate)
        {
            this._purchaseDate = purchaseDate;
        }

        public void AddUpdateDate(String updateDate)
        {
            this._updateDate = updateDate; 
        }
    }
}
