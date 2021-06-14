using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CemKeskin.Models.Entity;

namespace CemKeskin.Models.Classes
{
    public class ForHome
    {
        public IEnumerable<TBLAboutMe> AboutPage { get; set; }

        public IEnumerable<TBLEducation> EducationPage { get; set; }

        public IEnumerable<TBLExperiences> ExpPage { get; set; }

        public IEnumerable<TBLServices> ServicePage { get; set; }

        public IEnumerable<TBLReferences> ReferencePage { get; set; }

        public IEnumerable<TBLSocialMedia> SocialMediaPage { get; set; }

        public IEnumerable<TBLResume> ResumePage { get; set; }


        //Login Burada yok Admin için Koyulacak.

    }
}