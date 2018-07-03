**Dokumentace a příklady:** [zde ve wiki](https://github.com/Papouchcom/spinel.net/wiki)  
**Changelog** [najdete tady](https://github.com/Papouchcom/spinel.net/wiki).
# Spinel.NET
Balíček knihoven a ukázkových aplikací pro práci se zařízeními komunikujícími protokolem [Spinel](https://www.papouch.com/cz/website/mainmenu/spinel/). Spinel je univerzální otevřený komunikační protokol od [papouch.com](https://www.papouch.com). V současné době jsou implementována tato zařízení:  
* **I/O moduly Quido**: [dokumentace a příklady použití](https://github.com/Papouchcom/spinel.net/wiki/Dokumentace:-Quido), [odkaz na web papouch.com](https://www.papouch.com/cz/website/mainmenu/clanky/vyberte-si/io-pro-ethernet-usb-rs485-rs232/)  
* **Teploměry TQS3 a TQS4**: [dokumentace a příklady použití](https://github.com/Papouchcom/spinel.net/wiki/Dokumentace:-TQS), [odkaz na web papouch.com](https://www.papouch.com/cz/website/mainmenu/products/mereni/teplomery-vlhkomery/rs485-tqs/)  
* **Senzory THT2 a TH2E**: [dokumentace a příklady použití](https://github.com/Papouchcom/spinel.net/wiki/Dokumentace:-THT2,-TH2E), [THT2 na papouch.com](https://www.papouch.com/cz/shop/product/tht2-vlhkomer-teplomer-rs485/), [TH2E na papouch.com](https://www.papouch.com/cz/shop/product/th2e-ethernetovy-teplomer-s-vlhkomerem/)  

Knihovna umožňuje i komunikaci se zařízeními, které používají protokol Spinel, ale nejsou v knihovně implementovány (viz funkce [`SendAndReceive()`](https://github.com/Papouchcom/spinel.net/wiki/Spinel:-Ostatn%C3%AD-instrukce)).

Knihovna je určena pro platforu Microsoft .NET. Aktuální verze projektu je testována v [Microsoft Visual Studio Community 2017](https://www.visualstudio.com/cs/downloads/).  

Všechny části jsou napsané v jazyce C# a při použití využívají jen .NET Frameworku.  
Knihovny je možné zkompilovat jako samostatné .NET assembly (DLL) a použít je ve Vašem projektu, nebo je možné tyto knihovny přímo přikompilovat do Vaší aplikace (do výsledného EXE).

**[Podívejte se do Wiki](https://github.com/Papouchcom/spinel.net/wiki)** na kompletní dokumentaci knihovny včetně příkladů použití.

Co najdete ve složkách repozitáře:
-------------
**\Papouch.Communication**:  Knihovny pro komunikaci (nejnižší vrstva).  
**\Papouch.Spinel**: Knihovny protokolu Spinel (nadstavba pro Communication).  
**\Papouch.Utils**: Doplňkové funkce.  
**\Latest**: Zkompilované DLL, které můžete přímo [použít jako referenci](https://github.com/Papouchcom/spinel.net/wiki/Jak-do-projektu-p%C5%99idat-referenci-na-knihovny-spinel.net%3F) ve Vašem projektu (včetně PDB souborů).
  
**\QuidoDemo_CS.NET**: Příklad aplikace pro Quido v C#.  
**\QuidoDemo_VB.NET**: Příklad aplikce pro Quido ve VB.NET.  
**\CommunicationInterfaceDemo_CS.NET**: Samostatný příklad použití komunikačního rozhraní.  