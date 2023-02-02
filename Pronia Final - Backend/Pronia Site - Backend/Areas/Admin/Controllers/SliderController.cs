﻿using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Database.Models;
using Pronia_Site___Backend.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Admin.ViewModels.Slider;

namespace Pronia_Site___Backend.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/slider")]
    //[Authorize(Roles = "admin")]
    public class SliderController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;

        public SliderController(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        [HttpGet("list", Name = "admin-slider-list")]
        public async Task<IActionResult> List()
        {
            var model = await _dataContext.Sliders.Select(s => new ListItemViewModel(s.Id, s.MainTitle!, s.Content!,
                _fileService.GetFileUrl(s.BackgroundİmageInFileSystem, UploadDirectory.Slider),
                s.Button!,
                s.ButtonRedirectUrl!,
                s.Order,
                s.CreatedAt)).ToListAsync();

            return View(model);
        }
        [HttpGet("add", Name = "admin-slider-add")]
        public async Task<IActionResult> AddAsync()
        {
            return View();
        }

        [HttpPost("add", Name = "admin-slider-add")]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imageNameInSystem = await _fileService.UploadAsync(model!.Backgroundİmage!, UploadDirectory.Slider);

            AddSlider(model.Backgroundİmage!.FileName, imageNameInSystem);

            return RedirectToRoute("admin-slider-list");


            void AddSlider(string imageName, string imageNameInSystem)
            {
                var slider = new Slider
                {
                    MainTitle = model.MainTitle,
                    Content = model.Content,
                    Backgroundİmage = imageName,
                    BackgroundİmageInFileSystem = imageNameInSystem,
                    Button = model.Button,
                    ButtonRedirectUrl = model.ButtonRedirectUrl,
                    Order = model.Order,
                    CreatedAt = DateTime.Now,
                };

                _dataContext.Sliders.Add(slider);

                _dataContext.SaveChanges();
            }
        }
        [HttpGet("update/{id}", Name = "admin-slider-update")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var slider = await _dataContext.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null)
            {
                return NotFound();
            }
            var model = new UpdateViewModel
            {
                Id = slider.Id,
                MainTitle = slider.MainTitle,
                Content = slider.Content,
                Button = slider.Button,
                ButtonRedirectUrl = slider.ButtonRedirectUrl,
                Order = slider.Order,
                BackgroundİmageUrl = _fileService.GetFileUrl(slider.BackgroundİmageInFileSystem, UploadDirectory.Slider)

            };
            return View(model);
        }
        [HttpPost("update/{id}", Name = "admin-slider-update")]
        public async Task<IActionResult> Update(UpdateViewModel model)
        {
            var slide = await _dataContext.Sliders.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (slide == null) return NotFound();

            if (!ModelState.IsValid) return View(model);


            await _fileService.DeleteAsync(slide.BackgroundİmageInFileSystem, UploadDirectory.Slider);
            var backGroundImageInFileSytem = await _fileService.UploadAsync(model.Backgroundİmage!, UploadDirectory.Slider);

            await UpdateSlider(model.Backgroundİmage!.FileName, backGroundImageInFileSytem);

            return RedirectToRoute("admin-slider-list");

            async Task UpdateSlider(string backGroundImageName, string backGroundImageInFileSytem)
            {
                slide.MainTitle = model.MainTitle;
                slide.Content = model.Content;
                slide.Backgroundİmage = backGroundImageName;
                slide.BackgroundİmageInFileSystem = backGroundImageInFileSytem;
                slide.Button = model.Button;
                slide.ButtonRedirectUrl = model.ButtonRedirectUrl;
                slide.Order = model.Order;


                await _dataContext.SaveChangesAsync();
            }
        }

        [HttpPost("delete/{id}", Name = "admin-slider-delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var slider = await _dataContext.Sliders.FirstOrDefaultAsync(b => b.Id == id);
            if (slider is null)
            {
                return NotFound();
            }
            await _fileService.DeleteAsync(slider.BackgroundİmageInFileSystem, UploadDirectory.Slider);
            _dataContext.Sliders.Remove(slider);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-slider-list");
        }

    }
}
