using LionPetManagement.Service;
using Microsoft.AspNetCore.SignalR;

namespace LionPetManagement_CuongCla.Hubs
{
    public class LionHub : Hub
    {
            private readonly ILionProfileService _lionProfileService;
            public LionHub(ILionProfileService lionProfileService)
            {
                _lionProfileService = lionProfileService;
            }

            public async Task HubDelete_LionProfile(string id)
            {
                await Clients.All.SendAsync("ReceiveDelete_LionProfile", id);

                await _lionProfileService.DeleteAsync(int.Parse(id));
            }
    }
}
