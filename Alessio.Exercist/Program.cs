using System;

namespace Alessio.Exercist
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Composizione
            string nome = "PAESE";
            Continente continente = new Continente(nome);

            //Agregazione
            string nome_regione     = "REGIONE";
            string nome_provincia   = "PROVINCIA";
            string nome_comunune    = "COMUNE";
            string nome_abitante    = "ABITANTE";

            Regione regione         = new Regione(continente._paese, nome_regione);
            continente._paese.AddRegione(regione);
            Provincia provincia     = new Provincia(regione, nome_provincia);
            regione.AddProvincia(provincia);
            Comune comune           = new Comune(provincia, nome_comunune);
            provincia.AddComune(comune);
            Abitanti abitante       = new Abitanti(comune, nome_abitante);
            comune.AddCittadino(abitante);
            Unione_europea europa   = new Unione_europea(continente._paese);
            europa.AggiungiStato(continente._paese);
            ONU onu                 = new ONU(continente._paese);
            onu.AggiungiStato(continente._paese);
            NATO nato               = new NATO(continente._paese);
            onu.AggiungiStato(continente._paese);
        }
    }
}
