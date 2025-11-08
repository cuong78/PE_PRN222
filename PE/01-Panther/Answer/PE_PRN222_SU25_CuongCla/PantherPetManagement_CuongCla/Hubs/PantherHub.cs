using PantherPetManagement_CuongCla.Service;
using Microsoft.AspNetCore.SignalR;

namespace PantherPetManagement_CuongCla.Hubs
{
    public class PantherHub : Hub
    {
        private readonly IPantherProfileService _pantherProfileService;
        public PantherHub(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }

        public async Task HubDelete_PantherProfile(string id)
        {
            await Clients.All.SendAsync("ReceiveDelete_PantherProfile", id);

            await _pantherProfileService.DeleteAsync(int.Parse(id));
        }
    }
}
