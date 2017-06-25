using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mar31Fire
{
    public interface IRestService
    {


        Task <eMailStatus> SendEmailInfoAsync(eMail mail);


        Task<List<Building>> GetBuildingsAsync(valInfo ID);

        Task<confirmStatus> SendConfirmAsync(userValidation valID);


    }
}
