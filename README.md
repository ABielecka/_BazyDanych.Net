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

<h2>Wstęp do aplikacji</h2>

Po uruchomieniu programu należy wybrać przycisk ```Login``` - po jego naciśnięciu zostaniemy przekierowani do aplikacji. 

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/Login.png)

W tym momencie występuje wielowątkowość programu, ponieważ po kliknięciu przycisku ```Login``` pojawia się drugie okienko, które symuluje ładowanie zawartości bazy do programu.

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/Loading.png)

Naciśnięcie przycisku ```Exit``` kończy działanie programu i zamyka okno.

<h3>Przegląd aplikacji</h3>
Po uruchomieniu aplikacji są widoczne zakładki, takie jak np. ```Osoby```, ```Nieruchomości```, ```Najem``` itd.

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/Nawigacja.png)

<h3>Dodawanie i edycja danych</h3>

Aby dodać osobę należy wejść w zakładkę ```Osoby```, następnie kliknąć przycisk ```Dodaj```. Po jego naciśnięciu (jak na zdjęciu poniżej), pojawi się formularz do wypełnienia danych o nowej osobie:

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/OsobaAdd.png)

Jako że ```Data urodzenia``` nie jest wymagana, nie jest podświetlana jak informacje obowiązkowe. Po wpisaniu niezbędnych danych, zatwierdzamy informacje przyciskiem ```Zapisz```.

Aby usunąć osobę należy: 

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/OsobaDelete.png)

Aby modyfikować dane o osobie należy:

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/OsobaEdit.png)

Analogicznie 
Należy zastosować analogicznie powyższe procedury przy dodawaniu, edytowaniu i usuwaniu nieruchomości, wyposażenia oraz typu nieruchomości, województw.

Aplikacja posiada zadeklarowany słownik województw, tzn. zamiast wpisywać województwo przy wypełnianiu formularza ```Osoby``` lub ```Nieruchomości```, istnieje możliwość wyboru województwa. Analogiczne działanie zostało zastosowane również dla ```Wyposażenie``` i ```Typ nieruchomosci```.

Dostępna jest również lista osób, które mogą są właścicielami nieruchomości lub mogą nieruchomość nająć i typ wynajmu (na pokoje lub pełny metraż) w celu ułatwienia wprowadzania danych już zapisanych użytkowników i uniknięcia pomyłek.

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/Województwa.png)

<h3>Nieruchomość i jej składowe</h3>

W zakładce ```Nieruchomości``` oprócz możliwych miejsc, można jeszcze dodać do nich wyposażenie 

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/NieruchomoscWyp.png)

lub podzielić na pokoje

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/NieruchomoscPok.png)

Dodawanie/edycja/usuwanie wyposażenia lub pokoju (i wyposażenia dla pokoju) odbywa się zgodnie z procedurą opisaną wyżej na przykładzie zarządzania danymi osób w zakładce ```Osoby```. Wyposażenie wybierane jest z listy dostępnych, wcześniej wprowadzonych wyposażeń w zakładce ```Wyposazenie``` w ```Slowniki```.

Aby zobaczyć adres nieruchomości na mapie, można skorzystać z przycisku ```Mapa```

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/Mapa.png)

Po naciśnięciu przycisku zostanie wyświetlone okno, które przedstawi adres nieruchomości na mapie Google Maps.

Jeżeli osoba korzystająca z aplikacji jest zainteresowana obiektami znajdującymi się w okolicy może skorzystać z przycisku ```POI``` (Points of Interest) znajdującego się zaraz obok przycisku ```Mapa```.

W pierwszej kolejności użytkownik musi wybrać obiekty, które go interesują (np. bankomaty, restauracje, uczelnie) (1) i zatwierdzić swoją decyzję przyciskiem ```Szukaj``` (2). Po przyciśnięciu ```Mapa``` przy zaznaczonym obiekcie (3) obok adresu POI wyświetli się dystans i czas podróży od adresu nieruchomości do POI (4). Po prawej stronie wyświetli się również mapa Google Maps z nakreśloną drogą między dwoma punktami.

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/POI.png)

<h3>Najem</h3>

Oprócz podstawowych funkcji dodawania, edycji i usuwania, nieruchomości (i pokoje) można również wynająć przy pomocy przycisku ```Wynajmij```

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/Najmij.png)

Po wynajęciu nieruchomości (lub pokoju) jej status zmienia się na "zajęty" - checkbox zostaje zaznaczony i niemożliwe jest ponowne wynajęcie nieruchomości (lub pokoju) do czasu zwolnienia przez poprzedniego najemcę

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/Status.png)

W zakładce ```Najem``` istnieje możliwość edycji oraz usuwania danego najmu. Aby edytować najem należy wejść w zakładkę ```Najem```, następnie kliknąć przycisk:

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/WynajmijEdit.png)

W przypadku edycji najmu nie jest możliwa zmiana indentyfikatora i osoby najmującej.

Aby usunąć najem i jednocześnie zwolnić nieruchomośc/pokój, należy kliknąć przycisk:

![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/UsunWynajem.png)

Po wyprowadzeniu wszystkich pożądanych zmian, aby zamknąc aplikację należy wcisnąć ```X``` w górnej części okna. 
