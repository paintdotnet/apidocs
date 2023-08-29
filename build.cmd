@echo off

echo Deleting old files ...
rmdir /s /q docs
del api\*.yml

echo Building new files ...
docfx docfx.json --disableGitFeatures %*
