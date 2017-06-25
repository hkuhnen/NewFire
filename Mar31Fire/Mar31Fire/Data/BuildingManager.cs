using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mar31Fire
{
    public class BuildingManager
    {
        IRestService restService;

        public BuildingManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Building>> GetTasksAsync(valInfo ID)
        {
            return restService.GetBuildingsAsync(ID);
        }

        public Task<eMailStatus> SendEmailAsync(eMail mail)
        {
            return restService.SendEmailInfoAsync(mail);
        }

        public Task<confirmStatus> SendConfirmAsync(userValidation ID)
        {
            return restService.SendConfirmAsync(ID);
        }
    }
}
