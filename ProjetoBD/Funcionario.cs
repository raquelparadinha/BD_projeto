using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBD
{
    class Funcionario
    {
        private String _Nome, _Id, _Email, _Telemovel, _SSN, _NIF, _Morada, _Salario, _DataInicio, _DataFim, _Id_Sup, _Categoria, _Cargo;
        public String Nome { get => _Nome; set => _Nome = value; }
        public String Id { get => _Id; set => _Id = value; }
        public String Email { get => _Email; set => _Email = value; }
        public String Telemovel { get => _Telemovel; set => _Telemovel = value; }
        public String SSN { get => _SSN; set => _SSN = value; }
        public String NIF { get => _NIF; set => _NIF = value; }
        public String Morada { get => _Morada; set => _Morada = value; }
        public String Salario { get => _Salario; set => _Salario = value; }
        public String DataInicio { get => _DataInicio; set => _DataInicio = value; }
        public String DataFim { get => _DataFim; set => _DataFim = value; }
        public String Id_Sup { get => _Id_Sup; set => _Id_Sup = value; }
        public String Categoria { get => _Categoria; set => _Categoria = value; }
        public String Cargo { get => _Cargo; set => _Cargo = value; }

        public override string ToString()
        {
            return _Id + ": " + _Nome;
        }
    }


}
