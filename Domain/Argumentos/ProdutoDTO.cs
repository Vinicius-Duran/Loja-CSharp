﻿using Domain.Entidades;
using Zicard.API.Common.Argumentos.Base;

namespace Domain.Argumentos
{
    public class ProdutoDTO : ArgumentoBase
    {
        public string Nome { get;  set; }
        public string Codigo { get;  set; }
        public string Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public int Estoque { get;  set; }
        public int Pontos { get;  set; }

        public int CategoriaId { get;  set; }
       
    }
}
