#!/bin/bash

#parameterek ellenorzese
if (($#<2)); then
	echo Hasznalat: data_ast_func.sh data_konyvtar cel_konyvtar
	exit 1
fi

#parameterek atvetele
data="$1"
cel="$2"
original_loc=$(pwd)
echo PWD: $original_loc

#teszteljük a könyvtárakat
if ! [ -d "$data" ]
then
	echo "$data" könyvtár nem létezik
	exit 1
fi
chmod -R 774 $data

#ha a célkönyvtár nem létezik létrehozzuk
if ! [ -d "$cel" ]
then
	if ! mkdir "$cel" 2>/dev/null
	then
		echo nem lehet létrehozni a cél könyvtárat
		exit 1
	else
		#ki is írjuk ha sikerült
		echo "$cel" új könyvtár
		chmod -fR 774 $cel
	fi
fi

#ellenőrizzük, hogy a célkönytárban tudunk e létrehozni
#fájlokat, van-e w jogunk
if ! [ -w "$cel" ]
then
	echo a "$cel" -ben nem lehet fájlokat létrehozni
	exit 1
fi

#végigjárjuk az adathalmazt user-enkent
for user in $(ls "$data")
do
	if ! mkdir "$cel/$user" 2>/dev/null
	then
		echo nem lehet létrehozni a user könyvtárát
		exit 1
	fi
	chmod 774 $cel/$user
	#bejarjuk user-eket laboronkent 
	for labor in $(ls "$data/$user")
	do
		if ! mkdir "$cel/$user/$labor" 2>/dev/null
		then
			echo nem lehet létrehozni a "$cel/$user/$labor" labor könyvtárat
			exit 1
		fi
		chmod 774 $cel/$user/$labor
		#bejarjuk a laborokat feladatonkent
		for feladat in $(ls "$data/$user/$labor")
		do
			if ! mkdir "$cel/$user/$labor/$feladat" 2>/dev/null
			then
				echo nem lehet létrehozni a "$cel/$user/$labor/$feladat" könyvtárat
				exit 1
			fi
			chmod 774 $cel/$user/$labor/$feladat
			echo $pwd
			#bejarjuk a feladatokat .cpp allomanyonkent
			for allomany in $(ls $data/$user/$labor/$feladat |  egrep "*.cpp")
			do
				cd "./$cel/$user/$labor/$feladat"
				echo python "${original_loc}/funcFromFile.py"  "$allomany"
				python "${original_loc}/funcFromFile.py" "$original_loc/$data/$user/$labor/$feladat/$allomany" $allomany
				python "${original_loc}/createFuncAst.py" "$original_loc/$data/$user/$labor/$feladat/$allomany" 
				cd "$original_loc"
			done
			
		done
	done
done
		
