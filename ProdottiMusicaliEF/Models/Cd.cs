using System;
using System.Collections.Generic;

namespace ProdottiMusicaliEF.Models;

public partial class Cd
{
    public int Id { get; set; }

    public string Titolo { get; set; } = null!;

    public string Artista { get; set; } = null!;

    public int Anno { get; set; }
}
