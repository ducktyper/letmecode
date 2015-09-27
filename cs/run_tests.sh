#!/bin/bash

## Install CS on mac
# Visit http://www.mono-project.com/download/
# Click 'Download Mono MDK' and install

## Usage
# sh runTest.sh

for f in "$(dirname "${BASH_SOURCE[0]}")/*.cs"
do
  ## Compile
  mcs -t:library -r:nunit.framework ${f}

  ## Run test
  dll="${f%cs}dll"
  nunit-console ${dll}

  ## Clean
  rm ${dll}
done




