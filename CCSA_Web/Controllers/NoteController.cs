using CCSA_Web.DTO;

using CCSANoteApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static CCSANoteApp.Domain.Enums;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        public INoteService NotesService { get; }
        public NoteController(INoteService notesService)
        {
            NotesService = notesService;
        }
        [HttpPost("byNote")]
        public IActionResult CreateNote([FromBody] NoteDTO noteDTO)
        {
            NotesService.CreateNote(noteDTO.UserId,noteDTO.Title,noteDTO.Content,noteDTO.GroupName);
            return Ok("Created Successfully");
        }

        [HttpPost]
        public IActionResult CreateNote(Guid userId, string title, string content, GroupName group)
        {
            NotesService.CreateNote(userId, title, content, group);
            return Ok("Created Successfully");
        }
        [HttpDelete]
        public IActionResult DeleteNote(Guid id)
        {
            NotesService.DeleteNote(id);
            return Ok("Deleted Successfully");
        }

        [HttpDelete("multiple")]
        public IActionResult DeleteNote([FromBody]List<Guid> noteIds)
        {
            foreach (var noteId in noteIds)
            {
                NotesService.DeleteNote(noteId);
            }
            return Ok("Deleted Successfully");
        }
        [HttpGet("note")]
        public IActionResult FetchNote()
        {
            return Ok(NotesService.FetchNote());
        }
        [HttpGet("notegroup")]
        public IActionResult FetchNoteByGroup(Guid userId, GroupName group)
        {
            return Ok(NotesService.FetchNoteByGroup(userId,group));
        }

        [HttpGet("byId/{id}")]
        public IActionResult FetchNoteById(Guid id)
        {
            return Ok(NotesService.FetchNoteById(id));
        }

        [HttpGet("byUser/{id}")]
        public IActionResult FetchNoteByUser(Guid id)
        {
            return Ok(NotesService.FetchNoteByUser(id));
        }
        [HttpPut]
        public IActionResult UpdateNote(Guid id, [FromBody] NoteDTO noteDTO)
        {
            NotesService.UpdateNote(id, noteDTO.Content,noteDTO.GroupName);
            return Ok("Updated Successfully");
        }

        [HttpPut("updatecontent")]
        public IActionResult UpdateNote(Guid id, string content)
        {
            NotesService.UpdateNote(id, content);
            return Ok("Updated Successfully");
        }

        [HttpPut("updatetitle")]
        public IActionResult UpdateNoteTitle(Guid id, string title)
        {
            NotesService.UpdateNoteTitle(id, title);
            return Ok("Updated Successfully");
        }
    }
}
