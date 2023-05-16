# Simple BDD API Testing

The C# solution demonstrates a simple way to quickly get setup and start scripting API test scenarios which follow the popular BDD testing technique.

## Installation

Open the APIExercise.sln file in either Visual Studio (recommended) / Visual Studio Code as a existing project.

Build the solution from the .sln directory
```bash
dotnet build
```
Visual Studio should automatically fetch and initialise any required packages to then successfully run the example test scenarios.

## Usage

The example scenarios in written feature file are tagged. Two example tags are used **Smoke** & **Categories**(to run all the scenarios). 

Example Usage - 
```bash
dotnet test API.Tests --filter TestCategory=Smoke
```

## License
None
