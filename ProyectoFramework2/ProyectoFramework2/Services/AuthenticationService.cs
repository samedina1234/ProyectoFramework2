using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ProyectoFramework2.Services
{
    public class AuthenticationService
    {
        private readonly IJSRuntime _jsRuntime;
        public event Action OnAuthStateChanged;
        public string NombreUsuario { get; private set; } = "Invitado";
        public AuthenticationService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _ = Initialize();
        }
        private async Task Initialize()
        {
            NombreUsuario = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "nombreUsuario") ?? "Invitado";
            OnAuthStateChanged?.Invoke();
        }
        public async Task SetNombreUsuario(string nombre)
        {
            NombreUsuario = nombre;
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "nombreUsuario", nombre);
            OnAuthStateChanged?.Invoke();
        }
        public async Task ClearNombreUsuario()
        {
            NombreUsuario = "Invitado";
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "nombreUsuario");
            OnAuthStateChanged?.Invoke();
        }
    }
}
