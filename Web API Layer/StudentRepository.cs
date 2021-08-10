using Human.SP.WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Human.SP.WebAPI.Repository
{
    /// <summary>
    /// this will handle parent/child processes
    /// </summary>
    public class ChildRepository
    {
     
        public static ChildModel AddChild(ChildModel childModel)
        {
            try
            {
                if (childModel == null)
                    return null;

                  Child child = null;

                    using (DBEntities DB = new DBEntities())
                    {
                        if (childModel.ChildID == 0)
                        {
                            child = new Child()
                            {
                                //set the data
                            };
                            DB.Child.Add(child);
                        }
                        else
                        {
                            child = DB.Child.Where(c => c.ChildID == childModel.ChildID).FirstOrDefault();
                            if (child != null)
                            {
                               //set the updated data
                            }
                        }
                        DB.SaveChanges();
                    }
                    childModel.ChildID = child.ChildID;             
            }
            catch (Exception ex)
            {
               //log exception
            }
            return childModel;
        }

    
        /// <summary>
        /// get from database by childID
        /// </summary>
        /// <param name="childID"></param>
        /// <returns></returns>
        public static ChildModel GetChildByID(int childID)
        {
            ChildModel childModel = null;
            try
            {
                using (DBEntities DB = new DBEntities())
                {
                    var query = from c in DB.Child
                                where (c.ChildID == childID)
                                select new ChildModel()
                                {
                                   
                                    ChildName = c.ChildName,
                                    DateOfBirth = c.DateOfBirth,
                                    Gender = c.Gender,
                                    CreatedBy = c.CreatedBy,
                                    Created = c.Created,
                                    ModifiedBy = c.ModifiedBy,
                                    Modified = c.Modified
                                };

                    childModel = query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
              //log exception
            }
            return childModel;
        }

      
    }