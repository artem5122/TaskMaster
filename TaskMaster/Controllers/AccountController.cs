using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMaster.Data.Interfaces;
using TaskMaster.Data.Models;
using TaskMaster.ViewModel;

namespace TaskMaster.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISession _session;
        private readonly IAccounts _accountRepository;

        public AccountController(IHttpContextAccessor httpContextAccessor, IAccounts accountRepository)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _accountRepository = accountRepository;
        }

        public ActionResult Register()
        {
            // Вывод формы регистрации
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid && _accountRepository.FindByName(model.Username) == null)
            {
                var account = new Account
                {
                    Name = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    IsAdmin = false,
                    Img = "/img/programmer.png"
                };

                // Добавление аккаунта в базу данных
                _accountRepository.AddAccount(account);

                _session.SetInt32("IsAuthenticated", 1);
                _session.SetString("Username", model.Username);
                _session.SetString("Img", "/img/programmer.png");
                _session.SetInt32("IsAdmin", 0);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Поиск аккаунта по имени пользователя
                var account = _accountRepository.FindByName(model.Username);

                if (account != null && account.Password == model.Password)
                {
                    // Авторизация успешна
                    // Сохраняем информацию о состоянии авторизации в сессии
                    _session.SetInt32("IsAuthenticated", 1);
                    _session.SetString("Username", model.Username);
                    _session.SetString("Img", account.Img);

                    if(account.IsAdmin==true) _session.SetInt32("IsAdmin", 1);
                    else _session.SetInt32("IsAdmin", 0);



                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Неправильные данные авторизации
                    ModelState.AddModelError("", "Неправильное имя пользователя или пароль");
                }
            }

            // Если модель недействительна или авторизация не удалась, повторное отображение формы авторизации с ошибками
            return View(model);
        }

        public ActionResult Logout()
        {
            // Выход из аккаунта
            _session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}