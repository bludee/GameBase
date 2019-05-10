import os,re,sys

if sys.getdefaultencoding() != 'gbk':
	reload(sys)
sys.setdefaultencoding('gbk')

import codecs, xlrd #http://pypi.python.org/pypi/xlrd
from optparse import OptionParser



parser = OptionParser(usage="%prog [optinos] -e excelfile -j jsonPath")  
parser.add_option("-e", "--excelfile", action = "store", type = 'string', dest = "excelfile", default = None,  
				help="The Excel file you want to process")
parser.add_option("--headignore", action = "store", type = 'int', dest = "headignore", default = 3,  
				help="The table head rows in Excel table")
parser.add_option("-j", "--jsonPath", action = "store", type = 'string', dest = "jsonPath", default = None,  
				help="The Output Path you want store Json File")
(options, args) = parser.parse_args()  

excelFileName = options.excelfile
jsonPath = options.jsonPath
headIgnore = options.headignore

def FloatToString (aFloat):
	if type(aFloat) != float:
		return ""
	strTemp = str(aFloat)
	strList = strTemp.split(".")
	if len(strList) == 1 :
		return strTemp
	else:
		if strList[1] == "0" :
			return strList[0]
		else:
			return strTemp
	
def TableTojson(table, jsonfilename, headIgnore):
	nrows = table.nrows
	ncols = table.ncols

	f = codecs.open(jsonfilename,"w","utf-8")
	
	f.write(u"[");
	for r in range(headIgnore - 1, nrows - 1):
		f.write(u"{\n")
		for c in range(0, ncols): 
		
			if table.cell_value(0,c) == "":
				continue
				
			if c > 0:
				strTmp = u",\n"
			else:
				strTmp = ""
			
			strCellValue = u""
			CellObj = table.cell_value(r + 1,c)

			if type(CellObj) == unicode:
					strCellValue =  CellObj
			elif type(CellObj) == float:
					strCellValue = FloatToString(CellObj)
					
			if "str" in table.cell_value(1,c).lower():
					strCellValue = "\"" + strCellValue + "\""
					
			if "float" in table.cell_value(1,c).lower():
					strCellValue = "\"" + strCellValue + "\""
			
			if ("int" in table.cell_value(1,c).lower()) and (strCellValue.strip() == ""):
					strCellValue = "0"
					
			if ("array" in table.cell_value(1,c).lower()) and (strCellValue.strip() == ""):
					strCellValue = "[]"
					
			#print strCellValue
			strTmp += u"\t\""  + table.cell_value(0,c) + u"\": "

			strTmp += strCellValue

			f.write(strTmp)
			
		f.write(u"\n}")
		if r < nrows-2:
			f.write(u",")

	f.write(u"]")
	f.close()
	print "Create ", jsonfilename, " OK"
	return
	
def GetSheet(workbook, jsonPath, headIgnore):
	for sheetName in workbook.sheet_names():
		if ".json" in sheetName:
			desttable = workbook.sheet_by_name(sheetName)
			jsonfilename = os.path.join(jsonPath, sheetName) 
			TableTojson(desttable, jsonfilename, headIgnore)
	sys.exit()


workbook = xlrd.open_workbook(excelFileName)
GetSheet(workbook, jsonPath, headIgnore)
