SET svnPath="D:\SVN\fishing"
SET Script="%svnPath%\�߻�\tags\ת������\exceltojson.py"
SET ExcelDir="%svnPath%\�߻�\trunk\���ñ�"
SET JsonDir="%svnPath%\�߻�\trunk\json�ļ�"

cls
@echo off
echo ��������json�ļ������Ժ�

python %Script% -e %ExcelDir%\fish-��.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\bait-���.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\gameconfig_ȫ�ֱ�����.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\crew-��Ա.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\enhance-��ǿ��.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\port-�ۿ�.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\quest-����.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\sea-���򳡾�.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\QTE-���QTE.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\ship-��.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\music-��Ч.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\crew-��Ա.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\CN-ϵͳ����.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\shipyard-�촬��.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\fishingGear-����̵�.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\music-��Ч.xlsx -j %JsonDir%

pause