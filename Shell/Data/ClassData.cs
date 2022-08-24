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
}
