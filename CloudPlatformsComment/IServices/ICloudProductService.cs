﻿using CloudPlatformsComment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.IServices
{
    public interface ICloudProductService : IBaseService<CloudProduct>
    {
        CloudProduct FindById(int id);
    }
}
