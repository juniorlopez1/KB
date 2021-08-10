using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.db
{
    public class NormalizarParametro
    {
        public static SqlDbType obtenerTipoSQL(byte parametro)
        {
            if ((parametro | 0x0) == 0)
            {
                return SqlDbType.Int;
            }
            if ((parametro | 0x1) == 1)
            {
                return SqlDbType.VarChar;
            }
            if ((parametro | 0x2) == 2)
            {
                return SqlDbType.Char;
            }
            if ((parametro | 0x3) == 3)
            {
                return SqlDbType.Date;
            }
            if ((parametro | 0x4) == 4)
            {
                return SqlDbType.DateTime;
            }
            if ((parametro | 0x5) == 5)
            {
                return SqlDbType.Time;
            }
            if ((parametro | 0x6) == 6)
            {
                return SqlDbType.TinyInt;
            }
            if ((parametro | 0x7) == 7)
            {
                return SqlDbType.Money;
            }
            if ((parametro | 0x8) == 8)
            {
                return SqlDbType.SmallInt;
            }
            if ((parametro | 0x9) == 9)
            {
                return SqlDbType.Decimal;
            }
            if ((parametro | 0x10) == 16)
            {
                return SqlDbType.Bit;
            }

            throw new ArgumentException("El tipo de parametro no esta cubierto o es incorrecto");
        }


        // Esto va del lado del cliente
        public enum ParametroSQL
        {
            INT,
            VARCHAR,
            CHAR,
            DATE,
            DATETIME,
            TIME,
            TINYINT,
            MONEY,
            SMALLINT,
            DECIMAL,
            BIT
           
        }

        public static byte almacenarTipo(ParametroSQL tipo)
        {
            switch (tipo)
            {
                case ParametroSQL.INT:
                    return 0x0;
                case ParametroSQL.VARCHAR:
                    return 0x1;
                case ParametroSQL.CHAR:
                    return 0x2;
                case ParametroSQL.DATE:
                    return 0x3;
                case ParametroSQL.DATETIME:
                    return 0x4;
                case ParametroSQL.TIME:
                    return 0x5;
                case ParametroSQL.TINYINT:
                    return 0x6;
                case ParametroSQL.MONEY:
                    return 0x7;
                case ParametroSQL.SMALLINT:
                    return 0x8;
                case ParametroSQL.DECIMAL:
                    return 0x9;
                case ParametroSQL.BIT:
                    return 0x10;
                default:
                    return 0x1;
            }
        }
    }
}
