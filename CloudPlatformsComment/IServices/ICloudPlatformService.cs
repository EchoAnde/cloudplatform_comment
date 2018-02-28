using CloudPlatformsComment.Models;
using CloudPlatformsComment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.IServices
{
    public interface ICloudPlatformService : IBaseService<CloudPlatform>
    {
        CloudPlatform FindById(int id);

        IList<CloudPlatformListView> GetAllCloudPlatformList();
    }
}
