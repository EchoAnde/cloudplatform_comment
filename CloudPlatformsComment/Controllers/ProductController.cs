using CloudPlatformsComment.IServices;
using CloudPlatformsComment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ICloudProductService cloudProductService, ICloudPlatformService cloudPlatformService)
        {
            _cloudPlatformService = cloudPlatformService;
            _cloudProductService = cloudProductService;
        }

        public IActionResult List(int? platformId)
        {
            if (platformId.HasValue)
            {

                var platform = _cloudPlatformService.FindById(platformId.Value);
                if (platform != null)
                {
                    var model = new CloudProductListViewModel()
                    {
                        PlatformId = platform.Id,
                        PlatformName = platform.PlatformName
                    };
                    model.Products = _cloudProductService.LoadEntities(m => m.CloudPlatform.Id == platformId.Value)?.ToList();
                    return View(model);
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }
    }
}
