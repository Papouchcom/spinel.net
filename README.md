# quido.net
Balíček knihoven a ukázkových aplikací pro práci s [I/O moduly Papouch Quido](https://www.papouch.com/cz/website/mainmenu/clanky/vyberte-si/io-pro-ethernet-usb-rs485-rs232/) na platformě Microsoft .NET.  
Aktuální verze všech .NET projektů je kompatibilní s Microsoft Visual Studio 2015 Professional.

Obsah složek:
-------------
\\.NET assembly  
\\.NET assembly\CommunicationInterfaceDemo_CS.NET  
\\.NET assembly\Papouch.Communication  
\\.NET assembly\Papouch.Spinel  
\\.NET assembly\Papouch.Utils  
\\.NET assembly\QuidoDemo_CS.NET  
\\.NET assembly\QuidoDemo_VB.NET  
  
Složka obsahuje knihovny a ukázkový projekt pro moduly Quido v čistém C# (+ kopie ukázkové aplikace ve VB.NET).  
Všechny části jsou napsané v jazyku C# a při použití využívají jen .NET Frameworku.  
Složka obsahuje knihovny pro komunikaci ("\Papouch.Communication"), protokol Spinel ("\Papouch.Spinel") a doplňkové funkce ("\Papouch.Utils"). Tyto knihovny je možné zkompilovat jako samostatné .NET assembly (DLL) a použít je ve Vašem projektu, nebo je možné tyto knihovny přímo přikompilovat do Vaší aplikace (do výsledného EXE).
