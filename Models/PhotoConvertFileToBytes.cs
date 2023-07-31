using Microsoft.AspNetCore.Http;
using System.IO;


namespace Gym.Models
{
    public class PhotoConvertFileToBytes
    {
        string delete = "";
        public PhotoConvertFileToBytes(IFormFile file)//מקבל קובץ
        {
            if (file == null) { Photo = new byte[0]; return; }//אם ריק תיצור מערך מאופס
            MemoryStream stream = new MemoryStream();//מקום בזכרון
            file.CopyTo(stream);//מעתיק קובץ למקום החדש הזמני
            Photo = stream.ToArray();//המקום החדש למערך
        }
        public byte[] Photo { get;}
    }
}
