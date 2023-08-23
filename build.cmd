@echo off

echo Deleting old files ...
rmdir /s /q docs

echo Building new files ...
docfx docfx.json --disableGitFeatures %*
