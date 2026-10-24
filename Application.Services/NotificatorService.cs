
using System;

namespace Application.Services
{
    public class NotificatorService
    {
        public event Action? OnPedidosChanged;
        public event Action? OnPerfilChanged;

        public void NotificarCambioPedidos()
        {
            OnPedidosChanged?.Invoke();
        }

        public void NotificarCambioPerfil()
        {
            OnPerfilChanged?.Invoke();
        }
    }
}