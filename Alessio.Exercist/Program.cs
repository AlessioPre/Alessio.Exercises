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
            Provincia provincia     = new Provincia(regione, nome_provincia);
            Comune comune           = new Comune(provincia, nome_comunune);
            Abitanti abitante       = new Abitanti(comune, nome_abitante);
            Unione_europea europa   = new Unione_europea(continente._paese);
            ONU onu                 = new ONU(continente._paese);
            NATO nato               = new NATO(continente._paese);

        }
    }
}
