﻿using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
