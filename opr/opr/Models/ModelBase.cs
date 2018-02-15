using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace opr.Models
{
    public class ModelBase
    {
        public opr.Models.oprEntities database = new opr.Models.oprEntities();

        public static void WriteLog(System.Data.Entity.Validation.DbEntityValidationException aa)
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/error.txt");
            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/error.txt");
            var e = aa;

            File.AppendAllText(@dataFile, "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + ": " + aa.ToString());
            foreach (var eve in e.EntityValidationErrors)
            {
                File.AppendAllText(@dataFile, "\r\n" + string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State));
                //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {

                    File.AppendAllText(@dataFile, "\r\n" + string.Format("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage));
                }
            }

            //foreach (var a in aa.EntityValidationErrors)
            //{
            //    File.AppendAllText(@dataFile, a.ToString());
            //}
            File.AppendAllText(@dataFile, "\r\n-------- end of " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "---------\n");
        }
        public static void WriteLog(Exception aa)
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/error.txt");
            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/error.txt");
            File.AppendAllText(@dataFile, DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + ": " + aa.ToString());
            File.AppendAllText(@dataFile, "-------- end of " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "---------");
        }
        public static void WriteLog(string aa)
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/error.txt");
            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/error.txt");
            File.AppendAllText(@dataFile, DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + ": " + aa.ToString());
        }
        public int SaveChanges()
        {

            int result = 0;
            try
            {
                //using (var trans = new TransactionScope())
                //{

                result = database.SaveChanges();
                result = 1;
                //    trans.Complete();
                //}
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                result = 0;
                WriteLog(e);
                //throw;
            }
            catch (Exception aa)
            {
                result = 0;
                WriteLog(aa);
            }
            return result;
        }

    }
}