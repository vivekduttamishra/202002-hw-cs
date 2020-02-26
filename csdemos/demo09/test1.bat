call clear

csc -t:library furnitures.cs -out:furnitures.dll

csc -t:library data.cs -out:data.dll

csc -t:library thirdparty.cs -out:tpl.dll

csc Program1.cs -r:furnitures.dll,data.dll,tpl.dll -out:fa01.exe

fa01

