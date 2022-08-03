using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CCSANoteApp.Domain.Enums;

namespace CCSANoteApp.Domain
{
    public class Note
    {
        public Note()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public GroupName Group { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
