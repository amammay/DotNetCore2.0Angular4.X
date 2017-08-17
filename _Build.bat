@echo off
setlocal

set _projectName=PlayGround
set _solution=%_projectName%.sln
set _codeProject=src\%_projectName%.csproj
set _testProject=test\%_projectName%.tests.csproj

set _config=%1
if not defined _config (
  set _config=Debug
)

echo Building Config '%_config%'
echo Solution: '%_solution%'
echo Code: '%_codeProject%'
echo Test: '%_testProject%'

echo --------------------------
echo !!! Restoring packages !!!
echo --------------------------
dotnet restore

echo -------------------------
echo !!! Cleaning solution !!!
echo -------------------------
dotnet clean %_solution%

echo -------------------------
echo !!! Building solution !!!
echo -------------------------
dotnet build %_solution% -c %_config%

endlocal
@echo on
