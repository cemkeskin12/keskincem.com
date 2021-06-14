using CemKeskin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemKeskin.Models.Classes
{
    public class ForAdmin
    {
        public IEnumerable<TBLAboutMe> AboutPage { get; set; }

        public IEnumerable<TBLEducation> EducationPage { get; set; }

        public IEnumerable<TBLExperiences> ExpPage { get; set; }

        public IEnumerable<TBLServices> ServicePage { get; set; }

        public IEnumerable<TBLReferences> ReferencePage { get; set; }

        public IEnumerable<TBLSocialMedia> SocialMediaPage { get; set; }

        public IEnumerable<TBLLogin> Login { get; set; }

        public IEnumerable<TBLResume> ResumePage { get; set; }
    }
}