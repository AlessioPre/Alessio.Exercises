﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Organizzazione
    {
        //var
        private string _nome;
        private string _sede;
        private string _presidente;
        private string _regolamento;
        private int _nDipendenti;

        //property
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
            }
        }
        public string Sede
        {
            get { return _sede; }
            set
            {
                _sede = value;
            }
        }
        public string Presidente
        {
            get { return _presidente; }
            set
            {
                _presidente = value;
            }
        }
        public string Regolamento
        {
            get { return _regolamento; }
            set
            {
                _regolamento = value;
            }
        }
        public int N_Dipendenti
        {
            get { return _nDipendenti; }
            set
            {
                _nDipendenti = value;
            }
        }

        public void AggiungiStato()
        {

        }

        public void InvocaLegge()
        {

        }

        public void Sanziona()
        {

        }

        public void GestisciCrisi()
        {

        }

        public void RimuoviPaese()
        {

        }
    }
}
