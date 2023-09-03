@echo off

echo Deleting old files ...
rmdir /s /q docs
del api\*.yml

lprun7 build.linq D:\src\pdn\src\PaintDotNet\bin\Release %*
