// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
using System.Drawing;
using Microsoft.ML.Data;

namespace Ella.Structures.OnnxInput
{
    public class FaceBox
    {
        [ColumnName("input")]
        public float[] Input;
    }
}
