# Outside-In TDD Workshop with ASP.NET Core and EF Core

More details on the dotnetdays 2020 workshop [page](https://dotnetdays.ro/workshops/outside-in-tdd)

## Client App setup

- Install nvm from [here](https://github.com/coreybutler/nvm-windows/releases)
- Install yarn from [here](https://classic.yarnpkg.com/en/docs/install/#windows-stable)
- Clone [this](https://github.com/drogojan/cleancoders_openchat_webclient) repo
- Switch to the `workshop` branch
- Using nvm, install node v8.9.3 -> `nvm install 8.9.3`
- If you have multiple versions of node installed, make sure you use v8.9.3 when running the client app -> `nvm use 8.9.3`
- Run `yarn install`
- Run `yarn start`

The client app should open in the default browser on the http://localhost:3000 address.

## Prepare development environment

- Make sure you have installed the .NET Core 3.1 [SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- Using Visual Studio 2019 or Visual Studio Code, make sure you can build the OpenChat.sln solution

## Resources

- [The Art of Unit Testing](https://www.amazon.com/Art-Unit-Testing-examples/dp/1617290890)
- [Growing Object-Oriented Software, Guided by Tests](https://www.amazon.com/Growing-Object-Oriented-Software-Guided-Tests/dp/0321503627)
- [Test Driven Development: By Example](https://www.amazon.com/Test-Driven-Development-Kent-Beck/dp/0321146530)
- [Unit Testing Principles, Practices, and Patterns](https://www.amazon.com/Unit-Testing-Principles-Practices-Patterns/dp/1617296279)
- [Codurance Katalist - TDD katas](https://katalyst.codurance.com/)
- [Outside In TDD - Bank kata](https://katalyst.codurance.com/bank)
- [Testing and refactoring legacy code](https://www.youtube.com/watch?v=_NnElPO5BU0)
- [Codemanship - TDD - Jason Gorman](http://www.codemanship.co.uk/tdd_jasongorman_codemanship.pdf)
- [TDD in Javascript](https://codemanship.wordpress.com/2020/02/22/test-driven-development-in-javascript/)
- [EfCore.TestSupport](https://github.com/JonPSmith/EfCore.TestSupport)

## Slides

- [Slides](https://1drv.ms/p/s!AsCmpNilWAlAia4rFapFVlpyzMpsjQ?e=i3bhVP)

## Finished solution

[Check my Github repo](https://github.com/drogojan/outside-in-tdd-workshop/tree/clean-architecture)