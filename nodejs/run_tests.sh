#!/bin/bash

for f in $(dirname "${BASH_SOURCE[0]}")/*_test.js
do
  node ${f}
done
