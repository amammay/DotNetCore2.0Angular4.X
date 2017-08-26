#!/bin/bash

cd PsuAngularNetCore2

nvm install 8.0.0

nvm use 8.0.0

npm install

dotnet build

dotnet test
