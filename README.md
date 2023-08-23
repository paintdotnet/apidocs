# Getting Started with ApiDocs
This is a readme for if you are working on these docs, and should not be included in the docs themselves.

How to build the docs and get into a nice edit/build loop:
1. Run `restore.cmd`. It will install `docfx`. You only need to do this once.
2. Make sure you have already built Paint.NET in Visual Studio.
3. Run `build_and_serve.cmd`. It will build the docs (might take a few minutes!) and will then host the website locally so you can view it.
4. Make your edits
5. Go back to the console window where you ran `build_and_serve.cmd` and press Ctrl+C to kill it, then press Y for the "terminate batch file?" question.
6. If you made changes in the Paint.NET code, like adding or editing doc comments, make sure you do another Build -> Build Solution over in Visual Studio. docfx looks at the DLLs that are already built, it does not compile the code.
7. Go back to step 3.

You can edit Markdown files (*.md) in Visual Studio Code, which has live preview. Here's my workflow:
1. Open Visual Studio Code
2. File -> Open Folder, point it to the ApiDocs folder
3. Open up a .md file (like README.md or index.md or whatever) by double-clicking on it
4. To open the preview tab, press Ctrl+Shift+V (or right click on the tab and then on Open Preview)
