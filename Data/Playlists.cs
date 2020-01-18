using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/**
 * @author Berrada Yahia
 */

namespace SupPlayer.Data
{
    public class Playlists
    {
        [Key]
        public int PlaylistID { get; set; }
        public string PlaylistUser { get; set; }
        public string PlaylistName { get; set; }
    }
}