using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ToDoList.Web.Models
{
    public class data
    {
        public int idList { get; set; }
        public string nameList { get; set; }
        public string colorHexList { get; set; }
        public int statusList { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }

        //public Collection<ListItem> list { get; set; }
        //public ICollection<List<Data>> list { get; set; }
        public List<listItem> listItems { get; set;}
        
    }
}
