# SmartTrip
Asp.net Vnext Demo (MVC6 Entity 7)

http://www.calgaryer.com/

How to run:

1. install Visual Studio 2015 RC (windows 7)
2. open CMD.exe
3. @powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"
4. cd SmartTrip/src/SmartTrip
5. dnu restore
6. dnx . ef migration add initial
7. dnx . ef migration apply
8. dnx . web

Contact me:

    
12070132@qq.com
    
 
