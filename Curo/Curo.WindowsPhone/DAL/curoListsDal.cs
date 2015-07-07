using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curo.DataModel;

namespace Curo.DataModel
{
    public class curoListsDal
    {

        public async Task<List<curoLists>> GetListsAync()
        {
            var query = ParseObject.GetQuery("lists");


            IEnumerable<ParseObject> result = new List<ParseObject>();


            result = await query.FindAsync();

            var listItems = new List<curoLists>();
            foreach (var listItemParseObject in result)
            {
                var listItem = await curoLists.CreateFromParseObject(listItemParseObject);
                listItems.Add(listItem);
            }
            return listItems;




        }
    }
}
