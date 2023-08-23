@rem NOTE: Updating this batch file will NOT affect how the ApiDocs are built by MakePackages!
@rem       See ./MakePackage/ApiDocs/ApiDocsPackageBuilder.cs
rmdir /s /q docs
docfx docfx.json --disableGitFeatures %*
