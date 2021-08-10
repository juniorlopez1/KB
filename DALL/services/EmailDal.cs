using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.services
{
    public class EmailDal
    {
        private string destino;
        private string cuerpo;
        private string subject;

        public string Destino
        {
            get
            {
                return destino;
            }

            set
            {
                destino = value;
            }
        }

        public string Cuerpo
        {
            get
            {
                return cuerpo;
            }

            set
            {
                cuerpo = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }
    }
}
