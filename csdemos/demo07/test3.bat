call clear

csc -t:library furnitures.cs -out:furnitures.dll

csc -t:library data.cs -out:data.dll

csc Program2.cs -r:furnitures.dll,data.dll -out:fa01.exe

fa01

