using BookWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System;

namespace BookMVC.Controllers
{
    public class BooksController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Books> bookList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Books").Result;
            bookList = response.Content.ReadAsAsync<IEnumerable<Books>>().Result;
            return View(bookList);
        }

        [HttpGet]
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Books());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Books/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Books>().Result);
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(Books books)
        {
            if (books.BookId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Books", books).Result;
                TempData["SuccessMessage"] = "Records Saved Successfully...!";

                //if (response.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index");
                //}
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Books/" + books.BookId, books).Result;
                TempData["SuccessMessage"] = "Records Saved Successfully...!";

                //if (response.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index");
                //}
            }
            return RedirectToAction("Index");
        }

    }
}
