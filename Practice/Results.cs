//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practice
{
    using System;
    using System.Collections.Generic;
    
    public partial class Results
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public Nullable<int> id_work { get; set; }
        public Nullable<int> id_service { get; set; }
        public string result { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual users users { get; set; }
        public virtual Workers Workers { get; set; }
    }
}
