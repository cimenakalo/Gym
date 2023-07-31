using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Gym.ModefittnesEquipment
{
    public class Equipment
    {
        public Equipment(string name,string serialNumber,float weight,string category,float price,int amountAvailable,string description,string brand,IFormFile file, byte[] photo)
        {
            this.name = name;
            this.serialNumber = serialNumber;
            this.weight = weight;
            this.category = category;
            this.price = price;
            this.amountAvailable = amountAvailable;
            this.description = description;
            this.brand = brand;
            this.file = file;
            this.photo = photo;
        }
        public Equipment() { }
        [Key]
        public int ID { get; set; }
        [Display(Name="שם מוצר")]
        public string name { get; set; }
        [Display(Name =  "מק'ט")]
        public string serialNumber { get; set; }
        [Display(Name = "משקל")]

        public float weight { get; set; }
        [Display(Name = "קטגוריה ")]

        public string category { get; set; }
        [Display(Name = "מחיר")]
        public float price { get; set; }
        [Display(Name = "כמות מלאי")]
        public int amountAvailable { get; set; }
        [Display(Name = "תיאור המוצר")]
        public string description { get; set; }
        [Display(Name = "מותג")]
        public string brand { get; set; }
        [Display(Name ="קובץ")]
        public IFormFile file { get; set; }
        [Display(Name ="תמונה")]
        public byte[] photo { get; set; }
        public bool isAvailable { get; set; }
        public string Available()
        {
            if (isAvailable)
                return "המוצר זמין במלאי";
            return " המוצר לא זמין במלאי";
        }
        public void ChangeAvailable()
        {
            isAvailable = !isAvailable;
        }

    }

}

