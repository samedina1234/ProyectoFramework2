using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ProyectoFramework2.Client.Servicios
{
    public class AuthenticationService
    {
        private readonly IJSRuntime _jsRuntime;
        public event Action? OnAuthStateChanged;
        public string NombreUsuario { get; private set; } = "Invitado";
        public int IdUsuario { get; private set; } = 0;
        public NavigationManager NavigationManager { get; set; }

        public AuthenticationService(IJSRuntime jsRuntime, NavigationManager navigationManager)
        {
            NavigationManager = navigationManager;
            _jsRuntime = jsRuntime;
            _ = Initialize();
        }

        private async Task Initialize()
        {
            NombreUsuario = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "nombreUsuario") ?? "Invitado";
            string idUsuarioString = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "idUsuario");
            if (int.TryParse(idUsuarioString, out int idUsuario))
            {
                IdUsuario = idUsuario;
            }
            OnAuthStateChanged?.Invoke();
        }

        public async Task SetNombreUsuario(string nombre, int idUsuario)
        {
            NombreUsuario = nombre;
            IdUsuario = idUsuario;
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "nombreUsuario", nombre);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "idUsuario", idUsuario.ToString());
            OnAuthStateChanged?.Invoke();
        }

        public async Task ClearNombreUsuario()
        {
            NombreUsuario = "Invitado";
            IdUsuario = 0;
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "nombreUsuario");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "idUsuario");
            OnAuthStateChanged?.Invoke();
            NavigationManager.NavigateTo("/login");
        }
    }
}
