//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRAKTIKA1
{
    using System;
    using System.Collections.Generic;
    
    public partial class INGREDIENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INGREDIENTS()
        {
            this.SUSHI_STORE = new HashSet<SUSHI_STORE>();
        }
    
        public int ID_INGREDIENT { get; set; }
        public string NAME_INGREDIENT { get; set; }
        public decimal GRAMMOVKA { get; set; }
        public string DESCRIPTION_INGREDIENT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUSHI_STORE> SUSHI_STORE {private get; set; }
    }
}
