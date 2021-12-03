using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HpLayer.Services {
    public class BITMAPSIZE {
        public int W { get; set; }

        public int H { get; set; }
    }

    public interface IUploadServices {
        void PhysicalDeleteFile (string fileUrl);

        void PhysicalDeleteFile (string[] filePath);

        Task<Tuple<string, string>> SavePostedFileAsync (IFormFile formFile, BITMAPSIZE size = null);
    }

    /// <summary>
    /// upload File Service
    /// </summary>
    public class UploadServices : IUploadServices {
        public const string root = "uploads";

        // 64K. The artificial constraint due to win32 api limitations. Increasing the buffer size beyond 64k will not help in any circumstance, as the underlying SMB protocol does not support buffer lengths beyond 64k.
        private const int MaxBufferSize = 0x10000;
        private readonly IHostingEnvironment _environment;

        public UploadServices (IHostingEnvironment environment) {
            _environment = environment ??
                throw new ArgumentNullException (nameof (environment));
        }

        public async Task<Tuple<string, string>> SavePostedFileAsync (IFormFile formFile, BITMAPSIZE size = null) {
            if (formFile == null || formFile.Length == 0) {
                return null;
            }

            string saveThumbnails = null;
            string uploadsRootFolder = Path.Combine (_environment.WebRootPath, root);

            if (!Directory.Exists (uploadsRootFolder)) {
                Directory.CreateDirectory (uploadsRootFolder);
            }

            var fileExtension = Path.GetExtension (formFile.FileName);
            var fileName = Path.GetFileNameWithoutExtension (formFile.FileName);
            var newFileName = $"{fileName}{DateTime.Now.ToString("yyyyMMddHHmmssfff")}{Guid.NewGuid().ToString("N")}";
            var uploadPath = Path.Combine (uploadsRootFolder, $"{newFileName}{fileExtension}");

            using (var fileStream = new FileStream (uploadPath,
                FileMode.Create, FileAccess.Write, FileShare.None, MaxBufferSize,
                useAsync : true)) {
                await formFile.CopyToAsync (fileStream).ConfigureAwait (false);

                if (IsBITMAP (formFile)) {
                    string uploadThumbnailsPath = $"{newFileName}_thumbnails{fileExtension}";
                    var thumbnailsPath = Path.Combine (uploadsRootFolder, $"{uploadThumbnailsPath}");
                    Image image = Image.FromStream (formFile.OpenReadStream (), true, true);
                    var newImage = new Bitmap (size.W, size.H);
                    using (var g = Graphics.FromImage (newImage)) {
                        g.DrawImage (image, 0, 0, size.W, size.H);
                    }
                    newImage.Save (thumbnailsPath);
                    saveThumbnails = Path.Combine (root, $"{uploadThumbnailsPath}");
                }
                
            }

            string savePath = Path.Combine (root, $"{newFileName}{fileExtension}");
            return Tuple.Create (savePath, saveThumbnails);
        }

        public void PhysicalDeleteFile (string filePath) {
            if (!string.IsNullOrEmpty (filePath)) {
                var path = Path.Combine (_environment.WebRootPath, filePath);
                if (File.Exists (path)) {
                    File.Delete (path);
                }
            }
        }

        public void PhysicalDeleteFile (string[] filePath) {
            if (filePath.Any ()) {
                foreach (var item in filePath) {
                    var path = Path.Combine (_environment.WebRootPath, item);
                    if (File.Exists (path)) {
                        File.Delete (path);
                    }
                }
            }
        }

        private bool IsBITMAP (IFormFile formFile) {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (!string.Equals (formFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase)) {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension (formFile.FileName);
            if (!string.Equals (postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)) {
                return false;
            }
            return true;
        }
    }
}