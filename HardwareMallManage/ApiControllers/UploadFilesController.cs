using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bll.HardwareMall;
using HardwareMall.Tool;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.HardwareMall;

namespace HardwareMall.Manage.ApiControllers
{
    /// <summary>
    /// 上传文件Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {
        private readonly BllW_ProductImg _productImg = Bll.Base.HardwareMall.BllW_ProductImg.Instance();

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost("upLoadImg")]
        public ApiResult<string> UpLoadImg([FromQuery]string Path = "")
        {
            var ServerPath = ConfigHelper.Configuration["ImgFilePath"].ToString() + Path + "\\";
            var SavePath = ConfigHelper.Configuration["ImgSavePath"].ToString() + Path + "\\";
            var res = new ApiResult<string>() { Code = 1, Message = "操作成功", Success = true };
            var imgFile = Request.Form.Files[0];
            if (imgFile != null && !string.IsNullOrEmpty(imgFile.FileName))
            {
                var filename = Guid.NewGuid().ToString() + "." + imgFile.FileName.Split('.')[1];
                if (!System.IO.Directory.Exists(ServerPath))
                {
                    System.IO.Directory.CreateDirectory(ServerPath);
                }
                var FilePathAndName = ServerPath + filename;
                //如果存在文件，就将其删除
                if (System.IO.File.Exists(FilePathAndName))
                {
                    System.IO.File.Delete(FilePathAndName);
                }
                using (var fStream = new FileStream(FilePathAndName, FileMode.CreateNew)) //添加文件成功
                {
                    imgFile.CopyTo(fStream);
                }
                res.Data =SavePath + filename;
            }
            return res;
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        [HttpPost("UploadCKEFileUrl")]
        public async Task<object> UploadCKEFileUrl()
        {
            // CKEditor提交的很重要的一个参数  
            string callback = Request.Query["ckCsrfToken"];
            var form = Request.Form;
            var img = form.Files[0]; //获取图片
            string fileName = img.FileName;
            var openReadStream = img.OpenReadStream();
            byte[] buff = new byte[openReadStream.Length];
            await openReadStream.ReadAsync(buff, 0, buff.Length);
            string filenameGuid = Guid.NewGuid().ToString();
            string fileType = FileHelper.GetPostfixStr(fileName);
            var ImgPath = ConfigHelper.Configuration["ImgFilePath"] + "CKEFile\\";
            var bowerPath = filenameGuid + fileType;//获取到图片保存的路径，这边根据自己的实现
            var resultPath = ConfigHelper.Configuration["ImgServerUrl"] + "/Img/CKEFile/" + bowerPath;
            var savePath = ImgPath + bowerPath;
            if (!System.IO.Directory.Exists(ImgPath))
            {
                System.IO.Directory.CreateDirectory(ImgPath);//不存在就创建目录
            }
            using (FileStream fs = new FileStream(savePath, FileMode.Create))
            {
                await fs.WriteAsync(buff, 0, buff.Length);
                //服务器返回格式
                return new { uploaded = 1, url = resultPath };
            }
        }
    }
}