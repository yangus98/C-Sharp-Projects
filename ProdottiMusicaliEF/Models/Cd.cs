using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;

namespace ProdottiMusicaliEF.Models;

public partial class Cd
{
    public int Id { get; set; }

    public string Titolo { get; set; } = null!;

    public string Artista { get; set; } = null!;

    public int Anno { get; set; }

    static ProdottiMusicaliContext ctx = new ProdottiMusicaliContext();

    public static void Elimina(int codElimina)
    {
        
        var cd_da_eliminare = (from c in ctx.Cds
                               where c.Id == codElimina
                               select c).FirstOrDefault();

        ctx.Cds.Remove(cd_da_eliminare);
        ctx.SaveChanges();
    }

    public static void Modifica(int codModifica, string sceltaModifica, string titoloModificato, string artistaModificato, int annoModificato)
    {
        var cdModificato = (from c in ctx.Cds
                            where c.Id == codModifica
                            select c).FirstOrDefault();

        if (sceltaModifica == "t")
        {
            cdModificato.Titolo = titoloModificato;
            ctx.SaveChanges();
        }
        else if (sceltaModifica == "a")
        {
            cdModificato.Artista = artistaModificato;
            ctx.SaveChanges();
        }
        else if (sceltaModifica == "y")
        {
            cdModificato.Anno = annoModificato;
            ctx.SaveChanges();
        }
        else
        {
        }
    }
}

