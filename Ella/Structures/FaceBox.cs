// Copyright 2020 - 2021 Vignette Project
// Licensed under MIT. See LICENSE for details.
namespace Ella.Structures
{
    /// <summary>
    /// FaceBoxes represent one face, and declared by coordinates in Faces.
    /// </summary>
    public class FaceBox
    {
        /// <summary>
        /// Number of faces detected.
        /// </summary>
        public int FaceCount { get; set; }
        /// <summary>
        /// Face Coordinates, usually one bounding box.
        /// </summary>
        public float[] FaceCoordinates { get; set; }
        /// <summary>
        /// Vectors of faces detected.
        /// </summary>
        public float[] Faces { get; set; }
    }
}
