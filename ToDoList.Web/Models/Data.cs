using Newtonsoft.Json;

namespace ToDoList.Web.Models
{
    public class Data
    {
        public int idList { get; set; }
        public string nameList { get; set; }
        public string colorHexList { get; set; }
        public int statusList { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }

        [JsonIgnore]
        public ICollection<ListItem> listItems { get; set; }
    }
}
