// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
using System;
using System.Drawing;
using Microsoft.ML;

namespace Ella.Backend
{
    /// <summary>
    /// Backend for detecting faces. Based from the code from FaceBoxes.PyTorch.
    /// </summary>
    internal class FaceboxesBackend
    {
        private string modelPath;
        private MLContext mlContext;

        /// <summary>
        /// Instantiates a new FaceboxesBackend instance.
        /// </summary>
        /// <param name="path">Path to the Faceboxes model.</param>
        /// <param name="mLContext">the ML Context for Faceboxes.</param>
        public FaceboxesBackend (string path, MLContext mLContext)
        {
            modelPath = path;
            mlContext = mLContext;
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

        /// <summary>
        /// Get Prediction Data and return a <see cref="Structures.OnnxInput.FaceBox"/> Output.
        /// </summary>
        public float[] Predict(Bitmap input)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Structures.OnnxInput.FaceBox, Structures.OnnxOutput.FaceBox>(GetPredictionPipeline());
            var faceboxInput = new Structures.OnnxInput.FaceBox { Input = input };

            var prediction = predictionEngine.Predict(faceboxInput);

            return prediction.Output;
        }

        /// <summary>
        /// Predict labels from input and return a <see cref="Structures.OnnxInput.FaceBox"/> Output from the 353 output layer.
        /// </summary>
        public float[] PredictLabels(Bitmap input)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Structures.OnnxInput.FaceBox, Structures.OnnxOutput.FaceBox>(GetPredictionPipeline());
            var faceboxInput = new Structures.OnnxInput.FaceBox { Input = input };

            var prediction = predictionEngine.Predict(faceboxInput);

            return prediction.Labels;
        }
    }
}
