using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



namespace Examen_Mvvm.ViewModels
{
    public partial class FormCuadraticaViewModel : ObservableObject
    {
        [ObservableProperty]
        private double a;

        [ObservableProperty]
        private double b;

        [ObservableProperty]
        private double c;

        [ObservableProperty]
        private double discriminante;

        [ObservableProperty]
        private double x1;
        [ObservableProperty]
        private double x2;

        [RelayCommand]
        private void Calcular()
        {
            try
            {
                if (A == 0)
                {
                    Alerta("ERROR", "El valor de 'a' no puede ser 0"); 
                    return;
                }

                Discriminante = Math.Pow(B, 2) - 4 * A * C;

                if (Discriminante < 0)
                {
                    Alerta("ERROR", "El valor de 'discriminante' negativo es inválido");
                }
                else
                {
                    Alerta("ACIERTO", "Discriminante válido. ¡Operacion Exitosa!");
                }
                X1 = (-B + Math.Sqrt(Discriminante)) / (2 * A);
                X2 = (-B - Math.Sqrt(Discriminante)) / (2 * A);
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private void Limpiar()
        {
            A = 0;
            B = 0;
            C = 0;
            X1 = 0;
            X2 = 0;
        }
    }
}
