﻿namespace Shell.Data
{
    public class AuthorizeMenuSearchData
    {
        public AuthorizeMenuSearchData()
        {
            this.doclist = new List<AuthorizeMenuDocumentSearchData>();
        }
        public int? Menu_id { get; set; }
        public string? Menu_Name { get; set; }
        public int? Menu_Main { get; set; }
        public int? Menu_Position { get; set; }
        public bool? Menu_Used { get; set; }
        public List<AuthorizeMenuDocumentSearchData> doclist { get; set; }
    }
}