// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.ML;

namespace Ella.Backend
{
    internal class FaceboxesBackend
    {

        internal readonly string AssetsPath = @"../Model/";
        internal readonly string ModelFileName = @"FaceBoxesProd.onnx";
        private readonly MLContext mlContext;
        private IList<string> faceboxesBoundingBoxes;

        private ITransformer loadModel (string modelPath)
        {
#if DEBUG
            Console.WriteLine($"loading model: {modelPath}");
#endif
            try
            {
                var fileStream = File.OpenRead($"{AssetsPath}/{ModelFileName}");
                var model = mlContext.Model.Load(fileStream, Structures.OnnxInput.FaceBox);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
