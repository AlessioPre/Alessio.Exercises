using System;

using System.Collections.Generic;

namespace Alessio.Exercises9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EuDigitalWallet  digitalWallet = new EuDigitalWallet("","");
            Insurance insurance = new Insurance();

            bool planIsCreated = insurance.CreatePlan(digitalWallet.GetClinicalSituation());
            if (planIsCreated)
            {
                Console.WriteLine(insurance.GetData().ClinicStatus);
                digitalWallet.UpdateClinicalSituation("ottimo stato");
                Console.WriteLine(insurance.GetData().ClinicStatus);
            }
        }

        public class InsuranceIntermediary
        {
            public class ClinicalWallet
            {
                string _clinicStatus;
                public string ClinicStatus { get { return _clinicStatus; } set { _clinicStatus = value; } }
                public ClinicalWallet(string status)
                {
                    _clinicStatus = status;
                }
            }
        }

        class EuDigitalWallet : InsuranceIntermediary
        {
            string _owner;
            string _password;
            string _graduetion;
            ClinicalWallet _status;

            public EuDigitalWallet(string Cf,string status)
            {
                _owner = Cf;
                _status = new ClinicalWallet(status);
            }

            public ClinicalWallet GetClinicalSituation()
            {
                return _status;
            }

            internal void UpdateClinicalSituation(string v)
            {
               _status.ClinicStatus = v;
            }
        }


        public class Insurance : InsuranceIntermediary
        {
            List<ClinicalWallet> _clinicalSituations = new List<ClinicalWallet>();
            public bool CreatePlan(ClinicalWallet data)
            {
                bool isTrue = askClient();
                if (!isTrue)
                {
                    Console.WriteLine("Non hai accettato di inviare i dati sanitari, non puoi procedere");
                    return false;
                }

                _clinicalSituations.Add(data);
                return true;
            }

            private bool askClient()
            {
                Console.WriteLine(" inviare dati sanitari?");
                string input = Console.ReadLine();
                input.ToLower();

                if (input == "si" || input == "yes") return true;
                return false;
            }

            public ClinicalWallet GetData()
            {
                return _clinicalSituations[0];
            }
        }

        class Person
        {
            public string Cf { get; set; }
        }
       
    }
}
