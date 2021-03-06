﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using sbcore.Model.Interface;

namespace sbcore.Model
{
    public class Testamento : ISbItem
    {
        #region Atributos e propriedades
        private IList<Livro> livros;

        public string Tag { get; set; }
        public string Acronimo { get; set; }
        public string Nome { get; set; }
        public Traducao Traducao { get; set; }

        public IList<Livro> Livros
        {
            get
            {
                return new ReadOnlyCollection<Livro>(livros);
            }
        }
        #endregion

        #region Construtor
        public Testamento(string acronimo, string nome)
        {
            Acronimo = acronimo;
            Nome = nome;
            livros = new List<Livro>();
        }
        #endregion

        #region Métodos
        public Livro AddLivro(Livro livro)
        {
            livro.Testamento = this;
            this.livros.Add(livro);
            return livro;
        }

        public override bool Equals(object obj)
        {
            Testamento testamento = obj as Testamento;
            if ((object)testamento == null) return false;
            if (!Object.Equals(this.Acronimo, testamento.Acronimo)) return false;
            if (!Object.Equals(this.Nome, testamento.Nome)) return false;
            return true;
        }
        #endregion

        #region ISbItem<Livro> Members

        public string Display
        {
            get { return Nome; }
        }

        public IEnumerable<ISbItem> Children
        {
            get { return Enumerable.Cast<ISbItem>(Livros); }
        }

        public ISbItem Parent
        {
            get { return Traducao; }
        }

        #endregion
    }
}
