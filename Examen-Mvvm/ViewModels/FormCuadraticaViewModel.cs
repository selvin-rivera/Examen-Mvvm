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
                    Console.WriteLine("El valor de 'a' no puede ser 0.");
                    return;
                }

                Discriminante = Math.Pow(A, B - 4 * A * C);

                if (Discriminante < 0)
                {
                    Console.WriteLine("El discriminante es negativo. No hay raíces reales.");
                }
                else
                {
                    Console.WriteLine("El discriminante es válido. Puedes proceder con el cálculo de las raíces.");
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
        }
    }
}
