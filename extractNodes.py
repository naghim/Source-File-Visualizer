# walks through directories and extracts the AST nodes for each .cpp file
# and dumps them into a csv file

import os
import re
import pandas as pd
import sys

DIRSEPARATOR = '\\'
PRINT_HEADER = True

# returns the header for the csv file
def returnHeaders():
    vec = ['MAXDepth',
        '<<<NULL>>>',
        'AbiTagAttr',
        'AccessSpecDecl',
        'ArraySubscriptExpr',
        'BinaryOperator',
        'CStyleCastExpr',
        'CXXBoolLiteralExpr',
        'CXXConstructExpr',
        'CXXConstructorDecl',
        'CXXConversionDecl',
        'CXXCtorInitializer',
        'CXXDependentScopeMemberExpr',
        'CXXDestructorDecl',
        'CXXFunctionalCastExpr',
        'CXXMemberCallExpr',
        'CXXMethodDecl',
        'CXXOperatorCallExpr',
        'CXXRecordDecl',
        'CXXStaticCastExpr',
        'CXXTemporaryObjectExpr',
        'CXXThisExpr',
        'CXXUnresolvedConstructExpr',
        'CallExpr',
        'ClassTemplateSpecialization',
        'CompoundAssignOperator',
        'CompoundStmt',
        'ConditionalOperator',
        'ConstantExpr',
        'CopyAssignment',
        'CopyConstructor',
        'DeclRefExpr',
        'DeclStmt',
        'DefaultConstructor',
        'DefinitionData',
        'DependentNameType',
        'Destructor',
        'EnumConstantDecl',
        'ExprWithCleanups',
        'FieldDecl',
        'ForStmt',
        'FormatAttr',
        'FriendDecl',
        'FunctionDecl',
        'FunctionTemplateDecl',
        'ImplicitCastExpr',
        'IntegerLiteral',
        'MaterializeTemporaryExpr',
        'MemberExpr',
        'MoveAssignment',
        'MoveConstructor',
        'NoThrowAttr',
        'NullStmt',
        'public',
        'ParenExpr',
        'ParenListExpr',
        'ParmVarDecl',
        'PureAttr',
        'ReturnStmt',
        'StringLiteral',
        'TemplateArgument',
        'TemplateSpecializationType',
        'TemplateTypeParmDecl',
        'TypedefDecl',
        'UnaryOperator',
        'UnresolvedLookupExpr',
        'UsingDecl',
        'UsingShadowDecl',
        'WhileStmt']

    return vec

# returns the node-dictionary
def returnNodeDictionary():
    obj = {
        # 'VarDecl': 0,
        'MAXDepth': 1,
        '<<<NULL>>>': 0,
        'AbiTagAttr': 0,
        'AccessSpecDecl': 0,
        'ArraySubscriptExpr': 0,
        'BinaryOperator': 0,
        'CStyleCastExpr': 0,
        'CXXBoolLiteralExpr': 0,
        'CXXConstructExpr': 0,
        'CXXConstructorDecl': 0,
        'CXXConversionDecl': 0,
        'CXXCtorInitializer': 0,
        'CXXDependentScopeMemberExpr': 0,
        'CXXDestructorDecl': 0,
        'CXXFunctionalCastExpr': 0,
        'CXXMemberCallExpr': 0,
        'CXXMethodDecl': 0,
        'CXXOperatorCallExpr': 0,
        'CXXRecordDecl': 0,
        'CXXStaticCastExpr': 0,
        'CXXTemporaryObjectExpr': 0,
        'CXXThisExpr': 0,
        'CXXUnresolvedConstructExpr': 0,
        'CallExpr': 0,
        'ClassTemplateSpecialization': 0,
        'CompoundAssignOperator': 0,
        'CompoundStmt': 0,
        'ConditionalOperator': 0,
        'ConstantExpr': 0,
        'CopyAssignment': 0,
        'CopyConstructor': 0,
        'DeclRefExpr': 0,
        'DeclStmt': 0,
        'DefaultConstructor': 0,
        'DefinitionData': 0,
        'DependentNameType': 0,
        'Destructor': 0,
        'EnumConstantDecl': 0,
        'ExprWithCleanups': 0,
        'FieldDecl': 0,
        'ForStmt': 0,
        'FormatAttr': 0,
        'FriendDecl': 0,
        'FunctionDecl': 0,
        'FunctionTemplateDecl': 0,
        'ImplicitCastExpr': 0,
        'IntegerLiteral': 0,
        'MaterializeTemporaryExpr': 0,
        'MemberExpr': 0,
        'MoveAssignment': 0,
        'MoveConstructor': 0,
        'NoThrowAttr': 0,
        'NullStmt': 0,
        'public': 0,
        'ParenExpr': 0,
        'ParenListExpr': 0,
        'ParmVarDecl': 0,
        'PureAttr': 0,
        'ReturnStmt': 0,
        'StringLiteral': 0,
        'TemplateArgument': 0,
        'TemplateSpecializationType': 0,
        'TemplateTypeParmDecl': 0,
        'TypedefDecl': 0,
        'UnaryOperator': 0,
        'UnresolvedLookupExpr': 0,
        'UsingDecl': 0,
        'UsingShadowDecl': 0,
        'WhileStmt': 0,

    }

    return obj

# extracts the nodes
def extract_features(filepath):
    astNodes = returnNodeDictionary()
    beforeNodes = re.compile(r'.*\x1b\[0;1;3.([a-zA-Z0-9]*)')
    line_count = 1
    first = True

    nodeDepthSpace = re.compile(r' +\|? +')
    with open(filepath, 'r', encoding='ascii', errors='ignore') as file:
        line = file.readline()
        while line:
            try:
                if not first:
                    if astNodes['MAXDepth'] == 1:
                        None
                    else:
                        astNodes['MAXDepth'] = int(astNodes['MAXDepth']/2)
                first = False
            except:
                None

            if re.match(beforeNodes, line) != None:
                result = re.search(nodeDepthSpace, line)
                if result:
                    resultLength = len(result.group(0))
                    if astNodes['MAXDepth'] < resultLength:
                        astNodes['MAXDepth'] = resultLength
                for node in astNodes:
                    if re.match(".*" + node + ".*", line) != None:
                        astNodes[node] += 1

            # next line initialization
            line = file.readline()
            line_count += 1
        """"""""""""""""""""" end of loop """""""""""""""""""""
        if astNodes['MAXDepth'] == 1:
            None
        else:
            astNodes['MAXDepth'] = int(astNodes['MAXDepth'] / 2);

        dumpDictionaryToCSV(astNodes)


# dumps a dictionary to a CSV file
def dumpDictionaryToCSV(data):
    index_counter = 1
    global PRINT_HEADER
    csv_file = "test_data" + ".csv"
    df=pd.DataFrame(data,index=[index_counter])
    if PRINT_HEADER:
        csv_columns = returnHeaders()
        df.to_csv(csv_file, mode = 'w', header=csv_columns, index = False) #with headers
        PRINT_HEADER = False
    else:
        df.to_csv(csv_file, mode = 'a', header = False, index = False) #append mode without headers


# walks through the directories
def start(path):
    global DIRSEPARATOR
    patternUser = re.compile(r'.+\\user[0-9]+$')

    list_of_files = {}

    for (dirpath, dirnames, filenames) in os.walk(path):
        if(re.match(patternUser, dirpath) != None):
            list_of_files = {}

        for filename in filenames:
            if filename.endswith('.ast'):
                list_of_files[filename] = os.sep.join([dirpath, filename])
                extract_features(dirpath + DIRSEPARATOR + filename)


# main function to start feature extracting
def main(path, opsys):
    global DIRSEPARATOR
    DIRSEPARATOR = '\\' #defaults to Windows
    if opsys == 'LINUX' or opsys == 'MACOS':
        DIRSEPARATOR = '/'
    start(path)


# -------------------------------------- MAIN -------------------------------------- #
main('<<PATH-TO-DIR>>', 'WINDOWS')