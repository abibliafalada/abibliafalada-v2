﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpokenBible.Presenter;
using SpokenBible.Helpers;

namespace SpokenBible.View
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Page
    {
        private MainPresenter presenter = null;

        public Principal(MainPresenter presenter)
        {
            this.presenter = presenter;
            InitializeComponent();
        }

        private void busca_SearchRequest(object sender, RoutedEventArgs e)
        {
            this.presenter.SearchRequested(busca.Text);
            this.presenter.ClosePrincipal();
        }

        private void busca_TextChanged(object sender, RoutedEventArgs e)
        {
            this.presenter.SearchChanged(busca, busca.Text);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this.busca);
        }

        private void AjudaMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.presenter.ShowHelp();
        }

        private void ABibliaFaladaMouseDown(object sender, MouseButtonEventArgs e)
        {
            StaticContentGenerator.OpenSite(SpokenBible.Properties.Resources.linkSite);
        }
    }
}
