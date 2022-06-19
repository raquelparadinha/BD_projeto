using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBD
{
    internal class Produto
    {
        private String _Nome, _CodProd, _Marca, _CodSeccao, _Designacao, _Stock, _Preco;
        public String Nome { get => _Nome; set => _Nome = value; }
        public String CodProd { get => _CodProd; set => _CodProd = value; }
        public String Marca { get => _Marca; set => _Marca = value; }
        public String CodSeccao { get => _CodSeccao; set => _CodSeccao = value; }
        public String Designacao { get => _Designacao; set => _Designacao = value; }
        public String Stock { get => _Stock; set => _Stock = value; }
        public String Preco { get => _Preco; set => _Preco = value; }


        public override string ToString()
        {
            return _CodProd + ": " + _Nome;
        }
    }
}
