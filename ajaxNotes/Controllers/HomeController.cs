using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace ajaxNotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string,object>> AllNotes = DbConnector.Query("SELECT * FROM notes ORDER BY created_at DESC");
            ViewBag.AllNotes = AllNotes;
            return View();
        }

        [HttpPost]
        [Route("notes/{title}")]
        public object postNote(string title)
        {
            DbConnector.Execute($"INSERT INTO notes (title, created_at, updated_at) VALUES ('{title}', NOW(), NOW())");
            List<Dictionary<string,object>> NewNote = DbConnector.Query("SELECT LAST_INSERT_ID()");
            object newNoteID = NewNote[0]["LAST_INSERT_ID()"];
            return newNoteID;
        }

        [HttpPost]
        [Route("update")]
        public void updateNote(int id, string description)
        {
            DbConnector.Execute($"UPDATE notes SET description = '{description}', updated_at = NOW() WHERE idnotes = {id}");
        }

        [HttpPost]
        [Route("delete")]
        public void deleteNote(int id)
        {
            DbConnector.Execute($"DELETE FROM notes WHERE idnotes = {id}");
        }
    }
}
