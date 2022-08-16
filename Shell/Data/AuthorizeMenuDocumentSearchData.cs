namespace Shell.Data
{
    public class AuthorizeMenuDocumentSearchData
    {
        public int? doc_id { get; set; }
        public string? doc_name { get; set; }

        public bool? create_per { get; set; }
        public bool? edit_per { get; set; }
        public bool? view_per { get; set; }
        public bool? delete_per { get; set; }
        public bool? approve_per { get; set; }
        public bool? print_per { get; set; }
        public bool? export_per { get; set; }


        public bool? doc_used { get; set; }

        public bool? create_use { get; set; }
        public bool? edit_use { get; set; }
        public bool? view_use { get; set; }
        public bool? delete_use { get; set; }
        public bool? approve_use { get; set; }
        public bool? print_use { get; set; }
        public bool? export_use { get; set; }


        public bool? create_check { get; set; }
        public bool? edit_check { get; set; }
        public bool? view_check { get; set; }
        public bool? delete_check { get; set; }
        public bool? approve_check { get; set; }
        public bool? print_check { get; set; }
        public bool? export_check { get; set; }
    }
}
