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
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Collections;

/*
 * Seguindo o tutorial:
 * http://xamlcoder.com/cs/blogs/joe/archive/2007/12/13/building-custom-template-able-wpf-controls.aspx
 */
namespace AltzControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AltzControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AltzControls;assembly=AltzControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:AutoComplete/>
    ///
    /// </summary>
    public class AutoComplete : Control
    {
        static AutoComplete()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutoComplete), new FrameworkPropertyMetadata(typeof(AutoComplete)));
        }

        #region TextBox
        void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    OcultaPopup();
                    break;
                case Key.Down:
                    this.list.SelectedIndex = this.list.Items.Count > 0 ? 0 : -1;
                    ListBoxItem item = list.ItemContainerGenerator.ContainerFromItem(list.SelectedItem) as ListBoxItem;
                    item.Focus();
                    break;
            }
        }

        private void TextBoxLostFocus(object o, EventArgs e)
        {
            OcultaPopup();
        }
        #endregion

        #region MainWindow
        private TextBox textbox = null;
        private Popup popup = null;
        private ListBox list = null;

        private FrameworkElement FindMainWindow(FrameworkElement child)
        {
            if (child.Parent == null || child.Parent is Window)
                return child.Parent as FrameworkElement;
            if (child.Parent is FrameworkElement)
                return FindMainWindow(child.Parent as FrameworkElement);
            return null;
        }

        protected void OnMainWindowLocationChanged(object o, EventArgs e)
        {
            OcultaPopup();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.textbox = base.GetTemplateChild("PART_TextBox") as TextBox;
            this.popup = base.GetTemplateChild("PART_Popup") as Popup;
            this.list = base.GetTemplateChild("PART_ListBox") as ListBox;

            if (this.textbox != null)
            {
                this.textbox.LostFocus += this.TextBoxLostFocus;
                this.textbox.KeyUp += new KeyEventHandler(TextBoxKeyUp);
            }

            if (this.popup != null && this.list != null)
            {
                IList<string> itens = new List<string>();
                itens.Add("Matheus");
                itens.Add("Marcos");
                itens.Add("Lucas");
                itens.Add("João");
                this.list.ItemsSource = itens;

                this.list.KeyUp += new KeyEventHandler(ListBoxKeyUp);
                this.list.MouseUp += new MouseButtonEventHandler(ListBoxMouseUp);
            }

            Window mainWindow = FindMainWindow(this) as Window;
            if (mainWindow != null)
                mainWindow.LocationChanged += this.OnMainWindowLocationChanged;
        }
        #endregion

        #region Popup
        void ListBoxMouseUp(object sender, MouseButtonEventArgs e)
        {
            SelecionaItem();
        }

        void ListBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SelecionaItem();
            }
        }

        void SelecionaItem()
        {
            this.textbox.Text = this.list.SelectedValue as string;
            this.textbox.CaretIndex = this.textbox.Text.Length;
            OcultaPopup();
        }

        private void OcultaPopup()
        {
            if (this.popup != null && this.popup.IsOpen)
                this.popup.IsOpen = false;
        }
        #endregion

        #region ItemsSource
        public IEnumerable ItemsSource
        {
            get { return this.list.ItemsSource; }
            set { this.list.ItemsSource = value; }
        }
        #endregion

        #region Text property
        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.Register("Text", typeof(String), typeof(AutoComplete),
                new UIPropertyMetadata(null,
                    new PropertyChangedCallback(OnTextChanged),
                    new CoerceValueCallback(OnCoerceText)));

        private static object OnCoerceText(DependencyObject o, Object value)
        {
            if (o != null)
            {
                AutoComplete autoComplete = o as AutoComplete;
                return autoComplete.OnCoerceText((string)value);
            }
            else
                return value;
        }

        private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (o != null)
            {
                AutoComplete autoComplete = o as AutoComplete;
                autoComplete.OnTextChanged((string)e.OldValue, (string)e.NewValue);
            }
        }

        protected virtual String OnCoerceText(String value)
        {
            return value;
        }

        protected virtual void OnTextChanged(String oldValue, String newValue)
        {
            if (this.popup != null && !this.popup.IsOpen)
                this.popup.IsOpen = true;
            this.RaiseEvent(new RoutedEventArgs(AutoComplete.TextChangedEvent, this));
        }

        public String Text
        {
            // IMPORTANT: To maintain parity between setting a property in XAML
            // and procedural code, do not touch the getter and setter inside
            // this dependency property!
            get
            {
                return (String)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        #endregion

        #region TextChanged event
        public static readonly RoutedEvent TextChangedEvent =
            EventManager.RegisterRoutedEvent("TextChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(AutoComplete));

        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }
        #endregion
    }
}