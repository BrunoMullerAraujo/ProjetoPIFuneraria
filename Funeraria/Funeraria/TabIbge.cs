//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Funeraria
{
    using System;
    using System.Collections.Generic;
    
    public partial class TabIbge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TabIbge()
        {
            this.Cidade = new HashSet<Cidade>();
        }
    
        public int CodigoIbge_ibg { get; set; }
        public string DescricaoIbge_ibg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}
