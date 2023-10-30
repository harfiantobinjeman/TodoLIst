namespace ToDoList.Web.Models
{
    public class listItem
    {
        public int idListItem { get; set; }
        public string nameListItem { get; set; }
        public string descListItem { get; set; }
        public string isDoneListItem { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public int idList { get; set; }
    }
}
