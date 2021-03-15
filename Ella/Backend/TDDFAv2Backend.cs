// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
using System;
using Microsoft.ML;

namespace Ella.Backend
{
    internal class TDDFAv2Backend
    {
        private string modelPath;
        private MLContext mlContext;

        public TDDFAv2Backend(string path, MLContext mLContext)
        {
            modelPath = path;
            mlContext = mLContext;
        }

        public ITransformer GetPredictionPipeline()
        {
            try
            {
                var predictionPipeline = mlContext.Transforms.ApplyOnnxModel(modelPath);
                var emptyDv = mlContext.Data.LoadFromEnumerable(Array.Empty<Structures.OnnxInput.TDDFAv2>());

                return predictionPipeline.Fit(emptyDv);
            }
            catch
            {
                throw;
            }
        }


        public float[] Predict(float[] input)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Structures.OnnxInput.TDDFAv2, Structures.OnnxOutput.TDDFAv2>(GetPredictionPipeline());
            var tddfaInput = new Structures.OnnxInput.TDDFAv2 { Input = input };

            var prediction = predictionEngine.Predict(tddfaInput);

            return prediction.Output;
        }
    }
}
