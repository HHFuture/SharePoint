using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.SP.SPModel
{
    [Serializable]
    public class ChildModel
    {
         public int ChildID { get; set; }       
        public string ChildName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }      
        public string Gender { get; set; }    
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
    }

    
}
