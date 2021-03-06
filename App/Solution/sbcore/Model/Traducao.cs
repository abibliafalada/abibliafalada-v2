﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using sbcore.Model.Interface;

namespace sbcore.Model
{
    public class Traducao : ISbItem
    {
        #region Atributos e propriedades
        public IList<Testamento> testamentos;

        public string Tag { get; set; }
        public string Idioma { get; set; }
        public string Nome { get; set; }

        public IList<Testamento> Testamentos
        {
            get
            {
                return new ReadOnlyCollection<Testamento>(testamentos);
            }
        }
        #endregion

        #region Construtores
        public Traducao(string idioma, string nome)
        {
            Idioma = idioma;
            Nome = nome;
            testamentos = new List<Testamento>();
        }
        #endregion

        #region Métodos
        public Testamento AddTestamento(Testamento testamento)
        {
            testamento.Traducao = this;
            this.testamentos.Add(testamento);
            return testamento;
        }

        public override bool Equals(object obj)
        {
            Traducao traducao = obj as Traducao;
            if ((object)traducao == null) return false;
            if (!Object.Equals(this.Idioma, traducao.Idioma)) return false;
            if (!Object.Equals(this.Nome, traducao.Nome)) return false;
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
            get { return Enumerable.Cast<ISbItem>(Testamentos); }
        }

        public ISbItem Parent
        {
            get { return null; }
        }

        #endregion
    }
}
