using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Heplers
{
    public static class FileConverter
    {
        public static byte[] ConverToByte(IFormFile file)
        {
            byte[] pic = null;
            if (file is not null)
            {
                using (Stream fileStream = file.OpenReadStream())
                {
                    using (MemoryStream memorystream = new MemoryStream())
                    {
                        fileStream.CopyTo(memorystream);
                        pic = memorystream.ToArray();
                    }
                }
            }

            return pic;
        }
    }
}
