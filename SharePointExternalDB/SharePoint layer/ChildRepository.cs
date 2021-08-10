using Human.SP.SPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace Human.SP.SPRepository
{
    public class ChildRepository
    {
        public static async Task<ChildModel> SaveChild(ChildModel childModel)
        {
            using (HttpClient cons = HttpUtility.GetHttpClientConnection())
            {

                HttpResponseMessage res = await cons.PostAsJsonAsync("api/AddChild/", childModel);
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    childModel = await res.Content.ReadAsAsync<ChildModel>();
                }

                return childModel;
            }
        }

      
        public static async Task<ChildModel> GetChildByID(int childID)
        {
            using (HttpClient cons = HttpUtility.GetHttpClientConnection())
            {
                ChildModel childModel = new ChildModel(); 
                HttpResponseMessage res = await cons.GetAsync("api/GetChildByID/"+ childID);
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    childModel = await res.Content.ReadAsAsync<ChildModel>();
                }

                return childModel;
            }
        }

        
    }
}

