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

## Contributing
- Fork this repo
- Create an upstream remote

``` 
git remote add upstream https://github.com/drogojan/dotnetdays-outside-in-tdd-workshop.git
```

- Sync local `dojo-starting-point` branch with the upstream `dojo-starting-point` branch


```
git checkout dojo-starting-point
git pull upstream dojo-starting-point
```

- Create feature branch

```
git checkout -b <feature-branch-name>
```

- When done with the implementation, create a pull request from your feature branch to the upstream `dojo-starting-point` branch