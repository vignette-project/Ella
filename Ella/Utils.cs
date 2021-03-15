// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Ella
{
    public class Utils
    {
        public static float[] BitmapToFloat(Bitmap image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Bmp);

            ms.Seek(0, SeekOrigin.Begin);
            var bytes = ms.ToArray();

            // convert MemoryStream to float array.
            // https://stackoverflow.com/questions/4635769/how-do-i-convert-an-array-of-floats-to-a-byte-and-back
            var floatArray = new float[bytes.Length / 4];
            Buffer.BlockCopy(bytes, 0, floatArray, 0, bytes.Length);

            return floatArray;
        }
    }
}
