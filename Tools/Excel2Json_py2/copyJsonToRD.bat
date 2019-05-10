SET svnPath=E:\svn\fishing
SET JsonDirFrom="%svnPath%\策划\trunk\json文件"
SET JsonDirTo="%svnPath%\程序\trunk\Fishing\Assets\Resources\Config"

echo %JsonDirFrom%
pause

cls
@echo off
echo 正在生成json文件，请稍后
copy /y "%JsonDirFrom%" "%JsonDirTo%"

pause