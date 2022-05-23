using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace Vietjet.com.Models
{
    public class baysGenreViewModel
    {
        public List<bay>? bays { get; set; }
        public SelectList? Genres { get; set; }
        public string? bayGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
