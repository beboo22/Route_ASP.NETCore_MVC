using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace LinkDev._1stProj.BLL.common.services.interfaces
{
    public interface IAttachmentServices
    {
        

        public string? upload(IFormFile file, string foldername);


        bool Delete(string filepath);

    }
}
