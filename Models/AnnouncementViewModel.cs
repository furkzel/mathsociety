using System.ComponentModel;

namespace mathsociety.Models
{
    public class AnnouncementViewModel
    {
        [DisplayName("AnnouncementID")]
        public int AnnouncementID { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Content")]
        public string Content { get; set; }
        [DisplayName("Date")]
        public DateTime Date { get; set; }
        [DisplayName("Author")]
        public string Author { get; set; }

    }
}
