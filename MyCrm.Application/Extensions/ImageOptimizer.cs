﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;


namespace MyCrm.Application.Extensions
{
    public class ImageOptimizer
    {
        public void ImageResizer(string inputImagePath, string outputImagePath, int? width, int? height)
        {
            var customWidth = width ?? 100;

            var customHeight = height ?? 100;

         ////   using (var image = Sixlabors.ImageSharp.Image.Load(inputImagePath))
         //   {
         //       image.Mutate(x => x.Resize(customWidth, customHeight));

         //       image.Save(outputImagePath, new JpegEncoder
         //       {
         //           Quality = 100
         //       });
         //   }
        }
    }
}
