using Gym.Models;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.IO;
using Gym.ModefittnesEquipment;
using NPOI.SS.Formula.Functions;

namespace Gym.Models
{

    public class DataLayer : DbContext//יורש מקלאס דיביקונטקסט
    {
        public static User User = new User() { firstName = "התחבר"};
        static DataLayer data;//יוצר אובייקט מסוג דאטא

        private DataLayer() : base("server =LAPTOP-8EKOOVU6\\SQLSERVER1; initial catalog = Gym; user id = sa; password=1234")
        {//קונקשין סטרינג 
            Database.SetInitializer<DataLayer>(new DropCreateDatabaseIfModelChanges<DataLayer>());//יוצר בסיס נתונים חדש במקרה ויש שינוי
            if (Main_Store.Count() == 0)//אם החנות ריקה אז SEED
                Seed();
        }

        public static DataLayer Data//אובייקט גלובלי שיהיה אפשר לגשת אליו מבחוץ
        {
            get
            {
                if (data == null) data = new DataLayer();//אם ריק תיצור חדש
                return data;
            }
        }
        
        private void Seed()
        {
            Admin admin = new Admin() { userName = "admin", password = "12345678", email = "admin@gmail.com", firstName = "מנהל", lastName = "אתר", address = "", phoneNumber = "", city = "" };
            Admins.Add(admin);
            addFoodToMenu();
            Menu menu = new Menu() { name = "תפריט ברירת מחדל" ,NewMenu=""};
            Menus.Add(menu);
            FitnessStore fitnessStore = new FitnessStore();//חנות חדשה
            Main_Store.Add(fitnessStore);//תוסיף לטבלאות של הבסיס נתונים
            SaveChanges();//שומר את הנתונים



        }
        public void addMeat() 
        {
            addMeatFunction("meatballs.png","בשרי", "קציצות", 190, 15, 10, "קציצות בשר ברוטב", 10);
            addMeatFunction("chicken.jpg", "בשרי", "עוף", 185, 0, 26, "עוף בתנור", 8);
            addMeatFunction("pargit.png", "בשרי", "פרגית", 209, 0, 11, "פרגית בגריל", 26);
            addMeatFunction("shawarma.jpg", "בשרי", "שאוורמה", 125, 3, 5, "שווארמה על שיפוד", 17);
            addMeatFunction("steak.jpg", "בשרי", "סטייק", 265, 0, 16, "סטייק על האש", 26);

        }
        public void addParve() 
        {
            addParveFunction("falafel.jpg","פרווה", "פלאפל", 261, 35, 10, "פלאפל מטוגן", 9);
            addParveFunction("kooskoos.jpg", "פרווה", "קוסקוס", 112, 23, 0, "טעם של פעם", 4);
            addParveFunction("ptitim.jpg", "פרווה", "פתיתים", 362, 74, 1, "אפויים בתנור", 11);
            addParveFunction("rice.jpg", "פרווה", "אורז", 336, 78, 0, "על הגז", 7);
            addParveFunction("spageti.png", "פרווה", "ספגטי", 349, 71, 1, "ברוטב אדום", 11);
        }
        public void addMilk()
        {
            addMilkFunction("gvina.jpg","חלבי","גבינה צהובה", 349, 0, 28, "גבינה צהובה עמק", 24);
            addMilkFunction("gvinatazim.png", "חלבי", "גבינת עיזים", 364, 0, 30, "גבינת עיזים עמק", 22);
            addMilkFunction("koteg.png", "חלבי", "קוטג'", 275, 4, 12, "קוטג' 5% שומן", 5);
            addMilkFunction("milk.jpg", "חלבי", "חלב", 61, 4, 3, "3% שומן", 3);
            addMilkFunction("mokram.jpg", "חלבי", "מוקרם", 137, 15, 7, "ספגטי פטריות", 3);
            addMilkFunction("pizza.png", "חלבי", "פיצה", 266, 33, 10, "מרגריטה", 11);
        }
        public void addBread()
        {
            addBreadFunction("baget.jpg","לחמים", "באגט", 289, 56, 2, "לבן", 12);
            addBreadFunction("lafa.jpg", "לחמים", "לאפה", 420, 56, 2, "לבן", 12);
            addBreadFunction("parus.jpg", "לחמים", "לחם פרוס", 237, 56, 2, "לבן", 9);
            addBreadFunction("pita.png", "לחמים", "פיתה", 239, 49, 1, "לבן", 8);
        }
        public void addVegetable()
        {
            addVegetableFunction("hasa.jpeg", "ירקות", "חסה", 10, 12, 0, "ירוק", 0);
            addVegetableFunction("cucumber.jpeg", "ירקות", "מלפפון", 11, 8, 0, "ירוק", 0);
            addVegetableFunction("tomato.jpeg", "ירקות", "עגבנייה", 23, 14, 0, "אדום", 0);
            addVegetableFunction("carrot.jpeg", "ירקות", "גזר", 19, 10, 0, "כתום", 0);
        }
        public void addFruit()
        {
            addFruitFunction("banna.jpeg", "פירות", "בננה", 10, 12, 0, "צהוב", 0);
            addFruitFunction("pineapple.jpeg", "פירות", "אננס", 10, 12, 0, "צהוב", 0);
            addFruitFunction("apple.jpeg", "פירות", "תפוח", 10, 12, 0, "ירוק", 0);
            addFruitFunction("mango.jpeg", "פירות", "מנגו", 10, 12, 0, "צהוב", 0);

        }
        public void addShakeTosaf()
        {
            addShakeAndTosaf("hatif1.jpg", "allin חטיף ", "חטיף חלבון","חטיף חלבון בטעם וניל", 23, 0, 0, 0, "בדץ", "עוגיות", true, "תוספים",49,21);
            addShakeAndTosaf("whey1.jpg", "CombatXl Whey", "שייק חלבון", "שייק חלבון בטעם עוגיות", 12, 0, 0, 0, "בדץ", "עוגיות", true, "שייקים",299,13);
            addShakeAndTosaf("gainner.jpg", "CombatXl Gainner", "שייק חלבון", "שייק חלבוןופחממות בטעם וניל",15, 0, 0, 0, "בדץ", "וניל", true, "שייקים",329,12);
        }
        public void addEquipment()
        {
            addEquipmentFunction("walker.jpg", "הליכון","122",1200,"מכשיר כושר",1299,12,"הליכון","gymPro");
            addEquipmentFunction("bike.jpg", "אפני כושר", "111", 1200, "מכשיר כושר", 1299, 12, "אופנים", "gymPro");
            addEquipmentFunction("dumbell.jpeg", "משקולת יד ", "12213", 5, "משקולות", 149, 13, "משקולת יד 5 קילו", "gymPro");
            addEquipmentFunction("gymE.jpg", "מתח מקבילים","32113",1690,"מכשיר כושר",1899,8,"מתקן מתח מקבילים","gymPro");
            addEquipmentFunction("motolimpi.webp", "מוט אולימפי", "3442", 9, "משקולות", 299, 16, "מוט אולימפי ישר", "gymPro");
            addEquipmentFunction("motolimpiW.webp", "מוט אולימפי W", "87112", 7, "משקולות", 249, 10, "מוט אולימפי W", "gymPro");
            addEquipmentFunction("miskolet.png", "משקולת צלחת 10", "7611", 10, "משקולות", 89, 12, "משקולת צלחת 10 קילו", "gymPro");
            addEquipmentFunction("multitrainner.jpg", "מולטי טריינר", "3721", 2799, "מכשיר כושר", 2990, 9, "מתקן מולטי טריינר", "gymPro");
            addEquipmentFunction("crosover.jpg", "קרוסאובר", "2231", 3029, "מכשיר כושר", 3000, 5, "מתקן קרוס אובר", "gymPro");
        }
        public void addFoodToMenu() 
        {
            addMeat();
            addParve();
            addMilk();
            addBread();
            addVegetable();
            addFruit();
            addShakeTosaf();
            addEquipment();
        }
        public void addFruitFunction(string FruitPhotoPath, string category, string name, int calories, int carbs,
         int fats, string desp, int pro)
        {

            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/fruit/" + FruitPhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte[] photo = new PhotoConvertFileToBytes(File).Photo;
            Fruit fruit = new Fruit(name, category, desp, pro, calories, carbs, fats, File, photo, 1);
            {



            };
            Fruits.Add(fruit);
        }
        public void addVegetableFunction(string VegetablePhotoPath, string category, string name, int calories, int carbs,
         int fats, string desp, int pro)
        {

            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/Vegetable/" + VegetablePhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte[] photo = new PhotoConvertFileToBytes(File).Photo;
            Vegetable vegetable = new Vegetable(name, category, desp, pro, calories, carbs, fats, File, photo, 1);
            {



            };
            Vegetables.Add(vegetable);
        }
        public void addBreadFunction(string BreadPhotoPath,string category ,string name, int calories, int carbs,
           int fats, string desp, int pro)
        {

            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/bread/" + BreadPhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte[] photo = new PhotoConvertFileToBytes(File).Photo;
            Bread bread = new Bread(name, category, desp, pro, calories, carbs, fats, File, photo, 1);
            {

              
               
            };
            Breads.Add(bread);
        }
        //להוסיף חלבון בכל המקומות הרלוונטים
        public void addMeatFunction(string meatPhotoPath,string category,string name,int calories,int fats,
            int carbs,string desp,int pro) 
        {
            
            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/meat/"+ meatPhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte[] photo = new PhotoConvertFileToBytes(File).Photo;
            Besari meatName = new Besari(name, category, desp, pro, calories, carbs, fats, File, photo, 1);
            Besaris.Add(meatName);
        }
        public void addParveFunction(string ParvePhotoPath,string category, string name, int calories, int carbs,
           int fats, string desp, int pro)
        {

            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/parve/" + ParvePhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte[] photo = new PhotoConvertFileToBytes(File).Photo;
            Parve parvename = new Parve(name, category, desp, pro, calories, carbs, fats, File, photo, 1);
            Parves.Add(parvename);
        }
        public void addMilkFunction(string MilkPhotoPath,string category, string name, int calories, int carbs,
          int pro, string desp, int fats)
        {

            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/halavi/" + MilkPhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte [] photo = new PhotoConvertFileToBytes(File).Photo;
            Halavi halaviName = new Halavi(name, category, desp, pro, calories, carbs, fats, File, photo,1);
            Halavis.Add(halaviName);
        }
        public void addShakeAndTosaf(string ShakeAndTosafPhotoPath,string Name, string Category, string Description, int Protein, int Calories, int Carbs, int Fats
          ,string kosher, string taste, bool halavi, string typeOf,float price,int amountAvailable) 
        {
            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/ShakeAndTosaf/" + ShakeAndTosafPhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte[] photo = new PhotoConvertFileToBytes(File).Photo;
            ShakeAndTosaf shakeAndTosaf = new ShakeAndTosaf(Name, Category, Description, Protein, Calories, Carbs, Fats, File, photo,1 ,kosher, taste, halavi, typeOf,price, amountAvailable);
            ShakeAndTosafs.Add(shakeAndTosaf);
        }
        public void addEquipmentFunction(string EquipmentPhotoPath, string name, string serialNumber, float weight, string category, float price, int amountAvailable, string description, string brand)
        {

            var filePath = Path.GetTempFileName();
            string path = "./wwwroot/images/Equipment/" + EquipmentPhotoPath;
            var stream = System.IO.File.OpenRead(path);
            IFormFile File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            byte[] photo = new PhotoConvertFileToBytes(File).Photo;
            Equipment equipment = new Equipment(name,  serialNumber,  weight,  category,  price,  amountAvailable,  description,  brand,File,photo);
            Equipments.Add(equipment);
        }

        public DbSet<FitnessStore> Main_Store { get; set; }//מזין את הטבלה בבסיס נתונים
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Besari> Besaris { get; set; }
        public DbSet<Halavi> Halavis { get; set; }
        public DbSet<Parve> Parves { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Bread> Breads { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<ShakeAndTosaf> ShakeAndTosafs { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }

    }


}
