SET svnPath=E:\svn\fishing
SET JsonDirFrom="%svnPath%\�߻�\trunk\json�ļ�"
SET JsonDirTo="%svnPath%\����\trunk\Fishing\Assets\Resources\Config"

echo %JsonDirFrom%
pause

cls
@echo off
echo ��������json�ļ������Ժ�
copy /y "%JsonDirFrom%" "%JsonDirTo%"

pause