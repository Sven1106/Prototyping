:: this script needs https://www.nuget.org/packages/ilmerge

:: set your target executable name (typically [projectname].exe)
SET APP_NAME=Trekteg.exe

:: Set build, used for directory. Typically Release or Debug
SET ILMERGE_BUILD=Debug


:: set your NuGet ILMerge Version, this is the number from the package manager install, for example:
:: PM> Install-Package ilmerge -Version 3.0.29
:: to confirm it is installed for a given project, see the packages.config file
SET ILMERGE_VERSION=3.0.41

:: the full ILMerge should be found here:
SET ILMERGE_PATH=%USERPROFILE%\.nuget\packages\ilmerge\%ILMERGE_VERSION%\tools\net452\ILMerge.exe

:: add project DLL's starting with replacing the FirstLib with this project's DLL
%ILMERGE_PATH% bin\%ILMERGE_BUILD%\%APP_NAME% ^
  /lib:bin\%ILMERGE_BUILD%\ ^
	  AutoHotkey.Interop.dll ^
  /out:%APP_NAME% 
:Done
pause