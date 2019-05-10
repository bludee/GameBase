SET svnPath="D:\SVN\fishing"
SET Script="%svnPath%\策划\tags\转换工具\exceltojson.py"
SET ExcelDir="%svnPath%\策划\trunk\配置表"
SET JsonDir="%svnPath%\策划\trunk\json文件"

cls
@echo off
echo 正在生成json文件，请稍后

python %Script% -e %ExcelDir%\fish-鱼.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\bait-鱼饵.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\gameconfig_全局变量表.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\crew-船员.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\enhance-船强化.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\port-港口.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\quest-任务.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\sea-海域场景.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\QTE-鱼的QTE.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\ship-船.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\music-音效.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\crew-船员.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\CN-系统文字.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\shipyard-造船厂.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\fishingGear-渔具商店.xlsx -j %JsonDir%

python %Script% -e %ExcelDir%\music-音效.xlsx -j %JsonDir%

pause