@rem NOTE: Updating this batch file will NOT affect how the ApiDocs are built by MakePackages!
@rem       See ./MakePackage/ApiDocs/ApiDocsPackageBuilder.cs
docfx docfx.json --disableGitFeatures %*
