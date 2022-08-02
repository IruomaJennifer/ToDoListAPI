using static CCSANoteApp.Domain.Enums;

namespace CCSA_Web.DTO
{
    public class NoteDTO
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public GroupName GroupName { get; set; }
    }
}
