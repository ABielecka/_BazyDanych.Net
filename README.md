# _NetJava-ProjectWPF
Projekt .Net - Gerlach Alicja, Bielecka Anna

<h1>Aplikacja wspomagająca najem nieruchomości</h1>

<h2>Pierwsze uruchomienie programu</h2>

Aby uruchomić program należy otworzyć projekt ```Database.sln```. Należy mieć pobraną bazę danych, najlepiej ```Oracle Database 18 Express Edition```. Przy pierwszym uruchomieniu programu należy odkomentować drugą linię w pliku ```DataBaseW/Models/Context.cs```:
![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/firstUncomment.PNG)

Przy kolejnych uruchomieniach programu należy zostawić odkomentowaną tylko jedną linię:
![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/secondUncomment.PNG)

Następnie należy zmienić wartość ```HOST```, ```User Id``` oraz ```Password``` zgodnie z lokalnymi danymi bazy (w pliku ```DatabaseW/App.xaml.cs```):
![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/changeConString.PNG)

<h2>Przegląd aplikacji</h2>

Po uruchomieniu programu należy kliknąć przycisk ```Login``` - zostaniemy przekierowani do aplikacji. Między innymi w tym momencie występuje wielowątkowość programu, ponieważ po kliknięciu przycisku ```Login``` pojawia się drugie okienko, które symuluje ładowanie plików i bazy do programu.

Po uruchomieniu aplikacji są widoczne zakładki, takie jak np. ```Osoby```, ```Nieruchomości```, ```Najem``` itd.

<h3>Dodawanie osoby, nieruchomości...</h3>

Aby dodać osobę należy wejść w zakładkę ```Osoby```, następnie kliknąć przycisk:
```diff
- TUTAJ WSTAW SCREENA Z PRZYCISKIEM 'DODAJ' W OSOBACH
```
Po kliknięciu przycisku ```Dodaj``` (jak na zdjęciu powyżej), pojawi się formularz do wypełnienia danych o dodawanej osobie:
```diff
- TUTAJ WSTAW SCREENA Z TYM FORMULARZEM DO WYPELNIENIA DANYCH
```
Po wpisaniu niezbędnych danych, zatwierdzamy informacje przyciskiem ```Zapisz```.

Aby usunąć osobę należy wejść w zakładkę ```Osoby```, następnie kliknąć przycisk: 
```diff
- TUTAJ WSTAW SCREENA Z PRZYCISKIEM 'USUŃ' W OSOBACH
```
Aby modyfikować dane o osobie należy wejść w zakładkę ```Osoby```, następnie kliknąć przycisk:
```diff
- TUTAJ WSTAW SCREENA Z PRZYCISKIEM 'EDYTUJ' W OSOBACH
```
Należy zastosować analogicznie powyższe procedury przy dodawaniu, edytowaniu i usuwaniu nieruchomości, wyposażenia oraz typu nieruchomości.

Aplikacja posiada zadeklarowany na stałe słownik województw, tzn. zamiast wpisywać województwo przy wypełnianiu formularza ```Osoby``` lub ```Nieruchomości```, istnieje możliwość wyboru województwa.

<h3>Najem</h3>

W zakładce ```Najem``` istnieje możliwość edycji oraz usuwania danego najmu.
Aby edytować najem należy wejść w zakładkę ```Najem```, następnie kliknąć przycisk:
```diff
- TUTAJ WSTAW SCREENA Z PRZYCISKIEM 'EDYTUJ' W NAjmie
```
W edycji najmu mamy możliwość zmiany następujących pól:
```diff
- TUTAJ WSTAW SCREENA Z formularzem edycji najmu
```
Aby usunąć najem należy wejść w zakładkę ```Najem```, następnie kliknąć przycisk:
```diff
- TUTAJ WSTAW SCREENA Z PRZYCISKIEM 'USUŃ' W NAjmie
```
