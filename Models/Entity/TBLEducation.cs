//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CemKeskin.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLEducation
    {
        public int Id { get; set; }
        public string EducationTitle { get; set; }
        public string EducationYear { get; set; }
        public string EducationContent { get; set; }
        public string EducationIcon { get; set; }
        public Nullable<int> ResumeId { get; set; }
    
        public virtual TBLResume TBLResume { get; set; }
    }
}
