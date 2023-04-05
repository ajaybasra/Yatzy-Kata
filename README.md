# Yatzy Kata
---
### Author: Ajay Basra
I found this kata to be quite rewarding as I really got the chance to practice mock tests in multiple contexts, furthermore, I had the chance to learn and apply a lot of new concepts such as the factory design pattern. Though not fully polished, I'm happy with what I've achieved within a short amount of time.

## Key Concepts:
These are some key concepts which I felt were strongly applied to the kata.

### TDD
I primarily used a bottom-up TDD approach to ensure that code that I was writing actually worked under multiple constraints. This was my preferred approach as starting at the high level and mocking smaller modules doesn't seem as intuitive to me but my mentor reassured me that both approaches are valid and that they can be used hand in hand.

### Test Doubles
I used mocks in a lot of different situations, e.g. to simiulate user input. This was a powerful tool and allowed me to check things such as how many times a method was invoked, and it allowed me to manipulate what methods spit out. One particular case that comes to mind is that I mocked the random number generator interface to generate a fixed value as otherwise testing with random output is tricky. For instance, we can't predict what a players final score will be if they are scoring a random roll each time.
### Factory Pattern
For the creation of player objects inside of the game class I utilized the factory design pattern so that player creation was abstracted away from the game class, as it didn't make sense for the game class to depend on how the players are created. This also made testing easier because when it came time to add tests for the game class, I was able to mock the player factory interface.
### Seperation of Concerns
I tried to keep in mind SRP so that my classes and methods aren't doing too much which provided numerous benefits. For instance, it made my code more readable and easier to test. 
## Room for improvement:
    - Do more planning, for example, I added the player interface quite late into development
    - Whilst I obeyed TDD at the start, there were times later on where I would code up functionality and add tests later..
    - Some of the player methods are quite dense, could maybe refactor
    - Emoji's stopped showing up in the console, could fix but atm it's a super minor issue
    - Be more purposeful when it comes to creation and usage of interfaces
    - Be more aware of test coverage and maybe aim for x% as a goal
### Requirements 🔧
* [Download .NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

### Installation 🔌
1. Clone the repo or download as zip file.
2. Navigate into the project directory.
3. Run the following command: `dotnet run`