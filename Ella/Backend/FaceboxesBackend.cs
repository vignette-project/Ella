// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
using System;
using Microsoft.ML;

namespace Ella.Backend
{
    internal class FaceboxesBackend
    {
        private string modelPath;
        private readonly MLContext mlContext;

        public FaceboxesBackend (string path)
        {
            modelPath = path;
        }

        /// <summary>
        /// Loads the model and returns a <see cref="ITransformer"/> Pipeline.
        /// </summary>
        internal ITransformer GetPredictionPipeline()
        {
            try
            {
                // TODO: add directives to use DirectML for Windows, and GPU/CPU for Linux/macOS.
                var predictionPipeline = mlContext.Transforms.ApplyOnnxModel(modelPath);
                var emptyDv = mlContext.Data.LoadFromEnumerable(Array.Empty<Structures.OnnxInput.FaceBox>());

                return predictionPipeline.Fit(emptyDv);
            }
            catch
            {
                // either something fucked up or I fucked up, so throw the Exception.
                throw;
            }
        }

        public void Predict()
        {
            // TODO: figure out how to split the output of the prediction to Structures.FaceBox. If we figure it out here, it should work the same in TDDFAv2.
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Structures.OnnxInput.FaceBox, Structures.OnnxOutput.FaceBox>(GetPredictionPipeline());
        }
    }
}
