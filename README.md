# Tamagotchi Akka.NET

A few notes about the implementation.

**Running the Game**

* On startup, a timeframe needs to be specified. This is how quickly the game "turns" and in effect how fast the Tamagothic ages.  Each tick is a month, so if you specify 2 seconds then
it takes 2 seconds for the Tamagothchi to age 1 month.
* Each life stage takes 4 years in Tamagotchi life.
* Weight was specified as an attribute of the Tamagotchi, however, it was not indicated how it affects the dragon, so I decided not to implement it.
* The user can feed the dragon by pressing "F" and pet by pressing "P".
* If Hunger reaches 100 or loneliness 0, the dragon dies.

**Implementation**

* I used Akka.NET to relay pet and feed messages (life progress) to the life actor and subsequent dragon actor.
* I used a strategy pattern to determine how the dragon's life stage affects its hunger and happiness levels.

The console game play implementation is crude and many improvements can still be made but I am happy it as is (my wife played the game and
she was hooked)!

**Unit tests**

There is one test that fails when the whole test suite is executed together.

Although they all run sequentially, I suspect it might an issue with the static "sys" container 
tear down for the xUnit implementation of the TestKit.
        
It runs OK on its own or in conjunction with the rest of the tests in the class.

**Thanks!**
