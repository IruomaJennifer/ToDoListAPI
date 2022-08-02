
using CCSANoteApp.Domain;
using static CCSANoteApp.Domain.Enums;

namespace CCSANoteApp.Infrastructure
{
    public class NoteService : INoteService
    {
        List<Note> notes = new List<Note>();

        public void CreateNote(Note note)
        {
            notes.Add(note);
        }

        public void CreateNote(Guid userId, string title, string content, GroupName group)
        {
            var user = UserService.users.FirstOrDefault(user => user.Id == userId);
            notes.Add(new Note
            {
                Title = title,
                Content = content,
                User = user,
                Group = group
            });
        }

        public void DeleteNote(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                notes.Remove(note);
            }
        }

        public void DeleteNote(List<Note> notes)
        {
            foreach (Note note in notes)
            {
                DeleteNote(note.Id);
            }
        }

        public List<Note> FetchNote()
        {
            return notes;
        }

        public List<Note> FetchNoteByGroup(Guid userId, GroupName group)
        {
            var _notes = notes.Where(x => x.User.Id == userId && x.Group == group);
            return notes.ToList();
        }

        public Note FetchNoteById(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            return note;
        }

        public List<Note> FetchNoteByUser(Guid id)
        {
            var _notes = notes.Where(x => x.User.Id == id);
            return notes.ToList();
        }

        public void UpdateNote(Guid id, Note note)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = note.Title;
                _note.Content = note.Content;
                _note.Group = note.Group;
            }
        }

        public void UpdateNote(Guid noteId, string content)
        {
            var _note = notes.FirstOrDefault(x => x.Id == noteId);
            if (_note != null)
            {
                _note.Content = content;
            }
        }

        public void UpdateNote(Guid noteId, string content, GroupName group)
        {
            var _note = notes.FirstOrDefault(x => x.Id == noteId);
            if (_note != null)
            {
                _note.Content = content;
                _note.Group = group;
            }
        }

        public void UpdateNoteTitle(Guid id, string title)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = title;
            }
        }
    }
}
