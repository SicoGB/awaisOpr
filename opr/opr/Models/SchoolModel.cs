using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using opr.Models;

namespace opr.Models
{
    public class SchoolModel : ModelBase
    {
        public int Add(opr.Models.school s)
        {
            school schol = database.schools.Where(w => w.Name == s.Name).FirstOrDefault();
            if (schol != null)
            {
                return -1;
            }
            schol = null;
            schol = database.schools.Where(w => w.UserName == s.UserName).FirstOrDefault();//check if school with same username exist
            var user = database.users.Where(w => w.UserName == s.UserName).FirstOrDefault();// check if users with same user exist
            if (schol != null || user != null)
                return -2;

            s.UserID = Helpers.CurrentUser.UserID;
            s.LastEditedBy = Helpers.CurrentUser.UserID;
            s.LastEditedOn = DateTime.Now;
            s.Address = string.IsNullOrEmpty(s.Address) ? string.Empty : s.Address;
            s.Contact = string.IsNullOrEmpty(s.Contact) ? string.Empty : s.Contact;
            s.Email = string.IsNullOrEmpty(s.Email) ? string.Empty : s.Email;
            s.Mobile = string.IsNullOrEmpty(s.Mobile) ? string.Empty : s.Mobile;
            s.Princepal = string.IsNullOrEmpty(s.Princepal) ? string.Empty : s.Princepal;
            s.Website = string.IsNullOrEmpty(s.Website) ? string.Empty : s.Website;

            database.schools.Add(s);
            if (SaveChanges() > 0)
                return s.ID;
            else return 0;
        }
        public int Edit(school s)
        {
            s.LastEditedBy = Helpers.CurrentUser.UserID;
            s.LastEditedOn = DateTime.Now;
            database.Entry(s).State = System.Data.Entity.EntityState.Detached;
            database.Entry(s).State = System.Data.Entity.EntityState.Modified;
            return SaveChanges();

        }
        public int Update(opr.Models.school s)
        {
            var old = database.schools.Where(w => w.ID == s.ID).FirstOrDefault();
            //database.Entry(old).State = System.Data.Entity.EntityState.Detached;
            //database.Entry(s).State = System.Data.Entity.EntityState.Modified;

            if (s.Pasword == null) s.Pasword = old.Pasword;

            if (s.UserName == null) s.UserName = old.UserName;
            old.Address = s.Address;
            old.Contact = s.Contact;
            old.Email = s.Email;
            old.LastEditedBy = Helpers.CurrentUser.UserID;
            s.LastEditedOn = DateTime.Now;
            old.Mobile = s.Mobile;
            old.Name = s.Name;
            old.Princepal = s.Princepal;
            old.UserID = s.UserID;
            if (string.IsNullOrEmpty(s.Website)) old.Website = "";
            else old.Website = s.Website;
            s.LastEditedBy = Helpers.CurrentUser.UserID;
            s.LastEditedOn = DateTime.Now;
            old.IsExpired = s.IsExpired;
            old.IsActive = s.IsActive;
            old.Logo = s.Logo;
            foreach (var c in s.school_campus)
                old.school_campus.Add(c);

            return SaveChanges();
        }

        public bool Delete(int id)
        {
            school s = database.schools.FirstOrDefault(a => a.ID == id);
            return SaveChanges() > 0;
        }

        public List<school> GetAll()
        {
            List<opr.Models.school> o = database.schools.ToList();
            return o;
        }
        public school GetByID(int id)
        {
            school s = database.schools.FirstOrDefault(a => a.ID == id);
            return s;
        }


        public bool SchoolConfig(List<school_class> classes, List<school_class_group> groups, List<school_class_section> sections, List<school_class_subjects> subjects)
        {
            if (classes != null)
            {
                List<school_class> clases = database.school_class.ToList().Where(w => w.SchoolID == classes.FirstOrDefault().SchoolID).ToList();
                database.school_class.RemoveRange(clases);//.Where(w => !classes.Select(s => s.ClassID).Contains(w.ClassID)));
                foreach (var c in classes)
                {
                    //school_class clas = database.school_class.Where(w => w.SchoolID == c.SchoolID && w.ClassID == c.ClassID).FirstOrDefault();
                    //if (clas == null)
                    database.school_class.Add(c);

                }
            }
            if (groups != null)
            {
                List<school_class_group> grps = database.school_class_group.ToList().Where(w => w.SchoolID == groups.FirstOrDefault().SchoolID).ToList();
                database.school_class_group.RemoveRange(grps);//.Where(w => !groups.Select(s => s.ClassID).Contains(w.ClassID) && !groups.Select(s => s.GroupID).Contains(w.GroupID)));
                foreach (var g in groups)
                {
                    //school_class_group group = database.school_class_group.Where(w => w.SchoolID == g.SchoolID && w.GroupID == g.GroupID && w.ClassID == g.ClassID).FirstOrDefault();
                    //if (group == null)
                    database.school_class_group.Add(g);
                }
            }
            if (sections != null)
            {
                List<school_class_section> sct = database.school_class_section.ToList().Where(w => w.SchoolID == sections.FirstOrDefault().SchoolID).ToList();
                database.school_class_section.RemoveRange(sct);//.Where(w => !sections.Select(s => s.ClassID).Contains(w.ClassID) && !sections.Select(s => s.SectionID).Contains(w.SectionID)));
                foreach (var s in sections)
                {
                    //school_class_section secton = database.school_class_section.Where(w => w.SchoolID == s.SchoolID && w.SectionID == s.SectionID && w.ClassID == s.ClassID).FirstOrDefault();
                    //if (secton == null)
                    database.school_class_section.Add(s);
                }
            }
            if (subjects != null)
            {
                List<school_class_subjects> sbjs = database.school_class_subjects.ToList().Where(w => w.SchoolID == subjects.FirstOrDefault().SchoolID).ToList();
                database.school_class_subjects.RemoveRange(sbjs);//.Where(w => !subjects.Select(s => s.ClassID).Contains(w.ClassID) && !subjects.Select(s => s.SubjectID).Contains(w.SubjectID)));

                foreach (var s in subjects)
                {
                    //school_class_subjects subject = database.school_class_subjects.Where(w => w.SchoolID == s.SchoolID && w.SubjectID == s.SubjectID && w.ClassID == s.ClassID).FirstOrDefault();
                    //if (subject == null) 
                    database.school_class_subjects.Add(s);
                }
            }
            return SaveChanges() > 0;
        }

    }
}