# SnowmanLabs

## .NET 6 Solution Template

Based on **DDD, Vertical Slice Architecture & CQS Pattern**

Note: *This project uses Husky & Commitlint to keep track of commits and branches that follow Gitflow standards*

## Before start

The project is set to use husky + commitlint + commitizen to follow Gitflow standards for **commit** changes

To take advantage of this feature you should do the following:

- Install `Node.js` 16+ and `yarn` package on your computer 
- Run `yarn install`
- Run your `git` commands (except commit)
- And then `yarn commit`
- Follow the instructions on the terminal
- After finishing all the steps above, finally do your `git push` to send it to remote

## Tests

The project is configured to use PostgreSQL and the connection string for integration tests is set on `Application.IntegrationTest.Common`
