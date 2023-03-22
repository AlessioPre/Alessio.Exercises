using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises3
{
    public abstract class Paese
    {
        private string nome;
        private string continente;


        public Paese()
        {

        }

        public virtual void MetodoPaese()
        {
        }

    }
}
