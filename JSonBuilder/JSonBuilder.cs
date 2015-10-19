using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSonLib
{
    public class JSonBuilder
    {
        public JSonBuilder()
        {

        }

        public String ListToJSon(String listName, IList list)
        {
            if (list == null || listName == null)
                return null;
            if (list.Count == 0)
                return null;
            String result = $"{{\"{listName}\" : ";
            String elements = ""; 
            foreach (var item in list)
            {
                elements += $",\"{item}\"";
            }
            return ( result + "["+ elements.Remove(0,1) + "]}").Replace(@"\", @"\\");
        }
    }
}
