using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class ArtistController : Controller {

        public List<Artist> allArtists {get; set;}

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [HttpGet]
        [Route("artists")]
        public JsonResult DisplayArtists()
        {
            return Json(allArtists);
        }

        [HttpGet]
        [Route("artists/name/{name}")]
        public JsonResult DisplayArtistByName(string name)
        {
            var artistsByName = from artist in allArtists where artist.ArtistName == name select artist;
            return Json(artistsByName);
        }

        [HttpGet]
        [Route("artists/realname/{name}")]
        public JsonResult DisplayArtistByRealName(string name)
        {
            var artistsByRealName = from artist in allArtists where artist.RealName == name select artist;
            return Json(artistsByRealName);
        }

        [HttpGet]
        [Route("artists/hometown/{town}")]
        public JsonResult DisplayArtistByHometown(string town)
        {
            var artistsByHometown = from artist in allArtists where artist.Hometown == town select artist;
            return Json(artistsByHometown);
        }

        [HttpGet]
        [Route("artists/groupid/{id}")]
        public JsonResult DisplayArtistByGroupId(int id)
        {
            var artistsByGroupId = from artist in allArtists where artist.GroupId == id select artist;
            return Json(artistsByGroupId);
        }
    }
}