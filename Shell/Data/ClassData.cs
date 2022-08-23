namespace Shell.Data
{
    public class ListItem
    {
        public ListItem()
        {
        }
        public ListItem(string text,string value)
        {
            this.text = text;

            this.value = value;
        }
        public string text { get; set; }
        public string value { get; set; }
    }

    public class DataLines
    {
        public string to { get; set; }
        public string keyword_id { get; set; }
        public DataParams Params { get; set; }
    }
    public class DataParams
    {
        public string text { get; set; }
        public string acode { get; set; }
        public string name { get; set; }
    }
    public class DataTags
    {
        public string[] tags { get; set; }
    }
}
