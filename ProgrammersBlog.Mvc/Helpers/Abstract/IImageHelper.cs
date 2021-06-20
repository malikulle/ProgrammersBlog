using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.WebMvc.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<UploadedImageDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType,string folderName= null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
