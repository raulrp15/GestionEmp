﻿using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System.Collections.ObjectModel;

namespace ChatMaui.Client
{
    public partial class MainPage : ContentPage
    {
        private readonly HubConnection connection;
        MensajeUsuario msgUser;
        public ObservableCollection<MensajeUsuario> Lista { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            listaMensajes.ItemsSource = Lista;
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5111/chathub").WithAutomaticReconnect().Build();

            connection.On<MensajeUsuario>("ReceivedMessage", (m) =>
            {
                Lista.Add(m);
            });
            Task.Run(() =>
            {
                Dispatcher.Dispatch(async () =>
                await connection.StartAsync());
            });
        }

        private async void Send(object sender, EventArgs e)
        {
            msgUser = new();
            msgUser.Usuario = User.Text;
            msgUser.Mensaje = Message.Text;
            await connection.InvokeCoreAsync("SendMessage", args: new[]
            { msgUser});
            User.Text = String.Empty;
            Message.Text = String.Empty;
        }
    }

}
