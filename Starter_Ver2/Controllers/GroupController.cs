using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
        
        List<Artist> allArtists = JsonToFile<Artist>.ReadJson();

        [HttpGet]
        [Route("groups/{displayArtists}")]
        public JsonResult DisplayGroups(bool displayArtists = false)
        {
            if (displayArtists){
                var allGroupsWithMembers = from artist in allArtists group artist by artist.GroupId into members join g in allGroups on members.FirstOrDefault().GroupId equals g.Id select new {GroupId = g.Id, GroupName = g.GroupName, Members = members};
                return Json(allGroupsWithMembers);
            } else {
                return Json(allGroups);
            }
        }

        [HttpGet]
        [Route("groups/name/{name}/{displayArtists}")]
        public JsonResult DisplayGroupByName(string name, bool displayArtists = false)
        {
            if(displayArtists){
                var groupsByNameWithMembers = from artist in allArtists group artist by artist.GroupId into members join g in allGroups on members.FirstOrDefault().GroupId equals g.Id where g.GroupName == name select new {GroupId = g.Id, GroupName = g.GroupName, Members = members};
                return Json(groupsByNameWithMembers);
            } else {
                var groupsByName = from g in allGroups where g.GroupName == name select g;
                return Json(groupsByName);
            }
        }

        [HttpGet]
        [Route("groups/id/{id}/{displayArtists}")]
        public JsonResult DisplayGroupById(int id, bool displayArtists = false)
        {
            if (displayArtists){
                var groupsByIdWithMembers = from artist in allArtists group artist by artist.GroupId into members join g in allGroups on members.FirstOrDefault().GroupId equals g.Id where g.Id == id select new {GroupId = g.Id, GroupName = g.GroupName, Members = members};
                return Json(groupsByIdWithMembers);
            } else {    
                var groupsById = from g in allGroups where g.Id == id select g;
                return Json(groupsById);
            }
        }
    }
}