#Hasznalat: 
#python createFuncAst.py forrasallomanyt/tartalmazo/fajl/utvonala fuggvenyneveket/tartalmazo/fajl/utvonala
#python createFuncAst.py /home/tunde/Linux/Documents/Projekt/Part_I/Sajat_kodok/Analyzer_06_10/Data/user14/labor7/feladat1/Polynomial.cpp /home/tunde/Linux/Documents/Projekt/Part_II/Clang/Ast_kinyeres_fuggvenyre/Polynomial.txt

#link(hogyan generaljunk ast-t nem mukodo forraskodra):
#https://eli.thegreenplace.net/2014/05/21/compilation-databases-for-clang-based-tools

import os
import sys
from pathlib import Path


def createAst(funcName,fileName,output):
	command = "/home/tunde/Downloads/clang+llvm-9.0.0-x86_64-linux-gnu-ubuntu-18.04/bin/clang-check -extra-arg=-std=c++1y -ast-dump -ast-dump-filter="+funcName+" "+ fileName + " -- >> " + output
	print('Command:',command,'\n')
	os.system(command)
	#with open('temp.txt','r') as ast:
	#	if 'error' not in ast.read():
	#		command = "cat temp.txt >>"+ output
	#		os.system(command)
	#os.system("rm temp.txt")
	

#get filepath, first argument
filepath = sys.argv[1]
#get filepath with function names,second argument
funcpath = Path(filepath).stem+'.txt'
#create output file
output = Path(filepath).stem+'.ast'

with open(funcpath,'r') as f:	
	lines= f.readlines()
for line in lines:
	line = line.strip("\n")
	createAst(line,filepath,output)
