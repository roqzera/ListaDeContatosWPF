using System;
using System.Collections.Generic;

namespace ListaDeContatos.Models
{
    public class Contato
    {
        public int IdContato;
        private string _nome;
        private int _idade;
        private string _cidade;

        public Contato()
        {
        }

        public Contato(string nome, int idade, string cidade)
        {
            this._nome = nome;
            this._idade = idade;
            this._cidade = cidade;
        }
        public string nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }
 
        public int idade
        {
            get
            {
                return _idade;
            }
            set
            {
                _idade = value;
            }
        }
        public string cidade
        {
            get
            {
                return _cidade;
            }
            set
            {
                _cidade = value;
            }
        }

        public static implicit operator List<object>(Contato v)
        {
            throw new NotImplementedException();
        }
    }
}
