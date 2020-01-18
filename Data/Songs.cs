using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/**
 * @author Berrada Yahia
 */

namespace SupPlayer.Data
{
    public class Songs
    {
        [Key]
        public int SongId { get; set; }
        public int PlaylistID { get; set; }
        public string SongName { get; set; }
    }
}