# MovieLib
A desktop app representing a movie repository/library.

## Technologies
- WPF(.NET 6)
- MySQL

## Project Description
Main goal of this project is to implement ***WPF*** application where users have different roles, possibility of changing themes and language(localization),
as well as storing and fetching data from ***MySQL*** database (using purely ***ADO.NET***).

This app is implemented by using ***MVVM architectural pattern***. It has several different types of commands(implementations of ICommand interface), where some of them are
used for navigating, asynchronious database calls, etc.

There is 2 different user roles in this app: ***user*** and ***administrator***.
Users can filter and see all the information about movies, save them in their playlist or leave a review, while administrators can add or remove movies, 
as well as blocking user accounts. In database, movie deletion is implemented with soft-delete pattern.

## Demo
<img src="/MovieLib/Resources/Images/Filmovi(korisnik).png"  width="600"> 
<img src="/MovieLib/Resources/Images/Film(korisnik)v2.png"  width="600">
<img src="/MovieLib/Resources/Images/MovielibScreen2.png" width="600">
