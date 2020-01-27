using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace E2KMovil
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int cont = 0;

        public MainPage()
        {
            InitializeComponent();
            CrearControles();

            var BNuevoJuego = new Button
            {
                Text = "NUEVO JUEGO",
                TextColor = Color.WhiteSmoke,
                CornerRadius = 20,
                BackgroundColor = Color.FromHex("#272822")
            };

            BNuevoJuego.Clicked += BNuevoJuegoOnClick;
            BNuevoJuego.SetValue(Grid.RowProperty, 3);
            BNuevoJuego.SetValue(Grid.ColumnSpanProperty, 3);

            var NuevaFila = new RowDefinition();
            MiGrilla.RowDefinitions.Add(NuevaFila);
            MiGrilla.Children.Add(BNuevoJuego);
        }

        private void CrearControles()
        {
            MiGrilla.Children.Clear();

            for (int i = 0; i < MiGrilla.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < MiGrilla.RowDefinitions.Count; j++)
                {
                    var Boton = new Button()
                    {
                        BorderColor = Color.FromHex("#272822")
                    };

                    Boton.Clicked += BotonOnClick;
                    Boton.SetValue(Grid.RowProperty, j);
                    Boton.SetValue(Grid.ColumnProperty, i);
                    MiGrilla.Children.Add(Boton);
                }
            }
        }

        private void BNuevoJuegoOnClick(object sender, EventArgs e)
        {
            int cont = 0;
            List<int> Indices = new List<int>();

            foreach (var Control in MiGrilla.Children)
            {
                if (Control is BoxView)
                {
                    Indices.Add(cont);
                }
                cont++;
            }

            foreach (int indice in Indices)
            {
                var Boton = new Button()
                {
                    BorderColor = Color.FromHex("#272822")
                };

                Boton.Clicked += BotonOnClick;
                MiGrilla.Children[indice] = Boton;
            }
        }

        private void BotonOnClick(object sender, EventArgs e)
        {
            var boton = sender as Button;

            var Columna = (int)boton.GetValue(Grid.ColumnProperty);
            var Fila = (int)boton.GetValue(Grid.RowProperty);
            var caja = new BoxView();

            if ((cont % 2) == 0)
                caja.Color = Color.Cyan;
            else
                caja.Color = Color.DarkBlue;

            caja.SetValue(Grid.RowProperty, Fila);
            caja.SetValue(Grid.ColumnProperty, Columna);
            MiGrilla.Children.Add(caja);
            cont++;
        }
    }
}