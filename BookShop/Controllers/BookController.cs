using BookShop.Models;
using BookShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using System.IO;
using System.Security.Claims;
using BookShop.Heplers;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly ICoverAndTypeService _coverAndTypeService;
        private readonly IPublishingHauseService _publishingService;
        private readonly IAccountService _accountService;
        private readonly IPurchaseHistoryService _purchaseService;
        private readonly ICommentService _commentService;
        private readonly ISessionHelper _sessionHelper;

        public BookController(IBookService service, ICoverAndTypeService coverAndTypeService,
                              IPublishingHauseService publishingService, IAccountService accountService,
                              IPurchaseHistoryService purchaseService, ICommentService commentService,
                              ISessionHelper sessionHelper)
        {
            _publishingService = publishingService;
            _coverAndTypeService = coverAndTypeService;
            _service = service;
            _accountService = accountService;
            _purchaseService = purchaseService;
            _commentService = commentService;
            _sessionHelper = sessionHelper;
        }

        public IActionResult Home(int pageNumber = 1)
        {
            var result = new PagedResult<BookViewModel>
            {
                Data = _service.GetTopBooks(pageNumber),
                TotalItems = _service.GetNumberOfTopBook(),
                PageNumber = pageNumber,
                PageSize = 4
            };

            ViewBag.ShowRecomended = false;

            if (!String.IsNullOrEmpty(Request.Cookies["key"]))
            {
                List<BookViewModel> books = _service.GetRecommendedBooks(Request.Cookies["key"]);
                ViewBag.ShowRecomended = true;
                ViewBag.Type = books.First().TypeOfBook;
                ViewBag.Recommended = books;
            }

            return View(result);
        }

        public IActionResult Index(int pageNumber = 1)
        {
            var result = new PagedResult<BookViewModel>
            {
                Data = _service.GetBooks(pageNumber),
                TotalItems = _service.GetNumberOfBook(),
                PageNumber = pageNumber,
                PageSize = 8
            };

            return View(result);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string phrase)
        {
            return View(_service.GetBooks(phrase));
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Manage()
        {
            return View();
        }

        [Authorize(Roles ="SuperAdmin, Admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Add()
        {
            SetDropDawns();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Add(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if(files.Any())
                    book.Picture = FileConverter.ConverToByte(files[0]);

                _service.Create(book);
                return RedirectToAction(nameof(Manage));
            }
            else
            {
                SetDropDawns();
                return View(book);
            }
        }

        private void SetDropDawns()
        {
            List<CoverViewModel> covers = _coverAndTypeService.GetCovers();
            covers.Insert(0, new CoverViewModel { Id = 0, Name = "Select Cover" });
            ViewBag.Covers = covers;
            List<TypeOfBookViewModel> types = _coverAndTypeService.GetTypes();
            types.Insert(0, new TypeOfBookViewModel { Id = 0, Name = "Select Type" });
            ViewBag.TypesOfBook = types;
            List<PublishingHauseViewModel> hauses = _publishingService.GetHauses();
            hauses.Insert(0, new PublishingHauseViewModel { Id = 0, Name = "Select Hause" });
            ViewBag.PubHauses = hauses;
        }

        public IActionResult Details(int id)
        {
            BookViewModel book = _service.GetBook(id);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(14);
            Response.Cookies.Append("key", book.TypeOfBook, cookieOptions);
            return View(book);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Update(int id)
        {
            SetDropDawns();
            return View(_service.GetBook(id));
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        public IActionResult Update(int id, BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Any())
                    book.Picture = FileConverter.ConverToByte(files[0]);

                _service.Update(id, book);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                SetDropDawns();
                return View();
            }          
        }

        [Authorize]
        public IActionResult AddComment(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                comment.AuthorId = _accountService.GetUser(User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value).Id;
                _commentService.AddComment(comment);
            }

            return RedirectToAction(nameof(Details), new { id = comment.BookId });
        }

        [Authorize]
        public IActionResult AddToShopCard(int id)
        {
            _sessionHelper.AddBook(_service.GetBookToShopCard(id));

            return RedirectToAction(nameof(ShopCard));
        }

        [Authorize]
        public IActionResult TakeOutShopCard(int id)
        {
            _sessionHelper.RemoveBook(id);

            return RedirectToAction(nameof(ShopCard));
        }

        [Authorize]
        public IActionResult ShopCard()
        {
            ShopCardViewModel shopCard = _sessionHelper.GetShopCard();

            ViewBag.Count = shopCard.Count;
            ViewBag.Price = shopCard.Price;

            return View(shopCard.Books);
        }

        [Authorize]
        public IActionResult Buy()
        {
            ShopCardViewModel shopCard = _sessionHelper.GetShopCard();

            ViewBag.Count = shopCard.Count;
            ViewBag.Price = shopCard.Price;

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Buy(PurchaseHistoryViewModel purchase)
        {
            if (ModelState.IsValid)
            {
                ShopCardViewModel shopCard = _sessionHelper.GetShopCard();

                PurchaseHistoryViewModel newPurchase = new()
                {
                    FirstName = purchase.FirstName,
                    LastName = purchase.LastName,
                    Adress = purchase.Adress,
                    BuyerId = _accountService.GetUser(User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value).Id,
                    Books = shopCard.Books,
                    ToPay = shopCard.Price
                };

                _sessionHelper.DeleteSession();

                _purchaseService.Create(newPurchase);
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }
    }
}