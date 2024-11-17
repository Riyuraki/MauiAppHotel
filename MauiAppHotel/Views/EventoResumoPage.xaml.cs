namespace MauiAppHotel.Views
{
    public partial class EventoResumoPage : ContentPage
    {
        public EventoResumoPage()
        {
            InitializeComponent();
        }

        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}