// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
using Microsoft.ML.Data;

namespace Ella.Structures.OnnxOutput
{
    public class FaceBox
    {
        [ColumnName("output")]
        public float[] Output;

        [ColumnName("353")]
        public float[] Labels;
    }
}
