using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliFactory
{
    public enum TipoVeicolo { Moto, Camion, Automobile }
    
    internal class FabbricaVeicoli
    {
        private int telaioAuto = 0;
        private int telaioCamion = 1000;
        private int telaioMoto = 2000;

        public IVeicolo getVeicolo(TipoVeicolo tipo, string descrizione, string colore, double prezzo)
        {
            switch (tipo)
            {
                case TipoVeicolo.Automobile:
                    return new Automobile(telaioAuto++ , descrizione, colore, prezzo);
                    break;
                case TipoVeicolo.Camion:
                    return new Camion(telaioCamion++, descrizione, colore, prezzo);
                    break;
                case TipoVeicolo.Moto:
                    return new Moto(telaioMoto++, descrizione, colore, prezzo);
                    break;
                default:
                    return null;
            }
        }

        
    }
}
