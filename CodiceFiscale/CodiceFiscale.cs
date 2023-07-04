using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace CodiceFiscaleDaSolo
{
    internal class CodiceFiscale
    {
        string cf;
        public string getAcrNome(string codFiscale)
        {
            cf = codFiscale.ToUpper();
            string acrNome = cf.Substring(0, 3);
            return acrNome;
        }

        public string getAcrCognome(string codFiscale)
        {
            cf = codFiscale.ToUpper();
            string acrCognome = cf.Substring(3, 3);
            return acrCognome;
        }

        public int getGiorno(string codFiscale)
        {
            cf = codFiscale;
            int giorno = int.Parse(cf.Substring(9, 2));
            if (giorno > 40)
            {
                giorno = giorno - 40;
            }
            return giorno;
        }

        public string getMese(string codFiscale)
        {
            cf = codFiscale.ToUpper();
            string meseVero = "";
            string mese = cf.Substring(8, 1);
            if (mese == "a" || mese == "A")
            {
                meseVero = "Gennaio";
            }
            else if (mese == "b" || mese == "B")
            {
                meseVero = "Febbraio";
            }
            else if (mese == "c" || mese == "C")
            {
                meseVero = "Marzo";
            }
            else if (mese == "d" || mese == "D")
            {
                meseVero = "Aprile";
            }
            else if (mese == "e" || mese == "E")
            {
                meseVero = "Maggio";
            }
            else if (mese == "h" || mese == "H")
            {
                meseVero = "Giugno";
            }
            else if (mese == "l" || mese == "L")
            {
                meseVero = "Luglio";
            }
            else if (mese == "m" || mese == "M")
            {
                meseVero = "Agosto";
            }
            else if (mese == "p" || mese == "P")
            {
                meseVero = "Settembre";
            }
            else if (mese == "r" || mese == "R")
            {
                meseVero = "Ottobre";
            }
            else if (mese == "s" || mese == "S")
            {
                meseVero = "Novembre";
            }
            else if (mese == "t" || mese == "T")
            {
                meseVero = "Dicembre";
            }
            return meseVero;
        }

        public int getAnno(string codFiscale)
        {
            cf = codFiscale;
            int anno = int.Parse(cf.Substring(6, 2));
            if (anno >= 00 && anno <= 23)
            {
                anno += 2000;
            }
            else
            {
                anno += 1900;
            }
            return anno;
        }
        public int getAnni(string codFiscale)
        {
            cf = codFiscale;
            int anno = int.Parse(cf.Substring(6, 2));
            if (anno >= 00 && anno <= 23)
            {
                anno += 2000;
            }
            else
            {
                anno += 1900;
            }
            int età = 2023 - anno;
            return età;
        }

        public string getGenere(string codFiscale)
        {
            cf = codFiscale.ToUpper();
            int giorno = int.Parse(cf.Substring(9, 2));
            string genere;
            if (giorno > 40)
            {
                genere = "Femmina";
            }
            else
            {
                genere = "Maschio";
            }
            return genere;
        }
    }
}
