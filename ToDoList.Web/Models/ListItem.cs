using Microsoft.VisualBasic;

namespace ToDoList.Web.Models
{
    public class ListItem
    {
        public int idListItem { get; set; }
        public string nameListItem { get; set; }
        public string descListItem { get; set; }
        public int isDoneListItem { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public int idList { get; set; }

    }
}
