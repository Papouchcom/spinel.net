# Quido.NET
Balíček knihoven a ukázkových aplikací pro práci s [I/O moduly Papouch Quido](https://www.papouch.com/cz/website/mainmenu/clanky/vyberte-si/io-pro-ethernet-usb-rs485-rs232/) na platformě Microsoft .NET.  
Aktuální verze všech .NET projektů je kompatibilní s Microsoft Visual Studio 2015 Professional.

Obsah složek:
-------------
**\Papouch.Communication**:  Knihovny pro komunikaci (nejnižší vrstva).  
**\Papouch.Spinel**: Knihovny protokolu Spinel (nadstavba pro Communication).  
**\Papouch.Utils**: Doplňkové funkce.  
**\Latest**: Zkompilované DLL, které můžete přímo [použít jako referenci](https://github.com/Papouchcom/quido.net/wiki#jak-do-projektu-p%C5%99idat-referenci-na-knihovny-quidonet) ve Vašem projektu (včetně PDB souborů).
  
**\QuidoDemo_CS.NET**: Příklad aplikace v C#.  
**\QuidoDemo_VB.NET**: Příklad aplikce ve VB.NET.  
**\CommunicationInterfaceDemo_CS.NET**: Samostatný příklad použití komunikačního rozhraní.  
  
Všechny části jsou napsané v jazyku C# a při použití využívají jen .NET Frameworku.  
Knihovny je možné zkompilovat jako samostatné .NET assembly (DLL) a použít je ve Vašem projektu, nebo je možné tyto knihovny přímo přikompilovat do Vaší aplikace (do výsledného EXE).
