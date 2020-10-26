using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ejercicio8_CuadrosTexto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datoNombre_TextBox.Tag = mensajeNombre_TextBlock;
            datoApellido_TextBox.Tag = mensajeApellido_TextBlock;
        }
        
        private void DatoNombreApellido_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBlock mensaje = (sender as TextBox).Tag as TextBlock;

            if (e.Key == Key.F1)
            {
                if (mensaje.Visibility == Visibility.Hidden)
                    mensaje.Visibility = Visibility.Visible;
                else
                    mensaje.Visibility = Visibility.Hidden;
            }
        }

        private void DatoEdad_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool esUnEntero = EsUnEntero(datoEdad_TextBox.Text);

            if (datoEdad_TextBox.IsFocused)
            {
                if (e.Key == Key.F2 && !esUnEntero)
                    mensajeEdad_TextBlock.Visibility = Visibility.Visible;
                
                if (esUnEntero)
                    mensajeEdad_TextBlock.Visibility = Visibility.Hidden;
            }
        }

        private bool EsUnEntero(String datoEdad)
        {
            bool esUnEntero = false;
            Regex patron = new Regex(@"[0-9]");
            Match coincidencia = patron.Match(datoEdad);
            if (coincidencia.Success)
                esUnEntero = true;

            return esUnEntero;
        }
    }
}
