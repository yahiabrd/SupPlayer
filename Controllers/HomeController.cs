using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SupPlayer.Data;
using SupPlayer.Models;
using SupPlayer.ViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.RegularExpressions;
using System;
using Microsoft.AspNetCore.Authorization;

/**
 * @author Berrada Yahia
 */

namespace SupPlayer.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Playlist(int? id)
        {
            //recuperation de l'identifiant (email) depuis controller
            var emailUser = HttpContext.User.Identity.Name;

            //requete qui va recup toutes les playlists en fonction de emailUser
            List<PlaylistViewModel> data = (from Playlists in db.Playlists
                                            where Playlists.PlaylistUser == emailUser
                                            select new PlaylistViewModel
                                            {
                                                PlaylistID = Playlists.PlaylistID,
                                                PlaylistUser = Playlists.PlaylistUser,
                                                PlaylistName = Playlists.PlaylistName

                                            }).ToList();

            //si pas de id en parametre alors on affiche tous
            if (id == null)
            {
                return View(data);
            }
            //si id en parametre alors on affiche seulement les donnees de la playlist selectionnee
            else
            {
                //requete qui recupere toutes les infos de la playlist et des songs associes a cette playlist
                List<PlaylistViewModel> data2 = (from Playlists in db.Playlists
                                                 from Songs in db.Songs
                                                 where Playlists.PlaylistUser == emailUser
                                                 && Playlists.PlaylistID == id
                                                 && Songs.PlaylistID == id
                                                 select new PlaylistViewModel
                                                 {
                                                     PlaylistID = Playlists.PlaylistID,
                                                     PlaylistUser = Playlists.PlaylistUser,
                                                     PlaylistName = Playlists.PlaylistName,
                                                     SongName = Songs.SongName,
                                                     SongID = Songs.SongId

                                                 }).ToList();

                //on va recup l'email depuis la base de donnee par rapport a la playlist pour securiser l'ajout du default song
                var emailVerif = (from Playlists in db.Playlists
                         where Playlists.PlaylistID == id.GetValueOrDefault()
                         && Playlists.PlaylistUser == emailUser
                         select Playlists.PlaylistUser).SingleOrDefault();

                //si il n y a aucuns songs dans la playlist, on va creer un song par defaut sinon la requete marchera pas car aucun song n'a une playlistID
                bool isEmpty = !data2.Any();
                try //au cas ou l'utilisateur est deconnecte
                {
                    if (isEmpty && emailUser.Equals(emailVerif))
                    {
                        db.Songs.Add(new Songs
                        {
                            PlaylistID = id.GetValueOrDefault(),
                            SongName = "Default song"
                        });
                        db.SaveChanges();
                    }
                }catch(Exception e)
                {
                    return RedirectToAction("../Home/Playlist");
                }

                //on envoi les donnees dans la page Songs
                return View("Songs", data2);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create_Playlist(Playlists playlist)
        {
            //creation de la playlist
            if (ModelState.IsValid)
            {
                //verifie si le formulaire n'est pas envoye vide
                if (!string.IsNullOrEmpty(playlist.PlaylistName)) 
                {
                    db.Playlists.Add(playlist);
                    db.SaveChanges();
                }

                return RedirectToAction("../Home/Playlist");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create_Song(Songs song, IFormFile file)
        {
            //creation du song et upload du song
            if (ModelState.IsValid)
            {
                //verifie si le formulaire n'est pas envoye vide
                if (!string.IsNullOrEmpty(song.SongName)) 
                {
                    //regex pour eviter les problemes de nom avec caracteres speciaux
                    Regex regex = new Regex(@"^[A-Za-z0-9-_ ]+$");
                    Match match = regex.Match(song.SongName);
                    if (match.Success)
                    {
                        try {
                            //recupere le nom du fichier
                            var fileName = System.IO.Path.GetFileName(file.FileName);
                            //si le fichier existe deja on le supprime
                            if (System.IO.File.Exists(fileName))
                            {
                                System.IO.File.Delete(fileName);
                            }
                            //on specifie le chemin pour le mettre dans wwwroot/music
                            //on renome aussi le fichier avec le meme nom que le song et on ajoute mp3 pour quil soit possible a lire
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/music", song.SongName + ".mp3");
                            //creation dun fichier local et copie de ce fichier 
                            using (var localFile = System.IO.File.OpenWrite(path))
                            using (var uploadedFile = file.OpenReadStream())
                            {
                                uploadedFile.CopyTo(localFile);
                            }

                            //sauvegarde
                            db.Songs.Add(song);
                            db.SaveChanges();

                            return RedirectToAction("../Home/Playlist/" + song.PlaylistID);

                        }catch(Exception e)
                        {
                            ViewData["message"] = "Error...";
                            return View("ErrorSongName");
                        }
                    }
                    else
                    {
                        ViewData["message"] = "Special characters are not allowed in the song name";
                        return View("ErrorSongName");
                    }
                }
                else
                {
                    return RedirectToAction("../Home/Playlist/" + song.PlaylistID);
                }
            }

            return View("Playlist");
        }

        [Authorize]
        public IActionResult PlaySong(int? id)
        {
            //recuperation des infos du song en fonction de la playlist et du user
            var emailUser = HttpContext.User.Identity.Name;
            List<PlaylistViewModel> data = (from Songs in db.Songs
                                            from Playlists in db.Playlists
                                                 where Songs.SongId == id.GetValueOrDefault()
                                                 && Songs.PlaylistID == Playlists.PlaylistID
                                                 && Playlists.PlaylistUser == emailUser
                                                 && Songs.SongName != "Default Song"
                                                 select new PlaylistViewModel
                                                 {
                                                     PlaylistID = Playlists.PlaylistID,
                                                     PlaylistUser = Playlists.PlaylistUser,
                                                     PlaylistName = Playlists.PlaylistName,
                                                     SongName = Songs.SongName,
                                                     SongID = Songs.SongId

                                                 }).ToList();

            //recuperatio id du next song
            var nextSong = (from Songs in db.Songs 
                            from Playlists in db.Playlists
                         where Songs.SongId > id.GetValueOrDefault() 
                         && Songs.PlaylistID == Playlists.PlaylistID
                         && Playlists.PlaylistUser == emailUser
                         && Songs.SongName != "Default Song"
                         select Songs.SongId).FirstOrDefault();

            //recuperatio id du previous song
            //on rajoute le Max() pour recup le max ID des SongId < id en cours
            //on rajoute le defaultIfEmpty pour avoir une valeur par defaut
            var prevSong = (from Songs in db.Songs 
                            from Playlists in db.Playlists
                         where Songs.SongId < id.GetValueOrDefault()
                         && Songs.PlaylistID == Playlists.PlaylistID
                         && Playlists.PlaylistUser == emailUser
                         && Songs.SongName != "Default Song"
                         select Songs.SongId).DefaultIfEmpty(0).Max();

            //on envoi les donnees a la vue
            ViewData["nextSong"] = nextSong;
            ViewData["prevSong"] = prevSong;
            
            return View(data);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            //delete tous les songs de la playlist
            //recuperation de la list de tous les  songs
            var emailUser = HttpContext.User.Identity.Name;
            List<PlaylistViewModel> allSongs = (from Songs in db.Songs
                                                from Playlists in db.Playlists
                                                 where Playlists.PlaylistID == id.GetValueOrDefault()
                                                 && Songs.PlaylistID == Playlists.PlaylistID
                                                 && Playlists.PlaylistUser == emailUser
                                                 select new PlaylistViewModel
                                                 {
                                                     SongName = Songs.SongName,
                                                     SongID = Songs.SongId
                                                     
                                                 }).ToList();

            //securisation par email pour verif si celui qui supprime a le droit ou pas
            var emailVerif = (from Playlists in db.Playlists
                         where Playlists.PlaylistID == id.GetValueOrDefault()
                         && Playlists.PlaylistUser == emailUser
                         select Playlists.PlaylistUser).SingleOrDefault();

            try 
            {
                if (emailUser.Equals(emailVerif)) 
                {
                    ViewData["message"] = "The playlist has been correctly deleted";

                    foreach(var song in allSongs)
                    {
                        //delete fichier mp3
                        var fileName = "wwwroot/music/" + song.SongName + ".mp3";
                        if (System.IO.File.Exists(fileName))
                        {
                            System.IO.File.Delete(fileName);
                        }

                        //delete song
                        var deleteSong = new Songs { SongId = song.SongID };
                        db.Songs.Attach(deleteSong);
                        db.Songs.Remove(deleteSong);
                        db.SaveChanges();
                    }

                    //delete la playlist
                    var deletePlaylist = new Playlists { PlaylistID = id.GetValueOrDefault() };
                    db.Playlists.Attach(deletePlaylist);
                    db.Playlists.Remove(deletePlaylist);
                    db.SaveChanges();

                }
                else
                {
                    ViewData["message"] = "You haven't access to this playlist";
                }
            }catch(Exception e)
            {
                return RedirectToAction("../Home/Playlist");
            }

            return View();
        }

        [Authorize]
        public IActionResult DeleteSong(int? id)
        {
            //recup nom fichier pour le delete et on rajoute SingleOrDefault pour caster en string
            var emailUser = HttpContext.User.Identity.Name;
            var songName = (from Songs in db.Songs 
                            from Playlists in db.Playlists
                         where Songs.SongId == id.GetValueOrDefault()
                         && Songs.PlaylistID == Playlists.PlaylistID
                         && Playlists.PlaylistUser == emailUser
                         select Songs.SongName).SingleOrDefault();

            //securisation
            var emailVerif = (from Songs in db.Songs
                              from Playlists in db.Playlists
                         where Songs.SongId == id.GetValueOrDefault()
                         && Songs.PlaylistID == Playlists.PlaylistID
                         && Playlists.PlaylistUser == emailUser
                         select Playlists.PlaylistUser).SingleOrDefault();

            try
            {
                if (emailUser.Equals(emailVerif)) 
                {
                    ViewData["message"] = "The song has been correctly deleted";

                    //delete fichier mp3
                    var fileName = "wwwroot/music/" + songName + ".mp3";
                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.File.Delete(fileName);
                    }

                    //delete le song
                    var deleteSong = new Songs { SongId = id.GetValueOrDefault() };
                    db.Songs.Attach(deleteSong);
                    db.Songs.Remove(deleteSong);
                    db.SaveChanges();
                }
                else
                {
                    ViewData["message"] = "You haven't access to this song";
                }
            }catch(Exception e)
            {
                return RedirectToAction("../Home/Playlist");
            }

            return View();
        }

        [Authorize]
        public IActionResult Rename(int? id)
        {
            //recuperation de l'identifiant (email) depuis controller
            var emailUser = HttpContext.User.Identity.Name;

            //requete qui va recup toutes les playlists en fonction de emailUser
            List<PlaylistViewModel> data = (from Playlists in db.Playlists
                                            where Playlists.PlaylistUser == emailUser
                                            && Playlists.PlaylistID == id.GetValueOrDefault()
                                            select new PlaylistViewModel
                                            {
                                                PlaylistID = Playlists.PlaylistID,
                                                PlaylistUser = Playlists.PlaylistUser,
                                                PlaylistName = Playlists.PlaylistName

                                            }).ToList();

            return View(data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Rename_Playlist(Playlists playlist)
        {
            //creation de la playlist
            if (ModelState.IsValid)
            {
                //renommer la playlist
                var update = db.Playlists.Find(playlist.PlaylistID);
                update.PlaylistName = playlist.PlaylistName;

                db.SaveChanges();

                return RedirectToAction("../Home/Playlist");
            }

            return View("Playlist");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
