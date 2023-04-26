using Portfolio.Repository;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using static Portfolio.Repository.Repository;
namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository; 

        public HomeController(ILogger<HomeController> logger,IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(MailModel mailModel)
        {
            mailModel.emailC = string.IsNullOrEmpty(mailModel.email);
            mailModel.messageC = string.IsNullOrEmpty(mailModel.message);
            mailModel.nameC = string.IsNullOrEmpty(mailModel.name);
            mailModel.subjectC = string.IsNullOrEmpty(mailModel.subject);
            if (mailModel.emailC == true && mailModel.messageC == true && mailModel.nameC == true && mailModel.subjectC == true)
            {
                return View();
            }
            else
            {
                _repository.SendMail(mailModel);
                return View();
            }
          
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
    }
}