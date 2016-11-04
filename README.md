# 2016-Sep-DMIT-2018-In-Class-A02

## Gotcha's

If I'm missing roslyn/cs.exe when I run it (CTRL + F5), then

* Open **Tools>NuGet Package Manager>Package Manager Console...**
* Type `update-package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`
* If you are still having problems, also type the following in the Package Manager Console:
  * `update-package -reinstall`
