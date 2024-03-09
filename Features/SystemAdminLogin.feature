# language: pl

Właściwość: Logowanie administratora do systemu
  Jako administrator systemu
  Chcę się zalogować do panelu administracyjnego
  Aby zarządzać systemem


@smoke
Scenariusz: Poprawne zalogowanie do systemu jako administrator
    Zakładając, że otwieram stronę logowania do panelu administracyjnego
    Kiedy wybieram opcję Zaloguj
    I widzę formularz do logowania
    I wpisuję email administratora
    I wpisuję hasło administratora
    I zatwierdzam formularz logowania
    Wtedy jestem zalogowany do systemu jako administrator
   



