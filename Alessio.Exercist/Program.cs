using System;

namespace Alessio.Exercist
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Composizione
            // Area_Geografica Italia = new Paese("ITALIA");
            string nome_continente = "Europeo";
            Continente continente = new Continente(nome_continente,"mediterraneo",13000000M,"Multietico","Emisfiero Australe");
            Continente continente2 = new Continente("Continente emerso");
            continente.CreateState("Italia");
            continente2.CreateState("Atlantide");
            continente.GetListaPaesi();
            continente2.GetListaPaesi();
            continente.ChangeState(continente2);
            //Agregazione
            //string nome_regione   = "REGIONE";
            //string nome_provincia = "PROVINCIA";
            //string nome_comunune  = "COMUNE";
            //string nome_abitante  = "ABITANTE";


            //
            //Regione regione = new Regione(continente.Paese, nome_regione);
            //continente._paese.AddRegione(regione);
            //Provincia provincia = new Provincia(regione, nome_provincia);
            //regione.AddProvincia(provincia);
            //Comune comune = new Comune(provincia, nome_comunune);
            //provincia.AddComune(comune);
            //Abitanti abitante = new Abitanti(comune, nome_abitante);
            //comune.AddCittadino(abitante);
            //Unione_europea europa = new Unione_europea(continente.Paese);

            //continente.Paese.AddOrganizationUE(europa);
            //ONU onu = new ONU(continente.Paese);
            //continente.Paese.AddOrganizationONU(onu);
            //NATO nato = new NATO(continente.Paese);
            //continente.Paese.AddOrganizationNATO(nato);

            /////
            ///
            //Non credo che la relazione di Aggregazione tra paese e le organizzazione sia corretta,
            //credo che la relazione giusta sia di dipendenza tra le organizzazioni e il paese
            //quindi ho implementato una versione alternativa 
            //Unione_europea europa = new Unione_europea(continente._paese);
            //europa.AggiungiStato(continente._paese);
            //ONU onu = new ONU(continente._paese);
            //onu.AggiungiStato(continente._paese);
            //NATO nato = new NATO(continente._paese);
            //nato.AggiungiStato(continente._paese);
        }
    }
}
