//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace chicken0122.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tRent
    {
        public int fRentID { get; set; }
        public int fOrderID { get; set; }
        public int fOptionID { get; set; }
        public int fRentAmount { get; set; }
    
        public virtual tOptionCase tOptionCase { get; set; }
        public virtual tOrder tOrder { get; set; }
    }
}
