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
    
    public partial class tTent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tTent()
        {
            this.tOrder = new HashSet<tOrder>();
            this.tTentPhoto = new HashSet<tTentPhoto>();
        }
    
        public int fTentID { get; set; }
        public int fCampsiteID { get; set; }
        public string fTentName { get; set; }
        public string fTentCategory { get; set; }
        public int fTentPeople { get; set; }
        public int fTentPriceWeekday { get; set; }
        public int fTentPriceWeekend { get; set; }
        public int fTendPriceHoliday { get; set; }
    
        public virtual tCampsite tCampsite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOrder> tOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tTentPhoto> tTentPhoto { get; set; }
    }
}
