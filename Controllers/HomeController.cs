using Gym.ModefittnesEquipment;
using Gym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Controllers
{   // photo = new PhotoConvertFileToBytes(VM.File).Photo
    // <img src="data:image;base64,@System.Convert.ToBase64String()" width="180px" height="140px" />

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            FitnessStore test = new FitnessStore { Name = "test", phone_number = 000 };
            DataLayer.Data.Main_Store.Add(test);

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult LogInUser(int? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogInUser(User vm)
        {
            User user = DataLayer.Data.Users.ToList().Find(x => x.userName == vm.userName && x.password == vm.password);
            if (user != null)
            {
                user.Cart = new Cart();
                DataLayer.User = user;
                DataLayer.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.errorMessage = "ם משתמש או סיסמא אינם תקינים";
            return View(vm);
        }
        public IActionResult SignIn(int? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(User VM)
        {
            User user = DataLayer.Data.Users.ToList().Find(x => x.userName == VM.userName);
            if (user == null)
            {
                if (VM.password.Length < 8)
                {
                    VM.errorMessage = "סיסמא קצרה מידי";
                    return View(VM);
                }
                if (VM.checkUserName())
                {
                    user = new User()//יצירת אובייקט חדש 
                    {
                        userName = VM.userName,
                        password = VM.password,
                        email = VM.email,
                        firstName = VM.firstName,
                        lastName = VM.lastName,
                        address = VM.address,
                        phoneNumber = VM.phoneNumber,
                        city = VM.city

                    };
                    user.Cart = new Cart();
                }
                else
                {
                    VM.errorMessage = " נא לרשום רק באנגלית";
                    VM.userName = "";
                    return View(VM);
                }
                DataLayer.User = user;
                DataLayer.Data.Users.Add(user);
                DataLayer.Data.SaveChanges();
            }
            else
            {
                VM.errorMessage = "שם משתמש בשימוש בחר שם אחר";
                VM.userName = "";
                return View(VM);
            }
            return RedirectToAction("Index");

        }
        public IActionResult LogOutUser(User VM)
        {
            DataLayer.User.LogOut();
            DataLayer.Data.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public IActionResult AddToCart(int? id, string name)
        {
            Equipment equipment = DataLayer.Data.Equipments.ToList().Find(x => x.ID == id && x.name == name);
            ShakeAndTosaf shakeAndTosaf = DataLayer.Data.ShakeAndTosafs.ToList().Find(x => x.ID == id && x.name == name);
            if (shakeAndTosaf != null)
            {
                if (DataLayer.User.Cart.ShakeAndTosafList.ToList().Find(x => x.ShakeAndTosaf.ID == shakeAndTosaf.ID) == null)
                {
                    DataLayer.User.Cart.ShakeAndTosafList.Add(new VmShakesTosaf() { ShakeAndTosaf = shakeAndTosaf });
                }
                else
                {
                    DataLayer.User.Cart.ShakeAndTosafList.ToList().Find(x => x.ShakeAndTosaf.ID == shakeAndTosaf.ID).AddAmount();
                }
            }
            if (equipment != null)
            {
                if (DataLayer.User.Cart.EquipmentList.ToList().Find(x => x.equipment.ID == equipment.ID) == null)
                {
                    DataLayer.User.Cart.EquipmentList.Add(new VmEquipment() { equipment = equipment });
                }
                else
                {
                    DataLayer.User.Cart.EquipmentList.ToList().Find(x => x.equipment.ID == equipment.ID).AddAmount();
                }
            }
            DataLayer.Data.SaveChanges();
            return RedirectToAction("viewCart");
        }
        public IActionResult viewCart(int? id)
        {

            return View(DataLayer.User.Cart);

        }
        public IActionResult addAmuontToCart(int? id ,string name)
        {
            VmShakesTosaf shakesTosaf = DataLayer.User.Cart.ShakeAndTosafList.ToList().Find(x => x.ShakeAndTosaf.ID == id && x.ShakeAndTosaf.name == name);
            VmEquipment equipment = DataLayer.User.Cart.EquipmentList.ToList().Find(x => x.equipment.ID == id && x.equipment.name == name);
            if (equipment != null && equipment.amount<=equipment.equipment.amountAvailable)
            {
                equipment.AddAmount();
            }
            if (shakesTosaf !=null && shakesTosaf.amount<=shakesTosaf.ShakeAndTosaf.amountAvailable)
            {
                shakesTosaf.AddAmount();
            }
            DataLayer.Data.SaveChanges();
            return RedirectToAction("viewCart");
        }
        public IActionResult subAmuontFromCart(int? id, string name)
        {
            VmShakesTosaf shakesTosaf = DataLayer.User.Cart.ShakeAndTosafList.ToList().Find(x => x.ShakeAndTosaf.ID == id && x.ShakeAndTosaf.name == name);
            VmEquipment vm = DataLayer.User.Cart.EquipmentList.ToList().Find(x => x.equipment.ID == id && x.equipment.name == name);
            if (vm != null)
            {
                vm.SubAmount();

            }
            if (shakesTosaf != null)
            {
                shakesTosaf.SubAmount();

            }
            DataLayer.Data.SaveChanges();
            return RedirectToAction("viewCart");
        }
        public IActionResult DeleteFromCart(int? id)
        {
            List<VmEquipment> equipmentList = DataLayer.User.Cart.EquipmentList.ToList();
            VmEquipment equipment = DataLayer.User.Cart.EquipmentList.ToList().Find(x => x.ID == id);
            List<VmShakesTosaf> shakeAndTosafsList = DataLayer.User.Cart.ShakeAndTosafList.ToList();
            VmShakesTosaf shakeAndTosaf = DataLayer.User.Cart.ShakeAndTosafList.ToList().Find(x => x.ID == id);
            if(shakeAndTosaf!=null)
            DataLayer.User.Cart.ShakeAndTosafList.Remove(shakeAndTosaf);
            if(equipment != null)
            DataLayer.User.Cart.EquipmentList.Remove(equipment);
            DataLayer.Data.SaveChanges();
            return RedirectToAction(nameof(viewCart));

        }         
    }
}
