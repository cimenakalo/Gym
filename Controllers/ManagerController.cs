using Gym.ModefittnesEquipment;
using Gym.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using NPOI.SS.Formula.Udf;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Gym.Controllers
{
    public class ManagerController : Controller
    {
        // GET: ManagerController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewMenu(Menu menu)
        {
            Menu NewMenu = new Menu()
            {
                name = menu.name,
                NewMenu = "",
                NotNewMenu = "yes"

            };
            DataLayer.User.menus.Add(NewMenu);
            DataLayer.Data.SaveChanges();

            return RedirectToAction("Menu", NewMenu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFood(Food vm, int MenuID)//פונקציה שיוצאת עם האובייקט החדש מהדף ומשנה אותו
        {
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == MenuID);
            switch (vm.category)
            {
                case "בשרי":
                    Besari besari = DataLayer.Data.Besaris.ToList().Find(x => x.ID == vm.ID);
                    if (besari != null)
                    {
                        besari.name = vm.name;
                        besari.description = vm.description;
                        besari.calories = vm.calories;
                        besari.carbs = vm.carbs;
                        besari.protein = vm.protein;
                        besari.fats = vm.fats;
                        DataLayer.Data.SaveChanges();
                        return RedirectToAction("Menu", menu);
                    }
                    break;
                case "חלבי":
                    Halavi halavi = DataLayer.Data.Halavis.ToList().Find(x => x.ID == vm.ID);
                    if (halavi != null)
                    {
                        halavi.name = vm.name;
                        halavi.description = vm.description;
                        halavi.calories = vm.calories;
                        halavi.carbs = vm.carbs;
                        halavi.protein = vm.protein;
                        halavi.fats = vm.fats;
                        DataLayer.Data.SaveChanges();
                        return RedirectToAction("Menu", menu);
                    }
                    break;
                case "פרווה":
                    Parve parve = DataLayer.Data.Parves.ToList().Find(x => x.ID == vm.ID);
                    if (parve != null)
                    {
                        parve.name = vm.name;
                        parve.description = vm.description;
                        parve.calories = vm.calories;
                        parve.carbs = vm.carbs;
                        parve.protein = vm.protein;
                        parve.fats = vm.fats;
                        DataLayer.Data.SaveChanges();
                        return RedirectToAction("Menu", menu);
                    }
                    break;

                case "לחמים":
                    Bread bread = DataLayer.Data.Breads.ToList().Find(x => x.ID == vm.ID);
                    if (bread != null)
                    {
                        bread.name = vm.name;
                        //bread.typeOfbread = vm.typeOfBread;
                        bread.calories = vm.calories;
                        bread.carbs = vm.carbs;
                        bread.protein = vm.protein;
                        bread.fats = vm.fats;
                        DataLayer.Data.SaveChanges();
                        return RedirectToAction("Menu", menu);
                    }
                    break;

                case "פירות":
                    Fruit fruit = DataLayer.Data.Fruits.ToList().Find(x => x.ID == vm.ID);
                    if (fruit != null)
                    {
                        fruit.name = vm.name;
                        fruit.calories = vm.calories;
                        fruit.carbs = vm.carbs;
                        fruit.protein = vm.protein;
                        fruit.fats = vm.fats;
                        DataLayer.Data.SaveChanges();
                        return RedirectToAction("Menu", menu);
                    }
                    break;

                case "ירקות":
                    Vegetable vegetable = DataLayer.Data.Vegetables.ToList().Find(x => x.ID == vm.ID);
                    if (vegetable != null)
                    {
                        vegetable.name = vm.name;
                        vegetable.calories = vm.calories;
                        vegetable.carbs = vm.carbs;
                        vegetable.protein = vm.protein;
                        vegetable.fats = vm.fats;
                        DataLayer.Data.SaveChanges();
                        return RedirectToAction("Menu", menu);
                    }
                    break;
                case "שייקים ותוספים":
                    ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == vm.ID);
                    if (shakeAndTosaf != null)
                    {
                        shakeAndTosaf.name = vm.name;
                        shakeAndTosaf.calories = vm.calories;
                        shakeAndTosaf.carbs = vm.carbs;
                        shakeAndTosaf.protein = vm.protein;
                        shakeAndTosaf.fats = vm.fats;
                        DataLayer.Data.SaveChanges();
                        return RedirectToAction("Menu", menu);
                    }
                    break;
                default:
                    return RedirectToAction("Menu");
            }
            return RedirectToAction("Menu");

        }

        public ActionResult subAmountFromMenu(int? id, string name, int? menuId)
        {
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == menuId);//מציאת התפריט
            Food food = DataLayer.Data.Foods.ToList().Find(x => x.ID == id && x.name == name);
            Food findFood = menu.foodList.ToList().Find(x => x.ID == id && x.name == name);

            if (findFood.amount > 1)
            {
                findFood.subAmount();
                findFood.calories -= food.calories;
                findFood.protein -= food.protein;
                findFood.fats -= food.fats;
                findFood.carbs -= food.carbs;
            }
            return RedirectToAction("Menu", menu);

        }

        public ActionResult addAmountToMenu(int? id, string name, int? menuId)
        {
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == menuId);//מציאת התפריט
            Food food = DataLayer.Data.Foods.ToList().Find(x => x.ID == id && x.name == name);
            Food findFood = menu.foodList.ToList().Find(x => x.ID == id && x.name == name);
            if (findFood != null)
            {
                findFood.addAmount();
                findFood.calories += food.calories;
                findFood.protein += food.protein;
                findFood.fats += food.fats;
                findFood.carbs += food.carbs;

            }

            return RedirectToAction("Menu", menu);
        }


        public ActionResult DeleteFood(int? id, string name, int? MenuID)
        {

            Besari besari = DataLayer.Data.Besaris.ToList().Find(x => x.ID == id && x.name == name);
            Halavi halavi = DataLayer.Data.Halavis.ToList().Find(x => x.ID == id && x.name == name);
            Parve parve = DataLayer.Data.Parves.ToList().Find(x => x.ID == id && x.name == name);
            Bread bread = DataLayer.Data.Breads.ToList().Find(x => x.ID == id && x.name == name);
            Vegetable vegetable = DataLayer.Data.Vegetables.ToList().Find(x => x.ID == id && x.name == name);
            Fruit fruit = DataLayer.Data.Fruits.ToList().Find(x => x.ID == id && x.name == name);
            ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == id && x.name == name);


            if (besari != null)
                DataLayer.Data.Besaris.Remove(besari);
            if (halavi != null)
                DataLayer.Data.Halavis.Remove(halavi);
            if (parve != null)
                DataLayer.Data.Parves.Remove(parve);
            if (bread != null)
                DataLayer.Data.Breads.Remove(bread);
            if (vegetable != null)
                DataLayer.Data.Vegetables.Remove(vegetable);
            if (fruit != null)
                DataLayer.Data.Fruits.Remove(fruit);
            if (shakeAndTosaf != null)
                DataLayer.Data.ShakeAndTosafs.Remove(shakeAndTosaf);


            DataLayer.Data.SaveChanges();
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == MenuID);
            return RedirectToAction("Menu", menu);
        }


        public ActionResult EditFood(int? id, string name, int MenuID)
        {
            Besari besari = DataLayer.Data.Besaris.ToList().Find(x => x.ID == id && x.name == name);
            Parve parve = DataLayer.Data.Parves.ToList().Find(x => x.ID == id && x.name == name);
            Halavi halavi = DataLayer.Data.Halavis.ToList().Find(x => x.ID == id && x.name == name);
            Bread bread = DataLayer.Data.Breads.ToList().Find(x => x.ID == id && x.name == name);
            Vegetable vegetable = DataLayer.Data.Vegetables.ToList().Find(x => x.ID == id && x.name == name);
            Fruit fruit = DataLayer.Data.Fruits.ToList().Find(x => x.ID == id && x.name == name);
            ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == id && x.name == name);

            int menuId = MenuID;

            if (besari != null)
            {


                return View(besari);
            }
            if (halavi != null)
            {

                return View(halavi);
            }
            if (parve != null)
            {

                return View(parve);
            }
            if (bread != null)
            {

                return View(parve);
            }
            if (vegetable != null)
            {

                return View(vegetable);
            }
            if (fruit != null)
            {

                return View(fruit);
            }
            if(shakeAndTosaf!=null)
            {
                return View(shakeAndTosaf);
            }

            return View();


        }

        public ActionResult AddToMenu(string name, int? id, int? MenuID)
        {
            Food food = DataLayer.Data.Foods.ToList().Find(x => x.ID == id && x.name == name);
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == MenuID);
            if (menu.foodList.ToList().Find(x => x.name == food.name) == null)
            {
                Food foodClone = new Food(food);
                if (menu != null)
                {
                    menu.foodList.Add(foodClone);
               
                }
                DataLayer.Data.SaveChanges();
                return RedirectToAction("Menu", menu);
            }
            DataLayer.Data.SaveChanges();
            return RedirectToAction("Menu", menu);
        }
        public ActionResult DeleteMenu(int?id, int?menuId)
        {
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == menuId);//מציאת התפריט
            if (menu != null)
            DataLayer.User.menus.Remove(menu);
            DataLayer.Data.SaveChanges();
            return RedirectToAction("Menu");       
        }
        public ActionResult DeleteFromMenu(int? id, string name, int? menuId)
        {
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == menuId);//מציאת התפריט
            Food food = DataLayer.Data.Foods.ToList().Find(x => x.ID == id && x.name == name);
            if (food != null)
                menu.foodList.Remove(food);
            DataLayer.Data.SaveChanges();
            //תוסיפו כפתור שמאפשר ליצור תפריט חדש
            //ברגע שאנחנו בדף של התפריט החדש שלא יציג אופציה להכנס לתפריט ברירת מחדל
            return RedirectToAction("Menu", menu);//תחזור לפעולת מניו
        }
        public ActionResult Menu(int? id)
        {

            List<Menu> menuList = DataLayer.Data.Menus.ToList();
            Menu menu = DataLayer.User.menus.ToList().Find(x => x.ID == id);
            List<Food> foods = DataLayer.Data.Foods.ToList();
            if (menu == null)
                return View(menuList.First());//מחזיר את הרשימה של התפריט 
            else
                return View(menu);

        }
        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Delete/5
        public ActionResult AddBesariToMenu(int? id)
        {

            return View();
        }

        public ActionResult CreateBesari(int? id)//פעולה שאיתה נכנסים לדף של יצרית אובייקט בשרי
        {


            return View();
        }

        public ActionResult CreateBread(int? id)//פעולה שאיתה נכנסים לדף של יצרית אובייקט בשרי
        {


            return View();
        }
        [HttpPost]//נדרש לצורך העמסה (הוצאת האובייקט החוצה מהדף)
        [ValidateAntiForgeryToken]
        public ActionResult CreateBread(Bread VM)//פעולה שאיתה נכנסים לדף של יצרית אובייקט בשרי
        {
            Bread bread = new Bread//יצירת אובייקט חדש 
            {
                name = VM.name,//שם האבוייקט שווה לשם של האובייקט שקיבלנו מהדף
                calories = VM.calories,//קלוריות האבוייקט שווה לקלוריות של האובייקט שקיבלנו מהדף
                carbs = VM.carbs,//פחממות האבוייקט שווה לפחממות של האובייקט שקיבלנו מהדף
                typeOfbread = VM.typeOfbread,//תיאור האבוייקט שווה לתיאור של האובייקט שקיבלנו מהדף
                category = "לחמים",
                fats = VM.fats,//שומן האבוייקט שווה לשומן של האובייקט שקיבלנו מהדף
                photo = new PhotoConvertFileToBytes(VM.file).Photo
            };//הפיכת הקובץ שקיבלנו לתמונה
            DataLayer.Data.Breads.Add(bread);//הוספת האובייקט לטבלת האובייקטים הבשריים
            DataLayer.Data.SaveChanges();//שומר את הנתונים

            return RedirectToAction("Menu");//עובר לפעולת מניו 

        }
        [HttpPost]//נדרש לצורך העמסה (הוצאת האובייקט החוצה מהדף)
        [ValidateAntiForgeryToken]
        public ActionResult CreateBesari(Besari VM)//יצירת האובייקט הבשרי 
                                                   //וקבלת הנתונים מהדף והוספת לבסיס נתונים
        {
            Besari besariFood = new Besari//יצירת אובייקט חדש 
            {
                name = VM.name,//שם האבוייקט שווה לשם של האובייקט שקיבלנו מהדף
                calories = VM.calories,//קלוריות האבוייקט שווה לקלוריות של האובייקט שקיבלנו מהדף
                carbs = VM.carbs,//פחממות האבוייקט שווה לפחממות של האובייקט שקיבלנו מהדף
                description = VM.description,//תיאור האבוייקט שווה לתיאור של האובייקט שקיבלנו מהדף
                fats = VM.fats,//שומן האבוייקט שווה לשומן של האובייקט שקיבלנו מהדף
                photo = new PhotoConvertFileToBytes(VM.file).Photo,
                category = "בשרי"
            };//הפיכת הקובץ שקיבלנו לתמונה
            DataLayer.Data.Besaris.Add(besariFood);//הוספת האובייקט לטבלת האובייקטים הבשריים
            DataLayer.Data.SaveChanges();//שומר את הנתונים

            return RedirectToAction("Menu");//עובר לפעולת מניו 
        }

        public ActionResult CreateHalavi(int? id)
        {

            return View();
        }
        public ActionResult CreateVegetable(int? id)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVegetable(Vegetable VM)
        {
            Vegetable VegetableFood = new Vegetable
            {
                name = VM.name,
                calories = VM.calories,
                category = "ירקות",
                carbs = VM.carbs,
                description = VM.description,
                fats = VM.fats,
                photo = new PhotoConvertFileToBytes(VM.file).Photo
            };
            DataLayer.Data.Vegetables.Add(VegetableFood);
            DataLayer.Data.SaveChanges();

            return RedirectToAction("Menu");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHalavi(Halavi VM)
        {
            Halavi halaviFood = new Halavi
            {
                name = VM.name,
                calories = VM.calories,
                category = "חלבי",
                carbs = VM.carbs,
                description = VM.description,
                fats = VM.fats,
                photo = new PhotoConvertFileToBytes(VM.file).Photo
            };
            DataLayer.Data.Halavis.Add(halaviFood);
            DataLayer.Data.SaveChanges();

            return RedirectToAction("Menu");
        }
        public ActionResult CreateParve(int? id)
        {

            return View();
        }
        public ActionResult CreateFruit(int? id)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFruit(Fruit VM)
        {
            Fruit fruitFood = new Fruit
            {
                name = VM.name,
                calories = VM.calories,
                category = "פירות",
                carbs = VM.carbs,
                description = VM.description,
                fats = VM.fats,
                photo = new PhotoConvertFileToBytes(VM.file).Photo
            };
            DataLayer.Data.Fruits.Add(fruitFood);
            DataLayer.Data.SaveChanges();

            return RedirectToAction("Menu");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateParve(Parve VM)
        {
            Parve parveFood = new Parve
            {
                name = VM.name,
                calories = VM.calories,
                category = "פרווה",
                carbs = VM.carbs,
                description = VM.description,
                fats = VM.fats,
                photo = new PhotoConvertFileToBytes(VM.file).Photo
            };
            DataLayer.Data.Parves.Add(parveFood);
            DataLayer.Data.SaveChanges();

            return RedirectToAction("Menu");
        }
        public ActionResult CreateShakeAndTosaf(int?id)
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShakeAndTosaf(ShakeAndTosaf VM)
        {
            ShakeAndTosaf shakeAndTosaf = new ShakeAndTosaf
            {
                name = VM.name,
                calories = VM.calories,
                category = "שייקים ותוספים",
                carbs = VM.carbs,
                description = VM.description,
                fats = VM.fats,
                file=VM.file,
                photo = new PhotoConvertFileToBytes(VM.file).Photo,
                kosher = VM.kosher,
                taste = VM.taste,
                halavi= VM.halavi,
                TypeOf=VM.TypeOf

            };
            DataLayer.Data.ShakeAndTosafs.Add(shakeAndTosaf);
            DataLayer.Data.SaveChanges();

            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult GoToShakeAndTosafMenu(int? id)
        {
            List<ShakeAndTosaf> shakeAndTosafsList = DataLayer.Data.ShakeAndTosafs.ToList();


            return View(shakeAndTosafsList);
        }
        public ActionResult DeleteShakeAndTosaf(int? id)
        {
            List<ShakeAndTosaf> shakeAndTosafsList = DataLayer.Data.ShakeAndTosafs.ToList();
            ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == id);
            DataLayer.Data.ShakeAndTosafs.Remove(shakeAndTosaf);
            DataLayer.Data.SaveChanges();
            return RedirectToAction(nameof(GoToShakeAndTosafMenu));

        }
        public ActionResult EditShakeAndTosaf(int? id)
        {
            List<ShakeAndTosaf> shakeAndTosafsList = DataLayer.Data.ShakeAndTosafs.ToList();
            ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == id);
            return View(shakeAndTosaf);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditShakeAndTosaf(ShakeAndTosaf VM, int? id)
        {
            List<ShakeAndTosaf> shakeAndTosafsList = DataLayer.Data.ShakeAndTosafs.ToList();
            ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == id);

            if (shakeAndTosaf != null)
            {
                shakeAndTosaf.name = VM.name;
                shakeAndTosaf.calories = VM.calories;
                shakeAndTosaf.category = "שייקים ותוספים";
                shakeAndTosaf.carbs = VM.carbs;
                shakeAndTosaf.description = VM.description;
                shakeAndTosaf.fats = VM.fats;
                shakeAndTosaf.file = VM.file;
                shakeAndTosaf.photo = new PhotoConvertFileToBytes(VM.file).Photo;
                shakeAndTosaf.kosher = VM.kosher;
                shakeAndTosaf.taste = VM.taste;
                shakeAndTosaf.halavi = VM.halavi;
                shakeAndTosaf.TypeOf = VM.TypeOf;
                shakeAndTosaf.amountAvailable = VM.amountAvailable;
            }
            DataLayer.Data.SaveChanges();

            return RedirectToAction("GoToShakeAndTosafMenu");
        }
        public ActionResult ShakeAndTosafDetails(int id)
        {

            List<ShakeAndTosaf> shakeAndTosafsList = DataLayer.Data.ShakeAndTosafs.ToList();
            ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == id);

            return View(shakeAndTosaf);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateEquipment(int? id)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEquipment(Equipment vm)
        {
            Equipment equipment = new Equipment

            {
                name = vm.name,
                weight = vm.weight,
                brand = vm.brand,
                category = vm.category,
                description = vm.description,
                price = vm.price,
                serialNumber = vm.serialNumber,
                amountAvailable = vm.amountAvailable,
                file = vm.file,
                photo = new PhotoConvertFileToBytes(vm.file).Photo
            };
            DataLayer.Data.Equipments.Add(equipment);
            DataLayer.Data.SaveChanges();
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult GoToEquipmentMenu(int? id)
        {
            List<Equipment> equipmentList = DataLayer.Data.Equipments.ToList();


            return View(equipmentList);
        }
        public ActionResult DeleteEquipment(int? id)
        {
            List<Equipment> equipmentList = DataLayer.Data.Equipments.ToList();
            Equipment equipment = DataLayer.Data.Equipments.ToList().Find(x => x.ID == id);
            DataLayer.Data.Equipments.Remove(equipment);
            DataLayer.Data.SaveChanges();
            return RedirectToAction(nameof(GoToEquipmentMenu));

        }
        public ActionResult EditEquipment(int? id)
        {
            List<Equipment> equipmentList = DataLayer.Data.Equipments.ToList();
            Equipment equipment = DataLayer.Data.Equipments.ToList().Find(x => x.ID == id);
            return View(equipment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEquipment(Equipment vm, int? id)
        {
            List<Equipment> equipmentList = DataLayer.Data.Equipments.ToList();
            Equipment equipment = DataLayer.Data.Equipments.ToList().Find(x => x.ID == id);

            if (equipment != null)
            {
                equipment.name = vm.name;
                equipment.serialNumber = vm.serialNumber;
                equipment.weight = vm.weight;
                equipment.category = vm.category;
                equipment.price = vm.price;
                equipment.amountAvailable = vm.amountAvailable;
                equipment.description = vm.description;
                equipment.brand = vm.brand;
                equipment.file = vm.file;
            }
            DataLayer.Data.SaveChanges();

            return RedirectToAction("GoToEquipmentMenu");


        }
        public ActionResult EquipmentDetails(int id)
        {

            List<Equipment> equipment = DataLayer.Data.Equipments.ToList();
            Equipment eq = DataLayer.Data.Equipments.ToList().Find(x => x.ID == id);

            return View(eq);
        }

        public ActionResult ViewMessages()
        {
            List<Messages> messages = DataLayer.Data.Messages.ToList();
            return View(messages);
        }
        public ActionResult ReadChange(int?id)
        {
            Messages messages = DataLayer.Data.Messages.ToList().Find(x => x.Id == id);
            messages.Read = !messages.Read;
            DataLayer.Data.SaveChanges();
            return RedirectToAction("ViewMessages");

        }
        public ActionResult CreateMessages(int? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMessages(Messages M)
        {
            Messages message = new Messages
            {
                fullName = M.fullName,
                messeagIndex=M.messeagIndex,
                date=M.date,

            };
            DataLayer.Data.Messages.Add(message);
            DataLayer.Data.SaveChanges();
            return RedirectToAction("ViewMessages");
        }
        public ActionResult NotReadMessages()
        {
            List<Messages> NotReadMessages = new List<Messages>();
            foreach(Messages message in DataLayer.Data.Messages)
            {
                if (!message.Read)
                    NotReadMessages.Add(message);
            }
            DataLayer.Data.SaveChanges();
            return View("ViewMessages",NotReadMessages);

        }
        public ActionResult ReadMessages()
        {
            List<Messages> ReadMessages = new List<Messages>();
            foreach (Messages message in DataLayer.Data.Messages)
            {
                if (message.Read)
                    ReadMessages.Add(message);
            }
            DataLayer.Data.SaveChanges();
            return View("ViewMessages", ReadMessages);

        }
        public ActionResult DeleteMessage(int?id)
        {
            Messages message = DataLayer.Data.Messages.ToList().Find(x => x.Id == id);
            DataLayer.Data.Messages.Remove(message);
            DataLayer.Data.SaveChanges();
            return RedirectToAction("ViewMessages");
        }
        public IActionResult finishOrder()
        {
            string stringOrder = ""; 
            foreach (VmEquipment vmEquipment in DataLayer.User.Cart.EquipmentList.ToList())
            {
                Equipment equipment = DataLayer.Data.Equipments.ToList().Find(x => x.ID == vmEquipment.equipment.ID);
                equipment.amountAvailable -= vmEquipment.amount;
                if (equipment.amountAvailable < 5)
                {
                    DataLayer.Data.Messages.Add(new Messages { messeagIndex = "מוצר " + equipment.name + "עומד להיגמר" });
                    if (equipment.amountAvailable <= 0)
                    {
                        equipment.isAvailable = false;
                        equipment.amountAvailable = 0;
                    }
                }
                stringOrder += vmEquipment.toString + "\n";
                
            }
            foreach (VmShakesTosaf vmShakesTosaf in DataLayer.User.Cart.ShakeAndTosafList.ToList())
            {
                ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == vmShakesTosaf.ShakeAndTosaf.ID);
                shakeAndTosaf.amountAvailable -= vmShakesTosaf.amount;
                if (shakeAndTosaf.amountAvailable < 5)
                {
                    DataLayer.Data.Messages.Add(new Messages { messeagIndex = "מוצר " + vmShakesTosaf.ShakeAndTosaf.name + "עומד להיגמר" });
                    if (shakeAndTosaf.amountAvailable <= 0)
                    {
                        shakeAndTosaf.isAvailable = false;
                        shakeAndTosaf.amountAvailable = 0;
                    }
                }
                stringOrder += vmShakesTosaf.toString + "\n";
              
            }
            Order order = new Order()
            {
                orderDetails =
                "שם מזמין:"+ DataLayer.User.firstName +" "+ DataLayer.User.lastName +"\n"+
                "כתובת:" +DataLayer.User.address+" "+DataLayer.User.city +"\n"+
                "מספר טלפון:"+DataLayer.User.phoneNumber+"\n" +
                "תוכן הזמנה:"+stringOrder+"\n"+
                "מחיר שולם:"+DataLayer.User.Cart.totalPrice
            };
             DataLayer.Data.Messages.Add(new Messages
            {
                messeagIndex = "התקבלה הזמנה חדשה: "+ stringOrder + "מחיר שולם:" + DataLayer.User.Cart.totalPrice,
                fullName = DataLayer.User.firstName + " " + DataLayer.User.lastName,
            });
            DataLayer.User.orders.Add(order);
            DataLayer.User.Cart = new Cart();
            DataLayer.Data.SaveChanges();
            return RedirectToAction("viewOrder");

        }

        public IActionResult viewOrder()
        {

            return View(DataLayer.User.orders);

        }
        public ActionResult payment(Order order)
        {
            return View(order);
        }
        public ActionResult searchMessage(string? str)
        {
            List<Messages> SMsg= new List<Messages>();
            foreach (Messages messages in DataLayer.Data.Messages)
            {
                if (str != null)
                {
                    if(messages.fullName!=null)
                    {
                        if (messages.fullName.Contains(str))
                            SMsg.Add(messages);
                    }
                    if (messages.messeagIndex != null)
                    {
                        if(messages.messeagIndex.Contains(str))
                            SMsg.Add(messages);
                    }

                }
            }
            return View("ViewMessages", SMsg);

        }
        
        public ActionResult Search(string?name)
        {
            List<Equipment> eqList = new List<Equipment>();
            List<ShakeAndTosaf> shkList = new List<ShakeAndTosaf>();
              foreach (Equipment equipment in DataLayer.Data.Equipments)
              {
                  if (equipment != null)
                  {
                      if (equipment.name.Contains(name) || equipment.description.Contains(name) || equipment.category.Contains(name)
                          || equipment.brand.Contains(name))
                          eqList.Add(equipment);
                  }
              }
              foreach (ShakeAndTosaf shakeAndTosaf in DataLayer.Data.ShakeAndTosafs)
              {
                  if (shakeAndTosaf != null)
                  {
                      if (shakeAndTosaf.name.Contains(name) || shakeAndTosaf.taste.Contains(name) || shakeAndTosaf.TypeOf.Contains(name))
                          shkList.Add(shakeAndTosaf);
                  }
              }
              Search search = new Search() { Equipmentlist = eqList, shakeAndTosaflist = shkList };
              return View(search);  
        }
        public ActionResult viewUsers()
        {
            List<User> users = DataLayer.Data.Users.ToList();
            return View(users);
        }
        public ActionResult EditUser(int?id)
        {
            List<User> userList = DataLayer.Data.Users.ToList();
            User user = DataLayer.Data.Users.ToList().Find(x => x.ID == id);
            return View(user);
        }
    }
}
