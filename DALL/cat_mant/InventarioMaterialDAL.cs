using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.cat_mant
{
    public class InventarioMaterialDAL
    {
        private string idInventario;
        private string idMaterial;
        private decimal peso;
        private bool estadoTransaccionDB;

        public string IdInventario
        {
            get
            {
                return idInventario;
            }

            set
            {
                idInventario = value;
            }
        }

        public string IdMaterial
        {
            get
            {
                return idMaterial;
            }

            set
            {
                idMaterial = value;
            }
        }

        public decimal Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public bool EstadoTransaccionDB
        {
            get
            {
                return estadoTransaccionDB;
            }

            set
            {
                estadoTransaccionDB = value;
            }
        }
    }
}
