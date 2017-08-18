#!/bin/bash

cd PlayGround

nvm install 8.0.0

nvm use 8.0.0

npm install

dotnet build

cd ..

cd PlayGround/PlayGround.Tests

dotnet test
