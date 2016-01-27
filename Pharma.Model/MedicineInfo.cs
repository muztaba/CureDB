using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharma.Model
{
  public  class MedicineInfo
    {
      public string MedicineID { get; set; }
      public string MedicineBrandName { get; set; }
      public string Contains { get; set; }
      public string Dosage { get; set; }
      public string Manufacturar { get; set; }
      public decimal Price { get; set; }
    }
}
