using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises2
{
    internal class Disoccupato :Persona
    {
        private bool    _assengnoRicevuto;
        private bool    _disoccupato;
        private int     _annoUltimoLavoro;
        private int     _settimaneLavorate;
        private string  _tipoDiContratto;
        private string  _tempoImpiego;
        public string   TipoDiContratto { get => _tipoDiContratto; set => _tipoDiContratto = value; }
        public string   TempoImpiego { get => _tempoImpiego; set => _tempoImpiego = value; }
        public int      SettimaneLavorate { get => _settimaneLavorate; set => _settimaneLavorate = value; }
        internal bool   AssengnoRicevuto { get => _assengnoRicevuto; set => _assengnoRicevuto = value; }
        public int AnnoUltimoLavoro { get => _annoUltimoLavoro; set => _annoUltimoLavoro = value; }
        public bool     _Disoccupato { get => _disoccupato; set => _disoccupato = value; }

        public Disoccupato(string name, string surname, int age, int maturita, int universita, bool fedinaPenale, int figli, bool militare, bool debiti, decimal pilComune ,string tipodicontratto, string tempoImpiego,int duratamesi, int annoultimolavoro) : base(name,surname, age, maturita, universita, fedinaPenale, figli, militare, debiti, pilComune)
        {
            TipoDiContratto     = tipodicontratto;
            TempoImpiego        = tempoImpiego;
            SettimaneLavorate   = duratamesi;
            AnnoUltimoLavoro    = annoultimolavoro;
        }

        public override void GetValues()
        {
            base.GetValues();
            Console.WriteLine($"Ha lavorato con contratto: {this.TempoImpiego}");
            Console.WriteLine($"Tipologia contratto: {this.TipoDiContratto}");

            if (this.AssengnoRicevuto)
            {
                Console.WriteLine($"assegno ricevuto: {this.Bonus}\n");
            }
            else
            {
                Console.WriteLine("assegno non ricevuto\n");
            }
        }
    }
}
