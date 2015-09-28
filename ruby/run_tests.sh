#!/bin/bash

## Usage
# sh run_tests

for f in $(dirname "${BASH_SOURCE[0]}")/*_test.rb
do
  ruby ${f}
done
