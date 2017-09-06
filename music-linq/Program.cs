using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?

            var artistMV = from artist in Artists where artist.Hometown == "Mount Vernon" select new { artist.ArtistName, artist.Age };

            Console.WriteLine("** Artist from Mount Vernon **");
            foreach (var item in artistMV){
                Console.WriteLine(item);
            }

            //Who is the youngest artist in our collection of artists?

            var youngArtist = Artists.OrderBy(artist => artist.Age).First();

            Console.WriteLine("** Youngest Artist **");
            Console.WriteLine(youngArtist.ArtistName);
            Console.WriteLine(youngArtist.Age);

            //Display all artists with 'William' somewhere in their real name

            List<Artist> williams = Artists.Where( artist => artist.RealName.Contains("William")).ToList();;

            Console.WriteLine("** Artists with 'William' in their real name **");
            foreach (Artist a in williams){
                Console.WriteLine(a.RealName);
            }

            //Display the 3 oldest artist from Atlanta

            List<Artist> oldestAtlArtists = Artists.Where( artist => artist.Hometown == "Atlanta").OrderBy( artist => artist.Age ).Reverse().Take(3).ToList();

            Console.WriteLine("** 3 Oldest Artists from Atlanta **");
            foreach (Artist a in oldestAtlArtists){
                Console.WriteLine(a.RealName);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            List<string> notNYC = Artists.Where( artist => artist.Hometown != "New York City").Join(Groups, 
                artist => artist.GroupId, 
                group => group.Id, 
                (artist, group) => {
                    return group.GroupName;
                }).Distinct().ToList();

            Console.WriteLine("** Groups with members not from NYC **");

            foreach (string g in notNYC){
                Console.WriteLine(g);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

            List<string> wuTangMembers = Groups.Where( group => group.GroupName =="Wu-Tang Clan" ).Join(Artists, 
                group => group.Id, 
                artist => artist.GroupId,
                (group, artist) => {
                    return artist.ArtistName;
                }).ToList();

            Console.WriteLine("** Wu-Tang Clan Members **");

            foreach (string a in wuTangMembers){
                Console.WriteLine(a);
            }


        }
    }
}
