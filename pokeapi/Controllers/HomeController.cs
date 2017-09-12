using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace pokeapi.Controllers
{
    public class HomeController : Controller
    {


        // GET: /Home/
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult Index(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>{
                PokeInfo = ApiResponse;
            }).Wait();
            ViewBag.Name = FirstLetterToUpper((string)PokeInfo["name"]);
            ViewBag.AllTypes = PokeInfo["types"];
            ViewBag.Height = PokeInfo["height"];
            ViewBag.Weight = PokeInfo["weight"];
            ViewBag.Sprite = PokeInfo["sprites"];
            Console.WriteLine(ViewBag.Sprite["front_default"]);
            List<string> types = new List<string>();
            foreach (var type in ViewBag.AllTypes){
                if (type["slot"] == 1){
                    ViewBag.PrimaryType = FirstLetterToUpper((string)type["type"]["name"]);
                } else {
                    string othertype = FirstLetterToUpper((string)type["type"]["name"]);
                    types.Add(othertype);
                }
            }
            ViewBag.OtherTypes = types.ToArray();
            return View();
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
        
    }
}
