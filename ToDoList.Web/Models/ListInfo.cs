﻿namespace ToDoList.Web.Models
{
    public class listInfo
    {
        public string success { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public string url { get; set; }
        public List<data> data { get; set; }
    }

}
