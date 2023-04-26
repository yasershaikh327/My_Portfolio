namespace Portfolio.Models
{
    public class MailModel
    {
        public string name { get;set;}
        public string email { get;set;}
        public string subject { get;set;}
        public string message { get;set;}

        public bool nameC { get; set; }
        public bool emailC { get; set; }
        public bool subjectC { get; set; }
        public bool messageC { get; set; }
    }
}
