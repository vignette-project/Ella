# Facette

Facette is a C# implementation of [Towards Fast, Accurate and Stable 3D Dense Face Alignment](https://github.com/cleardusk/3DDFA_V2) or simply known as TDDFA.

The port focuses mostly on porting the inference pipeline and does not include the training pipeline.

## Getting Started

We already supply the prebuild ONNX models for Faceboxes and our TDDFA model, however if you wish to train your own TDDFA model, we have subtreed the original TDDFAv2 repository.

Consult the `TDDFAv2` directory for build instructions.

## Running Tests

*Note: as of 03/15/2021, unit tests are not implemented yet, but this has been documented already ahead of time.*

We use `osu.Framework`'s `VisualTests` platform for this. To run the tests:

```sh
$ dotnet run Ella.Tests
```

## Reminder

Keep in mind most of the code here is work in progress. Do not use it for production purposes.