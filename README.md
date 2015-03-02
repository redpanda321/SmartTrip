# SmartTrip
Asp.net Vnext Demo (MVC6 Entity 7)

1. install Visual Studio 2015 CTP6
2. open CMD.exe
3. @powershell -NoProfile -ExecutionPolicy unrestricted -Command "iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/master/kvminstall.ps1'))"
4. cd SmartTrip/src/SmartTrip
5. kpm restore
6. k ef migration add initial
7. k ef apply
8. run !
