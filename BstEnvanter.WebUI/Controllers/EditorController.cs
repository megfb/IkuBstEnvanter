﻿using BstEnvanter.Business.Abstract;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    [Authorize(Roles ="admin,editor")]    
    public class EditorController : Controller
    {

        private IBrandService _brandService;
        private ICategoryService _categoryService;
        private IModelService _modelService;
        private IProductService _productService;
        private IDepartmentService _departmentService;
        private ICLocationService _clocationService;
        private ICampusService _campusService;
        private ISexService _sexService;
        private IPersonelService _personelService;
        private IStatusService _statusService;
        private ICommonService _commonService;
        private ICpuService _cpuService;
        private IGpuService _gpuService;
        private IRamService _ramService;
        private IHardDriveService _hardDriveService;
        private IServiceService _serviceService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;
        public EditorController(IBrandService brandService, ICategoryService categoryService, IModelService modelService, IProductService productService,
            IDepartmentService departmentService, ICLocationService cLocationService, ICampusService campusService, ISexService sexService, IPersonelService personelService,
            IStatusService statusService, ICommonService commonService, ICpuService cpuService, IGpuService gpuService, IRamService ramService, IHardDriveService hardDriveService,
            IServiceService serviceService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _brandService = brandService;
            _categoryService = categoryService;
            _modelService = modelService;
            _productService = productService;
            _departmentService = departmentService;
            _clocationService = cLocationService;
            _campusService = campusService;
            _sexService = sexService;
            _personelService = personelService;
            _statusService = statusService;
            _commonService = commonService;
            _cpuService = cpuService;
            _gpuService = gpuService;
            _ramService = ramService;
            _hardDriveService = hardDriveService;
            _serviceService = serviceService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   BRAND PROCESSES   #########################

        public IActionResult AddBrand()
        {
            var model = new AddBrandViewModel()
            {
                brand = new Brand()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.add(brand);
                TempData.Add("Success", $"New brand succesfully added");
                return RedirectToAction("addbrand");
            }
            TempData.Add("Alert", $"New brand could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfBrand()
        {
            var model = new ListBrandViewModel()
            {
                brand = _brandService.getAll()
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var model = new UpdateBrandViewModel()
            {
                Brand = _brandService.get(id)
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.update(brand);
                TempData.Add("Success", $"{brand.name} succesfully updated");
                return RedirectToAction("ListOfBrand");
            }
            TempData.Add("Alert", $"{brand.name} could not be updated");
            return RedirectToAction("updatebrand", brand.id);
        }
        public IActionResult DeleteBrand(int id)
        {
            _brandService.remove(id);
            TempData.Add("Success", $"A brand succesfully deleted");
            return RedirectToAction("listofbrand");
        }
        public IActionResult DetailBrand(int id)
        {
            var model = new DetailBrandViewModel()
            {
                status = _statusService.getAllWithDetailsByBrand(id),
                brand = _brandService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailBrandAtPersonel(int id)
        {
            var model = new DetailBrandViewModel()
            {
                status = _statusService.getAllWithDetailsByBrand(id),
                brand = _brandService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailBrandAtCommon(int id)
        {
            var model = new DetailBrandViewModel()
            {
                status = _statusService.getAllWithDetailsByBrand(id),
                brand = _brandService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   CATEGORY PROCESSES   ######################

        public IActionResult AddCategory()
        {
            var model = new AddCategoryViewModel()
            {
                category = new Category()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.add(category);
                TempData.Add("Success", $"New category succesfully added");
                return RedirectToAction("listofcategory");
            }
            TempData.Add("Alert", $"New category could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfCategory()
        {
            var model = new ListOfCategoryViewModel()
            {
                category = _categoryService.getAll()
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var model = new UpdateCategoryViewModel()
            {
                category = _categoryService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.update(category);
                TempData.Add("Success", $"{category.name} succesfully updated");
                return RedirectToAction("listofcategory");
            }
            TempData.Add("Alert", $"{category.name} could not be updated");
            return RedirectToAction("updatecategory", category.id);
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.remove(id);
            TempData.Add("Success", $"A category succesfully deleted");
            return RedirectToAction("listofcategory");

        }
        public IActionResult DetailCategory(int id)
        {
            var model = new DetailCategoryViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.get(id),
                id = id,
            };
            return View(model);
        }
        public IActionResult DetailCategoryAtPersonel(int id)
        {
            var model = new DetailCategoryViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.get(id),
                id = id,
            };
            return View(model);
        }
        public IActionResult DetailCategoryAtCommon(int id)
        {
            var model = new DetailCategoryViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.get(id),
                id = id,
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Model   ###################################

        public IActionResult AddModel()
        {
            var model = new AddModelViewModel()
            {
                model = new Model()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _modelService.add(model);
                TempData.Add("Success", $"New model succesfully added");
                return RedirectToAction("listofmodel");
            }
            TempData.Add("Alert", $"New model could not be added");
            return View();
        }
        public IActionResult ListOfModel()
        {
            var model = new ListOfModelViewModel()
            {
                model = _modelService.getAll()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateModel(int id)
        {
            var model = new UpdateModelViewModel()
            {
                model = _modelService.get(id)
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _modelService.update(model);
                TempData.Add("Success", $"{model.name} succesfully updated");
                return RedirectToAction("listofmodel");
            }
            TempData.Add("Alert", $"{model.name} could not be updated");
            return RedirectToAction("updatemodel", model.id);
        }
        public IActionResult DeleteModel(int id)
        {
            _modelService.remove(id);
            TempData.Add("Success", $"A model succesfully deleted");
            return RedirectToAction("listofmodel");
        }
        public IActionResult DetailModel(int id)
        {
            var model = new DetailModelViewModel()
            {
                status = _statusService.getAllWithDetailsByModel(id),
                model = _modelService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailModelAtPersonel(int id)
        {
            var model = new DetailModelViewModel()
            {
                status = _statusService.getAllWithDetailsByModel(id),
                model = _modelService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailModelAtCommon(int id)
        {
            var model = new DetailModelViewModel()
            {
                status = _statusService.getAllWithDetailsByModel(id),
                model = _modelService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Product   #################################

        public IActionResult AddProduct()
        {
            var model = new AddProductViewModel()
            {
                status = new Status(),
                product = new Product(),
                category = _categoryService.getAll(),
                brand = _brandService.getAll(),
                model = _modelService.getAll(),
                campus = _campusService.getAll(),
                cpu = _cpuService.getAll(),
                gpu = _gpuService.getAll(),
                ram = _ramService.getAll(),
                hardDrive = _hardDriveService.getAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);                
                _statusService.add(status);
                TempData.Add("Success", $"New product succesfully added");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"New product could not be added");
            return View();
        }
        public IActionResult ListOfProduct(int id)
        {
            var model = new ListOfProductViewModel()
            {
                product = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id
            };
            return View(model);
        }
        public IActionResult UpdateProduct(int id)
        {
            var model = new UpdateProductViewModel()
            {
                product = _productService.get(id),
                category = _categoryService.getAll(),
                brand = _brandService.getAll(),
                model = _modelService.getAll(),
                cpu = _cpuService.getAll(),
                gpu = _gpuService.getAll(),
                ram = _ramService.getAll(),
                hardDrive = _hardDriveService.getAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.update(product);
                TempData.Add("Success", $"{product.name} succesfully updated");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"{product.name} could not be updated");
            return RedirectToAction("updateproduct", product.id);
        }
        public IActionResult DeleteProduct(int id, int productId)
        {
            _statusService.remove(id);
            _productService.remove(productId);
            TempData.Add("Success", $"A product succesfully deleted");
            return RedirectToAction("listofproduct");
        }
        public IActionResult DetailProduct(int id)
        {
            var model = new UpdateProductViewModel()
            {
                status = _statusService.get(id),
                
            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);
            return View(model);
        }
        public IActionResult AddProductAtPersonel(int id)
        {
            var model = new AddToPersonelViewModel()
            {
                status = _statusService.get(id),
                personel = _personelService.getAll(),
                campus = _campusService.getAll(),

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProductAtPersonel(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"The product succesfully added to personel");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"The product could not be added to personel");
            return View();
        }
        public IActionResult ListofProductAtPersonel(int id)
        {
            var model = new ListOfProductAtPersonelViewModel()
            {
                product = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id

            };
            return View(model);

        }
        public IActionResult DeleteProductAtPersonel(int id)
        {
            var model = _statusService.getStatus(id);
            model.personelId = null;
            model.bstId = _userManager.GetUserId(User);
            _statusService.update(model);
            TempData.Add("Success", $"The product succesfully deleted from personel");
            return RedirectToAction("listofproductatpersonel");
        }
        [HttpGet]
        public IActionResult UpdateProductAtPersonel(int id)
        {
            var model = new UpdateProductAtPersonelViewModel()
            {
                status = _statusService.get(id),
                campus = _campusService.getAll(),
                personel = _personelService.getAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductAtPersonel(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                int id = status.id;
                TempData.Add("Success", $"The product succesfully updated");
                return RedirectToAction("listofproductatpersonel");
            }
            TempData.Add("Alert", $"The product could not be updated");
            return View();
        }
        [HttpGet]
        public IActionResult AddCommon(int id)
        {
            var model = new AddCommonViewModel()
            {
                common = new Common(),
                department = _departmentService.getAll(),
                clocation = _clocationService.getAll(),
                id = id,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCommon(Common common, int id)
        {
            if (ModelState.IsValid)
            {
                _commonService.add(common);
            }
            return RedirectToAction("addproducttocommon", new { id = id, commonId = common.id });
        }
        [HttpGet]
        public IActionResult AddProductToCommon(int id, int commonId)
        {
            var model = new AddProductAtCommonViewModel()
            {
                status = _statusService.get(id),
                common = _commonService.get(commonId),
                campus = _campusService.getAll(),

            };
            return View(model);
        }
        public IActionResult AddProductToCommon(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"The product succesfully added to common");

                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"The product could not be added to common");

            return RedirectToAction("listofproduct");
        }
        public IActionResult ListOfProductAtCommon(int id)
        {
            var model = new ListOfProductAtCommon
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id
            };
            return View(model);
        }
        public IActionResult DeleteProductAtCommon(int id, int commonId)
        {
            var model = _statusService.getStatus(id);
            model.commonId = null;
            model.bstId = _userManager.GetUserId(User);
            _statusService.update(model);
            _commonService.remove(commonId);
            TempData.Add("Success", $"The product succesfully deleted from common");

            return RedirectToAction("listofproductatcommon");
        }
        [HttpGet]
        public IActionResult UpdateCommon(int id)
        {
            var model = new AddCommonViewModel()
            {
                common = new Common(),
                department = _departmentService.getAll(),
                clocation = _clocationService.getAll(),
                id = id,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCommon(Common common, int id)
        {
            if (ModelState.IsValid)
            {
                _commonService.add(common);
            }
            return RedirectToAction("updateproductatcommon", new { id = id, commonId = common.id });
        }
        [HttpGet]
        public IActionResult UpdateProductAtCommon(int id, int commonId)
        {
            var model = new AddProductAtCommonViewModel()
            {
                status = _statusService.get(id),
                common = _commonService.get(commonId),
                campus = _campusService.getAll(),
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductAtCommon(Status status, int commonId)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                _commonService.remove(commonId);
                TempData.Add("Success", $"The product succesfully updated");

                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"The product could not be updated");

            return RedirectToAction("listofproduct");
        }
        [HttpGet]
        public IActionResult MoveToPersonel(int id)
        {
            var model = new MoveToPersonelViewModel()
            {
                status = _statusService.get(id),
                personel = _personelService.getAll(),
                campus = _campusService.getAll(),

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult MoveToPersonel(Status status, int id)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                _commonService.remove(id);
                TempData.Add("Success", $"The product succesfully moved to personel");
                return RedirectToAction("listofproductatpersonel");


            }
            TempData.Add("Alert", $"The product could not be moved to personel");
            return RedirectToAction("listofproductatpersonel");
        }
        [HttpGet]
        public IActionResult MoveToCommon(int id)
        {
            var model = new MoveToCommonViewModel()
            {
                status = _statusService.get(id),
                common = new Common(),
                clocation = _clocationService.getAll(),
                department = _departmentService.getAll(),
                campus = _campusService.getAll(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult MoveToCommon(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"The product succesfully moved to common");
                return RedirectToAction("listofproductatcommon");

            }
            TempData.Add("Alert", $"The product could not be moved to personel");
            return RedirectToAction("listofproductatcommon");
        }
        public IActionResult ListOfProductAtService(int id)
        {
            var model = new ListOfProductAtServiceViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Department   ##############################

        public IActionResult AddDepartment()
        {
            var model = new AddDepartmentViewModel()
            {
                department = new Department()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.add(department);
                TempData.Add("Success", $"New department succesfully added");
                return RedirectToAction("listofdepartment");
            }
            TempData.Add("Alert", $"New department could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfDepartment()
        {
            var model = new ListOfDepartmentViewModel()
            {
                department = _departmentService.getAll()
            };
            return View(model);
        }
        public IActionResult UpdateDepartment(int id)
        {
            var model = new UpdateDepartmentViewModel()
            {
                department = _departmentService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.update(department);
                TempData.Add("Success", $"{department.name} succesfully updated");
                return RedirectToAction("listofdepartment");
            }
            TempData.Add("Alert", $"{department.name} could not be updated");
            return RedirectToAction("updatedepartment", department.id);
        }
        public IActionResult DeleteDepartment(int id)
        {
            _departmentService.remove(id);
            TempData.Add("Success", $"A department succesfully deleted");
            return RedirectToAction("listofdepartment");
        }
        public IActionResult DetailDepartmentAtPersonel(int id)
        {
            var model = new DetailDepartmentModel()
            {
                status = _statusService.getAllWithDetailsByDepartmentAtPersonel(id),
                department = _departmentService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailDepartmentAtCommon(int id)
        {
            var model = new DetailDepartmentModel()
            {
                status = _statusService.getAllWithDetailsByDepartmentAtCommon(id),
                department = _departmentService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   CLocation   ###############################

        public IActionResult AddCLocation()
        {
            var model = new AddCLocationViewModel()
            {
                cLocation = new CLocation()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddCLocation(CLocation cLocation)
        {
            if (ModelState.IsValid)
            {
                _clocationService.add(cLocation);
                TempData.Add("Success", $"New CLocation succesfully added");
                return RedirectToAction("listofCLocation");
            }
            TempData.Add("Alert", $"New CLocation could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfCLocation()
        {
            var model = new ListOfCLocationViewModel()
            {
                cLocation = _clocationService.getAll()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateCLocation(int id)
        {
            var model = new UpdateCLocationViewModel()
            {
                cLocation = _clocationService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCLocation(CLocation cLocation)
        {
            if (ModelState.IsValid)
            {
                _clocationService.update(cLocation);
                TempData.Add("Success", $"{cLocation.name} succesfully updated");
                return RedirectToAction("listofclocation");
            }
            TempData.Add("Alert", $"{cLocation.name} could not be updated");
            return RedirectToAction("updateclocation", cLocation.id);
        }
        public IActionResult DeleteCLocation(int id)
        {
            _clocationService.remove(id);
            TempData.Add("Success", $"A clocation succesfully deleted");
            return RedirectToAction("listofclocation");
        }
        public IActionResult DetailCLocationAtCommon(int id)
        {
            var model = new DetailCLocationAtCommon()
            {
                status = _statusService.getAllWithDetailsByCLocationAtCommon(id),
                cLocation = _clocationService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailClocationAtPersonel(int id)
        {
            var model = new DetailCLocationAtPersonel()
            {
                status = _statusService.getAllWithDetailsByCLocationAtPersonel(id),
                cLocation = _clocationService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Campus   ##################################

        public IActionResult AddCampus()
        {
            var model = new AddCampusViewModel()
            {
                campus = new Campus()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCampus(Campus campus)
        {
            if (ModelState.IsValid)
            {
                _campusService.add(campus);
                TempData.Add("Success", $"New campus succesfully added");
                return RedirectToAction("listofcampus");
            }
            TempData.Add("Alert", $"New campus could not be added");
            return View();
        }
        public IActionResult ListOfCampus()
        {
            var model = new ListOfCampusViewModel()
            {
                campus = _campusService.getAll(),
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateCampus(int id)
        {
            var model = new UpdateCampusViewModel()
            {
                campus = _campusService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCampus(Campus campus)
        {
            if (ModelState.IsValid)
            {
                _campusService.update(campus);
                TempData.Add("Success", $"{campus.name} succesfully updated");
                return RedirectToAction("listofcampus");
            }
            TempData.Add("Alert", $"{campus.name} could not be updated");
            return RedirectToAction("updateclocation", campus.id);
        }
        public IActionResult DeleteCampus(int id)
        {
            _campusService.remove(id);
            TempData.Add("Success", $"A campus succesfully deleted");
            return RedirectToAction("listofcampus");
        }
        public IActionResult DetailCampus(int id)
        {
            var model = new DetailCampusModel()
            {
                status = _statusService.getAllWithDetailsByCampus(id),
                campus = _campusService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailCampusAtPersonel(int id)
        {
            var model = new DetailCampusModel()
            {
                status = _statusService.getAllWithDetailsByCampus(id),
                campus = _campusService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailCampusAtCommon(int id)
        {
            var model = new DetailCampusModel()
            {
                status = _statusService.getAllWithDetailsByCampus(id),
                campus = _campusService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Personel   ################################

        public IActionResult AddPersonel()
        {
            var model = new AddPersonelViewModel()
            {
                personel = new Personel(),
                sex = _sexService.getAll(),
                deparment = _departmentService.getAll(),
                cLocation = _clocationService.getAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelService.add(personel);
                TempData.Add("Success", $"New personel succesfully added");
                return RedirectToAction("listofpersonel");
            }
            TempData.Add("Alert", $"New personel could not be added");
            return View();
        }
        public IActionResult ListOfPersonel()
        {
            var model = new ListOfPersonelViewModel()
            {
                personel = _personelService.getAll(),
            };
            return View(model);
        }
        public IActionResult DeletePersonel(int id)
        {
            _personelService.remove(id);
            TempData.Add("Success", $"The Personel succesfully deleted");
            return RedirectToAction("listofpersonel");
        }
        [HttpGet]
        public IActionResult UpdatePersonel(int id)
        {
            var model = new UpdatePersonelViewModel()
            {
                personel = _personelService.get(id),
                sex = _sexService.getAll(),
                department = _departmentService.getAll(),
                cLocation = _clocationService.getAll()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdatePersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelService.update(personel);
                TempData.Add("Success", $"The personel succesfully updated");
                return RedirectToAction("listofpersonel");
            }
            TempData.Add("Alert", $"The personel could not be updated");
            return View();
        }
        [HttpGet]
        public IActionResult DetailPersonel(int id)
        {
            var model = new DetailPersonelViewModel()
            {
                personel = _personelService.get(id),
                status = _statusService.getAllWithDetailsByPersonel(id)

            };
            return View(model);

        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Status   ##################################

        public IActionResult AddStatus(int id)
        {
            var model = new AddStatusViewModel()
            {
                status = new Status(),
                product = _productService.get(id),
                personel = _personelService.getAll(),
                campus = _campusService.getAll(),

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.add(status);
                RedirectToAction("listofproduct");
            }
            return View();
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Cpu   #####################################
        public IActionResult ListOfCpu()
        {
            var model = new ListOfCpuModel()
            {
                cpu = _cpuService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddCpu()
        {
            var model = new AddCpuViewModel()
            {
                cpu = new Cpu(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCpu(Cpu cpu)
        {
            if (ModelState.IsValid)
            {
                _cpuService.add(cpu);
                TempData.Add("Success", $"New cpu succesfully added");

                return RedirectToAction("listofcpu");
            }
            TempData.Add("Alert", $"New cpu could not be added");

            return View();
        }
        [HttpGet]
        public IActionResult UpdateCpu(int id)
        {
            var model = new UpdateCpuViewModel()
            {
                cpu = _cpuService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCpu(Cpu cpu)
        {
            if (ModelState.IsValid)
            {
                _cpuService.update(cpu);
                TempData.Add("Success", $"The personel succesfully updated");
                return RedirectToAction("listofcpu");

            }
            TempData.Add("Alert", $"The cpu could not be updated");
            return RedirectToAction("listofcpu");

        }
        public IActionResult DeleteCpu(int id)
        {
            _cpuService.remove(id);
            TempData.Add("Success", $"The cpu succesfully deleted");
            return RedirectToAction("listofcpu");
        }
        public IActionResult DetailCpu(int id)
        {
            var model = new DetailCpuViewModel()
            {
                status = _statusService.getAllWithDetailsByCpu(id),
                cpu = _cpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailCpuAtPersonel(int id)
        {
            var model = new DetailCpuViewModel()
            {
                status = _statusService.getAllWithDetailsByCpu(id),
                cpu = _cpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailCpuAtCommon(int id)
        {
            var model = new DetailCpuViewModel()
            {
                status = _statusService.getAllWithDetailsByCpu(id),
                cpu = _cpuService.get(id)
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Gpu   #####################################

        public IActionResult ListOfGpu()
        {
            var model = new ListOfGpuViewModel()
            {
                gpu = _gpuService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddGpu()
        {
            var model = new AddGpuViewModel()
            {
                gpu = new Gpu(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddGpu(Gpu gpu)
        {
            if (ModelState.IsValid)
            {
                TempData.Add("Success", $"New gpu succesfully added");
                _gpuService.add(gpu);
                return RedirectToAction("listofgpu");
            }
            TempData.Add("Alert", $"New gpu could not be added");

            return View();
        }
        [HttpGet]
        public IActionResult UpdateGpu(int id)
        {
            var model = new UpdateGpuViewModel()
            {
                gpu = _gpuService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateGpu(Gpu gpu)
        {
            if (ModelState.IsValid)
            {
                _gpuService.update(gpu);
                TempData.Add("Success", $"The gpu succesfully updated");

                return RedirectToAction("listofgpu");
            }
            TempData.Add("Alert", $"The gpu could not be updated");

            return View();
        }
        public IActionResult DeleteGpu(int id)
        {
            _gpuService.remove(id);
            TempData.Add("Success", $"The gpu succesfully deleted");

            return RedirectToAction("listofgpu");
        }
        public IActionResult DetailGpu(int id)
        {
            var model = new DetailGpuViewModel()
            {
                status = _statusService.getAllWithDetailsByGpu(id),
                gpu = _gpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailGpuAtPersonel(int id)
        {
            var model = new DetailGpuViewModel()
            {
                status = _statusService.getAllWithDetailsByGpu(id),
                gpu = _gpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailGpuAtCommon(int id)
        {
            var model = new DetailGpuViewModel()
            {
                status = _statusService.getAllWithDetailsByGpu(id),
                gpu = _gpuService.get(id)
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Ram   #####################################

        public IActionResult ListOfRam()
        {
            var model = new ListOfRamViewModel()
            {
                ram = _ramService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddRam()
        {
            var model = new AddRamViewModel()
            {
                ram = new Ram(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddRam(Ram ram)
        {
            if (ModelState.IsValid)
            {

                _ramService.add(ram);
                TempData.Add("Success", $"New ram succesfully added");

                return RedirectToAction("listofram");
            }
            TempData.Add("Alert", $"New ram could not be added");

            return View();
        }
        public IActionResult UpdateRam(int id)
        {
            var model = new UpdateRamViewModel()
            {
                ram = _ramService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateRam(Ram ram)
        {
            if (ModelState.IsValid)
            {
                _ramService.update(ram);
                TempData.Add("Success", $"The ram succesfully updated");

                return RedirectToAction("ListOfRam");
            }
            TempData.Add("Alert", $"The ram could not be updated");

            return View();
        }
        public IActionResult DeleteRam(int id)
        {
            _ramService.remove(id);
            TempData.Add("Success", $"The ram succesfully deleted");

            return RedirectToAction("listofram");
        }
        public IActionResult DetailRam(int id)
        {
            var model = new DetailRamViewModel()
            {
                status = _statusService.getAllWithDetailsByRam(id),
                ram = _ramService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailRamAtPersonel(int id)
        {
            var model = new DetailRamViewModel()
            {
                status = _statusService.getAllWithDetailsByRam(id),
                ram = _ramService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailRamAtCommon(int id)
        {
            var model = new DetailRamViewModel()
            {
                status = _statusService.getAllWithDetailsByRam(id),
                ram = _ramService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Hard Drive   ##############################

        public IActionResult ListOfHardDrive()
        {
            var model = new ListOfHardDriveViewModel()
            {
                hardDrive = _hardDriveService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddHardDrive()
        {
            var model = new AddHardDriveViewModel()
            {
                hardDrive = new HardDrive(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddHardDrive(HardDrive hardDrive)
        {
            if (ModelState.IsValid)
            {
                _hardDriveService.add(hardDrive);
                TempData.Add("Success", $"New hard drive succesfully added");

                return RedirectToAction("listofharddrive");
            }
            TempData.Add("Alert", $"New hard drive could not be added");

            return View();
        }
        public IActionResult UpdateHardDrive(int id)
        {
            var model = new UpdateHardDriveViewModel()
            {
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateHardDrive(HardDrive hardDrive)
        {
            if (ModelState.IsValid)
            {
                _hardDriveService.update(hardDrive);
                TempData.Add("Success", $"The hard drive succesfully updated");

                return RedirectToAction("listofharddrive");
            }
            TempData.Add("Success", $"The hard drive could not be updated");

            return View();
        }
        public IActionResult DeleteHardDrive(int id)
        {
            _hardDriveService.remove(id);
            TempData.Add("Success", $"The hard drive succesfully deleted");

            return RedirectToAction("listofharddrive");
        }
        public IActionResult DetailHardDrive(int id)
        {
            var model = new DetailHardDriveViewModel()
            {
                status = _statusService.getAllWithDetailsByHardDrive(id),
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailHardDriveAtPersonel(int id)
        {
            var model = new DetailHardDriveViewModel()
            {
                status = _statusService.getAllWithDetailsByHardDrive(id),
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailHardDriveAtCommon(int id)
        {
            var model = new DetailHardDriveViewModel()
            {
                status = _statusService.getAllWithDetailsByHardDrive(id),
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Service   #################################

        public IActionResult AddService(int id)
        {
            var model = new AddServiceViewModel()
            {
                status = _statusService.get(id),
                service = new Service(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddService(Status status)
        {

            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"The product succesfully added to service");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"The product could not be added to service");

            return View();
        }
        public IActionResult DeleteService(int id)
        {
            _serviceService.remove(id);
            TempData.Add("Success", $"The service case succesfully closed");
            return RedirectToAction("listofproduct");
        }
        public IActionResult UpdateService(int id)
        {
            var model = new UpdateServiceViewModel()
            {
                status = _statusService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateService(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"The service case succesfully updated");

                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"The service case could not be updated");

            return View();
        }
        public IActionResult DetailService(int id)
        {
            var model = new DetailServiceViewModel()
            {
                status = _statusService.get(id),
            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);

            return View(model);
        }
    }
}
