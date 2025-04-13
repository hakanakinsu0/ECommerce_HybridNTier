using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels;
using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        readonly ICategoryManager _catManager;
        readonly IMapper _mapper;

        public CategoryController(ICategoryManager catManager, IMapper mapper)
        {
            _catManager = catManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<CategoryDto> categoryDtos = await _catManager.GetAllAsync();
            List<CategoryResponseModel> categories = _mapper.Map<List<CategoryResponseModel>>(categoryDtos);

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequestModel model)
        {
            if(ModelState.IsValid)
            {
                await _catManager.CreateAsync(_mapper.Map<CategoryDto>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int id)
        {
            UpdateCategoryRequestModel model =_mapper.Map<UpdateCategoryRequestModel>( await _catManager.GetByIdAsync(id));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await _catManager.UpdateAsync(_mapper.Map<CategoryDto>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            TempData["Message"] = await _catManager.RemoveAsync(await _catManager.GetByIdAsync(id));
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Pacify(int id)
        {
            await _catManager.MakePassiveAsync(await _catManager.GetByIdAsync(id));
            return RedirectToAction("Index");
        }
    }
}
