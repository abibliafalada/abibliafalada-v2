﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sbcore.Persistence;
using Db4objects.Db4o;
using SpokenBible.Presenter;
using sbcore.Model;
using SpokenBible.Properties;
using SpokenBible.Components;

namespace SpokenBible.Controller
{
    public class AppController
    {
        private Index index = null;

        public IObjectContainer DefaultContainer { get; set; }
        
        public Index Index {
            get
            {
                if (index == null)
                {
                    index = new Index(SbDbManager.Index);
                    if (!System.IO.Directory.Exists(SbDbManager.Index))
                    {
                        index.CreateIndex(SbDbManager.Database);
                    }
                }
                return index;
            }
        }
        
        internal string DefaultTerm
        {
            get { return Settings.Default.Referencia; }
            set { Settings.Default.Referencia = value; }
        }

        public AppController()
        {
        }

        public void Start()
        {
            this.DefaultContainer = Container.GetContainer(SbDbManager.Database);
            Index index = Index;
            MainPresenter presenter = new MainPresenter(this);
            presenter.ShowView();
        }

        internal void End()
        {
            Container.CloseContainer();
            Settings.Default.Save();
        }

    }
}