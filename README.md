# SourceFileAnalyzer
### About
Nowadays more and more people are seeking to apply, develop and add to their skills the computer science field. 
Consequently, a need has risen to write clean, efficient, well documented and readable code. The purpose of this research is
to measure programming style from source code. By doing so, it not only may be an effective tool for companies to filter people
by their competence, but also could be a great tool for students hoping to improve their abilities. This research is intended 
to focus on the semantical aspects of the source code, using abstract syntax trees and deep learning in order to achieve 
the desired results mentioned above. 

Source Code Authorship Attribution by extracting layout, lexical and syntactical features and classifying them.

### Main steps
- Layout and Lexical feature extraction with Python code
- AST extraction with Clang compiler and output processing (done using Linux OS)
- Classification with Python frameworks

## Dataset
Our dataset contains 9 C/C++ source file/100 user from the Google Code Jam 2015 programming competition [(GCJ_Dataset/Data)](https://github.com/kotunde/SourFileAnalyzer_featureSearch_and_classification/tree/master/GCJ_Dataset/Data), and an average 27 C++ source file/14 user from Sapientia EMTE University [(Sapi_Dataset/Data)](https://github.com/kotunde/SourFileAnalyzer_featureSearch_and_classification/tree/master/Sapi_Dataset/Data).

The main difference between the datasets is that the GCJ users were only given the task to solve, while Sapi users were given the header files too to work with. So the results are more remarkable at the GCJ dataset, since the Sapi codes were similar in structure.

## How it works

### Prerequisites
Install Python 3.x
```
$ sudo apt install python3.7
```
#### Set up Clang compiler
The following link may help with it ( [Setting up Clang](https://eli.thegreenplace.net/2011/07/03/parsing-c-in-python-with-clang#documentation) ).

//TODO
{...}

### Running
#### Layout and Lexical features
Run the first script to extract layout and lexical features into a CSV file: [extractAttributes.py](https://github.com/kotunde/SourceFileAnalyzer_featureSearch_and_classification/blob/master/Programs/LL_features/extractAttributes.py).

Don't forget to set the directory path.
```
$ python extractAttributes.py
```
Now we have the layout and lexical feautres in LL_features.csv file, where each column is a feature, except the last, which is the "author", the class itself. Our results: [GCJ L&L Features CSV](https://github.com/kotunde/SourceFileAnalyzer_featureSearch_and_classification/blob/master/GCJ_Dataset/CSV/GCJ_47.csv),  [Sapi L&L Features CSV](https://github.com/kotunde/SourceFileAnalyzer_featureSearch_and_classification/blob/master/Sapi_Dataset/CSV/SAPI_47.csv)

#### Abstract Syntax Trees
We have a bash script which is written for both of the datasets, since they differ in their directory structure ([gcj_data_ast_func.sh](https://github.com/kotunde/SourceFileAnalyzer_featureSearch_and_classification/blob/master/Programs/AST_extraction/gcj_data_ast_func.sh) , [sapi_data_ast_func.sh](https://github.com/kotunde/SourceFileAnalyzer_featureSearch_and_classification/blob/master/Programs/AST_extraction/sapi_data_ast_func.sh)). The script traverses the data directory (given as first parameter) by source files, and creates a second direcory (it's name given as second parameter) with the same directory structure, containing the .ast files with the same name as the respective source file.

**Important!**
In [createAstByFuncName.py](https://github.com/kotunde/SourceFileAnalyzer_featureSearch_and_classification/blob/master/Programs/AST_extraction/createAstByFuncName.py) set the path to installed ```clang-check```
```
$ bash gcj_data_ast_func.sh Data Data_ast
```
or
```
$ bash sapi_data_ast_func.sh Data Data_ast
```
The script creates the ASTs by first extracting the function names from each sourcefile, then creating the AST for each function.

#### Classification
Run Python script to classify the result CSVs with Random Forest Classifier([rfc.py](https://github.com/kotunde/SourceFileAnalyzer_featureSearch_and_classification/blob/master/Programs/Classification/rfc.py)).
Don't forget to set the directory path to the respective CSV file and format the output CSV's header.
```
$ python rfc.py
```
#### Illustration
To illustrate the output CSVs you can use the ```matplotlib.pyplot``` framework.
