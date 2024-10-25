using LinkDev._1stProj.BLL.common.services.interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stProj.BLL.common.services.entity
{
    public class AttacmentService : IAttachmentServices
    {
        private List<string> _AllowedExtension = new List<string> { ".png", ".jpg", ".jpeg" };
        private readonly int _AllowedMaxSize = 2_097_152;
        public string? upload(IFormFile file, string foldername)
        {
            var extension = Path.GetExtension(file.FileName);
            
            if(!_AllowedExtension.Contains(extension)) 
                return null;
            if(file.Length>_AllowedMaxSize)
                return null;

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", foldername);
            if(!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);


            var Filename = $"{Guid.NewGuid()}{extension}";
            var Filepath = Path.Combine(FolderPath,Filename);

            using var filestream = new FileStream(Filepath,FileMode.Create);
            file.CopyTo(filestream);

            return Filename;
        }
        public bool Delete(string filepath)
        {
            if(File.Exists(filepath))
            {
                File.Delete(filepath);
                return true;
            }
            return false;
        }

    }
}
