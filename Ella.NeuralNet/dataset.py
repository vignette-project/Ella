# Copyright 2021 (c) the Vignette Project Authors
# Licensed under <SPDX LICENSE GOES HERE>.
import tensorflow_datasets as tfds
import tensorflow as tf


dataset = tfds.load('the300w_lp', split='train', as_supervised=True, shuffle_files=True)

dataset = dataset.shuffle(100).batch(128).prefectch(10).take(5)

for image, label in dis:
    # we would need to call MobileNetV3 and run training here.
    # But before you do, remove pass here and have the iterator run a loop properly.
    pass 
