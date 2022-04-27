# How does Anki/Quizlet work?
I'll explain how the actual programs work here, so if you know, you can skip this heading. So here is how it works. Basically, there are group of decks, you name them, you create them customly. Let it be a language learning deck or for your medicine school lessons. This program exists to help you to memorize/learn the stuff by immersion.

In deck groups there are group of cards. To get this more clear, here is an example. Lets say we have a french deck and 150 cards in it. There is a "Front Face" of the card and a "Rear/Back Face" of the card. Depending on what you choose, your first interaction with the card will be one of these faces, and the back will have the meaning or the stuff you should remember.

If you will choose "Great" on the card, it wont be shown to you again, until you start to study the whole deck, however if you will click "Again" on the card, once you iterated the whole deck, you will now start to iterate the cards that you've chosen "Again" and you will choose "Again" or "Great" on these cards once again. This way you will have a great success of remembering/memorizing those stuff you were planning to learn.

# What do I aim to learn out of this project?
Trying to take a good grasp on some concepts that are new to me in C#, get some basic knowledge and understanding of how databases work and apply them in my project. 

I dont know much of DSA yet, but I've made some practice on linked lists in C before and I do think that a Quizlet/Anki clone is an amazing idea for also practicing linked lists. All the cards in a deck are connected to each other for real. They should be.

I also aim to learn new programming practices, concepts I've not heard before, and write a readable code, and optimise it once it works.

* Documenting new concepts I've found out for the first time and planning to take a look/already took a look or learnt:
   * **MVC**
   * **Overloading**
   * **Agile Methodology**
   * **Manager Class**
   * **Wrapper Object**
   * **Backgroundworker Class**
   * **SQL Injections**
   * **Threadpool**
   * **Singleton**
   * **Database Indexes**
   * **Lambda Functions**
* How does the program work?
   * I've used **C#** and **SQL Express Server** along with the **windows form** in the project, some **OOP concepts** included.
   * There is only one form, and in it there is a panel. You can see the user controls in the folder, and from that moment all the user controls will be controlled in that panel.
   * As it was my first time using databases, and me trying to get used to the basic concepts, I am aware that most of my database usage was not good in practice and I am trying to improve them by reviewing the code over and over. But here is the deal:
   - * There is a login page which is working, and there is a deckpage which is unique to the user whom is logged-in. Once the user is logged in, the program checks out the tables in the database and finds out the decks the user owns, and creates linklabes dynamically/programatically. Once those link labels are created, the program will take the cards for the deck, from the database and put it into a linked list, and from there we will be dealing with the linked list. But this takes toll on the UI so it's coded as async.
   - If the linklabel will be clicked, it will take you to the "flashcards" user control.
   - In the flashcards control you can move through the cards in the linked list, and for adding/editing cards, the user controls will be added dynamically as you can see in the flashcards.
   - If user will want to add/edit cards, it'll compare the linkedlist with database and update/insert or other proper methods and so on.
   - There is a button in the flashcard usercontrol as you can see, which is named "study", once clicked, it'll hide all the controls in the flashcards and will upload the user control for study flashcards user control.
   - From that moment you will be able to use the heart of the program, which is "again" or "great" feature. Once iterated, you will get to iterate the cards you've chosen "again" for.

# Progress
- [x] A working login page, with the option to log out. 
- [x] Decks are unique to the user whom has logged in.
- [x] You can delete the decks you've added, you can create one, see how many cards in it.
- [x] You can now study the flashcards in your deck quizlet/anki style. Once you finish studying a deck, it'll reshow you the cards again which you've decided to study again, or felt like you didn't learn them properly. When studying a deck, you can reset, or shuffle the deck.
- [x] You can now export cards into the textfile. You can edit the cards you've added.
- [x] Dynamically created deck names as in linklabels, and dynamic boxes for the cards, the more you want, the more you get.
- [x] You can move with arrow keys when browsing the deck in the flashcards panel.
- [x] Progress Bar that shows you how much you've done. 
- [ ] Stat and Browse page 
- [ ] Importing decks from others
- [ ] Work/Test mode for flashcard studies
- [ ] Being able to state what language is the face of card that we are seeing. 

**Existing bugs to be fixed**
* In the _Flashcards_ user control, after writing in the text box for adding cards to my deck, I'm not able to move in the textbox with arrow keys.
* Not every snap of code is safe for SQL Injections, though some parts are safe.
* UI Thread blocked when creating a new deck.

**Fixed Bugs**
* Could add cards which didn't use latin characters, such as "ų, ū, ş" but the database was removing them and making them into the latin characters.
* UI Thread was getting blocked from when creating the dynamic texts for deck names while getting them from the database. Used Async/Await.
* Dynamically created user controls weren't being deleted, or lapping over each other. Instead of going up in the page when deleted, they were going down.
* When deleting a deck, it was dropping the table but it's link label wasn't being deleted, which was created dynamically.
* Fixed some memory leak issues, such as linked list blowing up and having 1 million objects in it, or forgetting to close textfile/database.
* Progress bar...does progress now.
* In the _Flashcards_ user control, if I am deleting cards from my deck and only one is left, deleting that one will make that deck dead, will have to remove it and create again.
* When creating decks, I can't use deck names that contains spaces like "john's deck"
* Card numbers go out of the line, if its more than 99

### Screenshots
![image](https://user-images.githubusercontent.com/64064136/163731659-887a8497-306a-4766-abf6-847aa0e2f4dc.png)
![image](https://user-images.githubusercontent.com/64064136/163731692-82603bc3-e4b6-441f-9220-425874327f5a.png)
![image](https://user-images.githubusercontent.com/64064136/163731700-141cf2e3-b039-4d70-a2ad-a6d4fb3a929d.png)
![image](https://user-images.githubusercontent.com/64064136/163731703-d2048746-2cc0-4fce-8835-56803063886b.png)
![image](https://user-images.githubusercontent.com/64064136/163731711-6980c85b-cd29-42a2-942a-a2b19ec7cd68.png)



