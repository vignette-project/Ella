// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Ella
{
    public class Utils
    {
        public static float[] BitmapToFloat(Bitmap image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Bmp);

 
            var bytes = ms.ToArray();

            // convert MemoryStream to float array.
            // https://stackoverflow.com/questions/4635769/how-do-i-convert-an-array-of-floats-to-a-byte-and-back
            var floatArray = new float[bytes.Length / 4];

            // kudos to KoziLord for this
            // we don't need to copy memory anymore, we just do it in the same allocation space for the MemoryStream which saves us time.
            ms.Read(MemoryMarshal.AsBytes(floatArray.AsSpan()));

            return floatArray;
        }
    }
}
