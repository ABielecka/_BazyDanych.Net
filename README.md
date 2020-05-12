# _NetJava-ProjectWPF
Projekt .Net - Gerlach Alicja, Bielecka Anna

Aplikacja wspomaga najem nieruchomości.

Aby uruchomić program należy otworzyć projekt 'Database.sln'. Należy mieć pobraną bazę danych, najlepiej Oracle Database 18 Express Edition. Przy pierwszym uruchomieniu programu należy odkomentować drugą linię w pliku DataBaseW/Models/Context.cs:
![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/firstUncomment.PNG)

Przy kolejnych uruchomieniach programu należy zostawić odkomentowaną tylko jedną linię:
![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/secondUncomment.PNG)

Następnie należy zmienić wartość 'HOST', 'User Id' oraz 'Password' zgodnie z lokalnymi danymi bazy (w pliku DatabaseW/App.xaml.cs):
![alt text](https://github.com/ABielecka/_NetJava-ProjectWPF/blob/master/screenshots/changeConString.PNG)

Po uruchomieniu programu należy kliknąć przycisk 'Login' - zostaniemy przekierowani do aplikacji. Między innymi w tym momencie występuje wielowątkowość programu, ponieważ po kliknięciu przycisku 'Login' pojawia się drugie okienko, które symuluje ładowanie plików i bazy do programu.
