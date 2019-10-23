import sys
import csv

# verifies if a .cpp file has an .ast and creates a list for the union() function
#       if the ast exists => 'yes'
#       if the ast doesn't exist => '*'
def union():
    sys.stdout = open('summary.txt', mode='w', buffering=1)
    with open('cppNodeList.txt', 'r', encoding='ascii', errors='ignore') as f:
        line = f.readline()
        cppHasAst = False
        while line:
            with open('astNodeList.txt', 'r', encoding='ascii', errors='ignore') as f2:
                line2 = f2.readline()
                while line2:
                    if line.split('.')[-2] == line2.split('.')[-2]:
                        print('yes')
                        cppHasAst = True
                        break
                    line2 = f2.readline()
                if cppHasAst == False:
                    print("*")
            cppHasAst = False
            line = f.readline()


# transforms the dumped ast features into another csv file
# so it can be united with the other features
# it is necessary because not every .cpp has an .ast file
def dump():

    reader = csv.reader(open('ASTnodes.csv', 'r'))
    writer = csv.writer(open('appended_output.csv', 'wt', newline=''))
    with open('summary.txt', 'r', encoding='ascii', errors='ignore') as f:
        line = f.readline()
        while line:
            if line == 'yes\n': 
                row = next(reader)
                writer.writerow(row)
                print(row)
            else:
                writer.writerow('\n')

            line = f.readline()


# -------------------------------------- MAIN -------------------------------------- #
# step 1: union - make the list for the union
# step 2: dump - dump the data into a csv file

# union()
dump()