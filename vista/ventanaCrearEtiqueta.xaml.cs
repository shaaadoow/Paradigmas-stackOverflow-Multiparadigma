﻿using controlador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace vista
{
    /// <summary>
    /// Lógica de interacción para ventanaCrearEtiqueta.xaml
    /// </summary>
    public partial class ventanaCrearEtiqueta : Window
    {
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        ventanaCrearPregunta ventanaCrearPregunta;

        public ventanaCrearEtiqueta(ventanaCrearPregunta ventanaCrearPregunta)
        {
            InitializeComponent();
            this.ventanaCrearPregunta = ventanaCrearPregunta;
        }

        public ventanaCrearPregunta VentanaCrearPregunta { get => ventanaCrearPregunta; set => ventanaCrearPregunta = value; }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_CrearEtiqueta_Click(object sender, RoutedEventArgs e)
        {
            if (tb_NombreEtiqueta.Text == "" || tb_DescripcionEtiqueta.Text == "")
            {
                MessageBox.Show("No pueden haber campos en blanco");
            }
            else if (controlador.CrearEtiqueta(tb_NombreEtiqueta.Text, tb_DescripcionEtiqueta.Text))
            {
                VentanaCrearPregunta.cb_SeleccionEtiquetas.Items.Refresh();
                MessageBox.Show("Etiqueta creada");
                this.Close();
            } else
            {
                MessageBox.Show("Ya existe una etiqueta con ese nombre");
            }
            tb_NombreEtiqueta.Clear();
            tb_DescripcionEtiqueta.Clear();
        }
    }
}
