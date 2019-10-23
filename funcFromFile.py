#Egy C++ fajlbol egy azonos nevu .txt fajlba irja a forrasallomany fuggvenyneveit.
#Hasznalat: python funcFromFile.py /home/tunde/.../feladat.cpp feladat.cpp
#Hasznalat clang-check: /home/tunde/Downloads/clang+llvm-9.0.0-x86_64-linux-gnu-ubuntu-18.04/bin/clang-check -extra-arg=-std=c++1y -ast-dump -ast-dump-filter=main simple.cpp
#Clang source: http://releases.llvm.org/download.html#9.0.0


import sys
import re
import os
import fileinput
import mmap

def function_to_file(words,f):
    for i in words:       
    	f.write('%s\n'%i)

# searches functions in a line
def find_functions(line,f):
	#version: find operator overloading method's name (operator)
    found_functions=re.findall(r'^(?:\w+(?:\[\d+\]|<\w+>)?\s*[*&]?\s+)+(?:\w+::)?(\w+)\s*[(\[\])\+\=\-\*(<<)(\(\))]*\(',line)
    
    if found_functions:
        #write words of a function name into file
        function_to_file(found_functions,f)

def process_file(filepath,f):
	with open(filepath, 'r', encoding='utf-8', errors='ignore') as inf:
		line = inf.readline()
		while line:
			find_functions(line,f)
			line = inf.readline()

def check_operator(output):
	op_bool = 0
	operators = ['+','-','*','/','[]','()','<<','<','>','<=','>=','==','++']	
	with open(output,'r') as func_names:
                if 'operator' in func_names.read():
                    op_bool = 1
	if op_bool == 1:
		with open(output,'r') as f:	
			lines= f.readlines()
		with open(output,'w') as w:
			for line in lines:
				if line.strip("\n") != 'operator':
					w.write(line)
		for i in operators:
			with open(output,"a") as f:
				print("operator"+ i, file=f)



#get filepath, first argument
filepath = sys.argv[1]
#get filename second argument, remove extension
filename = os.path.splitext(sys.argv[2])[0]
#create output file
output = filename + '.txt'
#open output file
f = open(output,"w")
#process file line by line and get function names
process_file(filepath,f)
f.close()
#search operator overloading method names; if are
check_operator(output)

