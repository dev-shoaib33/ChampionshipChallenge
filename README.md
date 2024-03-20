# Championship Challenge

## Description
Championship Challenge is a coding challenge designed to allow developers the freedom to fulfill the challenge requirements according to their skill set. As we all know, there are practically infinite ways to solve any programming problem. In this case, this will allow us to collaborate and evaluate the level of understanding a developer has for their solution.

## Requirements
- Read in data from the file 'Matches.txt'
  - Each line is a match-up
  - Compare the results of each and score the teams according to the scoring rules
- Output (to the console) each team & their scores, in descending order of score, respecting the format of the example below:

Ex:
````
Lizards - # points
Cats - # points
Lions - # points
Dogs - # points
Bears - # points
````


## Scoring Rules
- If a team wins a match, they are granted 3 points
- If a team loses a match, they are granted 0 points
- If the teams tie, each team is granted 1 point

# ChampionshipChallenge

ChampionshipChallenge is a C# console application for managing and displaying scores of matches in a championship.

## Overview

ChampionshipChallenge allows you to read match data from a file, process it, and display the scores of the matches in a championship.

## Features

- Read match data from a file.
- Process match data to calculate scores.
- Display scores.

## Project Architecture

The project is structured as follows:

### Models

- **Team**: Stores data about teams including team names and points.
- **Match**: Represents individual matches and allows comparison of scores.

### Services

- **ChampionshipService**: Contains business logic to calculate scores based on match data.
- **ValidationService**: Provides functionality for data validation and file validation.

### Tests

The `ChampionshipChallenge.Tests` project contains XUnit test cases for testing various components of the application.

