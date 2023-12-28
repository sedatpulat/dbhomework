using DatabaseHomeWork.UI.Models;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DatabaseHomeWork.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbModelContext _dbModelContext;

        public HomeController(ILogger<HomeController> logger, DbModelContext dbModelContext)
        {
            _logger = logger;
            _dbModelContext = dbModelContext;
        }

        public IActionResult Index()
        {
            var allCustomers = _dbModelContext.Customers.ToList();
            return View(allCustomers);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }
        public IActionResult EditCustomer(int customerId)
        {
            var customer = _dbModelContext.Customers.FirstOrDefault(x => x.CustomerId == customerId);
            return View(customer);
        }
        [HttpPost]
        public IActionResult EditCustomer(DataModel.Entities.Customer customer)
        {
            var result = _dbModelContext.Customers.FirstOrDefault(b => b.CustomerId == customer.CustomerId);
            if (result != null)
            {
                result.Surname = customer.Surname;
                result.Email = customer.Email;
                result.Phone = customer.Phone;
                result.Address = customer.Address;
                result.Gender = customer.Gender;
                result.DateOfBirth = customer.DateOfBirth;
                result.Name = customer.Name;
                _dbModelContext.SaveChanges();
            }
            return RedirectToAction("EditCustomer", new { customerId = customer.CustomerId });
        }
        [HttpPost]
        public IActionResult AddCustomer(DataModel.Entities.Customer customer)
        {
            _dbModelContext.Customers.Add(customer);
            _dbModelContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AddCar(DataModel.Entities.Car car)
        {
            _dbModelContext.Cars.Add(car);
            _dbModelContext.SaveChanges();

            return Json(true);
        }
        public ActionResult GetCars(int customerId)
        {
            var list = _dbModelContext.Cars.Where(x => x.CustomerId == customerId).ToList();
            return Json(list);
        }

        [HttpPost]
        public ActionResult AddPolicy(DataModel.Entities.InsurancePolicy insurancePolicy)
        {
            var findCarPolicy = _dbModelContext.InsurancePolicys.FirstOrDefault(x => x.CarId == insurancePolicy.CarId && insurancePolicy.PolicyStartDate <= x.PolicyStartDate && insurancePolicy.PolicyEndDate >= insurancePolicy.PolicyEndDate);
            if (findCarPolicy == null)
            {
                Random r = new Random();
                insurancePolicy.PolicyNumber = r.Next().ToString();
                _dbModelContext.InsurancePolicys.Add(insurancePolicy);
                _dbModelContext.SaveChanges();

                return Json(true);
            }
            else
            {
                return Json("Bu araç için eklenmiş poliçe bulunmaktadır.");
            }
        }

        public ActionResult GetPolicy(int customerId)
        {
            var carList = _dbModelContext.Cars.Where(x => x.CustomerId == customerId).Select(x => x.CarId).ToList();
            var list = _dbModelContext.InsurancePolicys.Where(x => carList.Contains(x.CarId)).ToList();
            return Json(list);
        }
        public ActionResult GetItemPolicy(int policyId)
        {
            var item = _dbModelContext.InsurancePolicys.FirstOrDefault(x => x.PolicyId == policyId);
            return Json(item);
        }

        [HttpPost]
        public ActionResult AddPayment(DataModel.Entities.PremiumPayment premiumPayment)
        {
            var findPayment = _dbModelContext.PremiumPayments.FirstOrDefault(x => x.PolicyId == premiumPayment.PolicyId);
            if (findPayment == null)
            {
                _dbModelContext.PremiumPayments.Add(premiumPayment);
                _dbModelContext.SaveChanges();

                return Json(true);
            }
            else
            {
                return Json("Bu poliçe için ödeme işlemi yapılmıştır!");
            }
        }

        public ActionResult GetPayment(int customerId)
        {
            var carList = _dbModelContext.Cars.Where(x => x.CustomerId == customerId).Select(x => x.CarId).ToList();
            var getpolicyList = _dbModelContext.InsurancePolicys.Where(x => carList.Contains(x.CarId)).Select(x => x.PolicyId).ToList();
            var list = getpolicyList.Count > 0 ? _dbModelContext.PremiumPayments.Where(x => getpolicyList.Contains(x.PolicyId)).ToList() : null;
            return Json(list);
        }

        [HttpPost]
        public ActionResult AddAccidents(DataModel.Entities.Accidents accidents)
        {
            _dbModelContext.Accidents.Add(accidents);
            _dbModelContext.SaveChanges();

            return Json(true);
        }

        [HttpPost]
        public ActionResult DeleteAccidents(int id)
        {
            var item = _dbModelContext.Accidents.FirstOrDefault(x => x.AccidentId == id);
            _dbModelContext.Accidents.Attach(item);
            _dbModelContext.Accidents.Remove(item);
            _dbModelContext.SaveChanges();
            return Json(true);
        }
        [HttpPost]
        public ActionResult DeletePayment(int id)
        {
            var item = _dbModelContext.PremiumPayments.FirstOrDefault(x => x.PaymentId == id);
            _dbModelContext.PremiumPayments.Attach(item);
            _dbModelContext.PremiumPayments.Remove(item);
            _dbModelContext.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public ActionResult DeletePolicy(int id)
        {
            var item = _dbModelContext.InsurancePolicys.FirstOrDefault(x => x.PolicyId == id);
            _dbModelContext.InsurancePolicys.Attach(item);
            _dbModelContext.InsurancePolicys.Remove(item);
            _dbModelContext.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public ActionResult DeleteCar(int id)
        {
            var item = _dbModelContext.Cars.FirstOrDefault(x => x.CarId == id);
            _dbModelContext.Cars.Attach(item);
            _dbModelContext.Cars.Remove(item);
            _dbModelContext.SaveChanges();
            return Json(true);
        }

        public ActionResult GetAccidents(int customerId)
        {
            var getCarList = _dbModelContext.Cars.Where(x => x.CustomerId == customerId).Select(x => x.CarId).ToList();
            var list = _dbModelContext.Accidents.Where(x => getCarList.Contains(x.CarId)).ToList();
            return Json(list);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
