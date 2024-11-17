using MauiAppHotel.Models;
using MauiAppHotel.Views;

namespace MauiAppHotel.Views
{
    public partial class CadastroEventoPage : ContentPage
    {
        public Evento Evento { get; set; }

        public DateTime Hoje { get; set; }
        public CadastroEventoPage()
        {
            InitializeComponent();


            Evento = new Evento
            {
                DataInicio = DateTime.Now,
                DataTermino = DateTime.Now.AddDays(1)
            };

            BindingContext = this;

        }

        private async void OnCadastrarEventoClicked(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(Evento.Nome) ||
                    Evento.DataInicio == default ||
                    Evento.DataTermino == default ||
                    Evento.NumeroParticipantes <= 0 ||
                    string.IsNullOrEmpty(Evento.Local) ||
                    Evento.CustoPorParticipante <= 0)
                {
                    await DisplayAlert("Erro", "Todos os campos devem ser preenchidos corretamente.", "OK");
                    return;
                }

                
                await Navigation.PushAsync(new EventoResumoPage
                {
                    BindingContext = Evento
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        private void OnDataInicioSelected(object sender, DateChangedEventArgs e)
        {
            
            if (Evento.DataInicio != default)
            {
                Evento.DataTermino = Evento.DataInicio.AddDays(1);
            }
        }
    }
}