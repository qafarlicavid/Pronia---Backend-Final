﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Admin.ViewModels.Contact;
using Pronia_Site___Backend.Database;

namespace Pronia_Site___Backend.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/contact")]
    public class ContactController : Controller
    {
        private readonly DataContext _dataContext;

        public ContactController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region List

        [HttpGet("list", Name = "admin-contact-list")]
        public async Task<IActionResult> ListAsync()

        {
            var model = await _dataContext.Contacts
                .Select(a => new ListItemViewModel(a.Id, a.Name, a.Email, a.Message, a.Phone, a.CreatedAt, a.UpdatedAt ))
                .ToListAsync();

            return View(model);
        }

        #endregion
    }
}
