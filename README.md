# RFS Phase 3 - Final Project

## Overview
You have been commissioned to build a new, simple application for managing RF-SMART’s “Library” conference room’s books. Lately there’s been confusion around who’s reading what books, which ones are available in the library conference room, and when they’re expected back. Some employees also would like to leave comments about a book they’ve read and read other’s comments as well. Finally, when a book is accidentally destroyed or lost, nobody is sure who to tell or how to let others know it’s no longer available.

### Necessary Deliverables

To assist with the design of this application, here are some general guidelines for technical direction and overall design for how to approach this project:

#### You will need a DATABASE
- This can be created using mySQL or PostgreSQL
- You can use a Docker container for doing this, or
- You can install a database directly on your local machine
- You get to design the schema, tables, etc. that you’ll use based on what you learn
#### You will need a C# API PROJECT
- You’re going to be creating REST services
- You’ll need classes to represent your data models, requests, responses, etc.
- You’ll need controllers with actions to represent your REST endpoints
- You’ll need some validation
- You’ll need NuGet packages for communicating with your database
- You’ll need settings for the connection string and potentially other things
- You’ll need to store, update, and read data from your database in your code
#### You will need a WEB APPLICATION
- Use your JavaScript skills to create a basic web application
- You’ll be calling your REST API from your web application to perform the various actions
- It doesn’t have to be pretty, but it should be functional
#### You will need a C# END-TO-END AUTOMATION TEST PROJECT
- This will use Playwright with C#
- You’ll use the Page Object Model (POM) pattern
- You’ll need tests that cover the UI
- You’ll need tests that cover the API directly
- See: Test Cases*
#### You should be able to RUN EVERYTHING "LOCALLY" ON YOUR MACHINE
- Bonus points for orchestrating them in containers (docker, docker-compose, etc.)


### Test Cases
#### Test Case Constraints / Requirements:
- You should use the Page Object Model design pattern in constructing your test bed
- There should be 2 test cases for each use-case presented: 1 for UI, 1 against the API.
- There should also be at least 4 negative test cases, you can distribute the 4 across different use-cases or all on the same use-case.
- Collect data and create artifact after manipulating it in some way (reverse the order, select last 5, etc.)
- Create a broken or non-existent endpoint in the API and test that a happy path test returns a failing test result.


### Submission
- Commit your code to GitHub for review
- Demo individually with SDETS, and code will be reviewed


Timeline goal: 2 months


## Project Links
#### RFS Academy Playbook
- [RFS Academy Playbook.pdf](https://github.com/jbabs22/rfsproject3/files/14256030/RFS.Academy.Playbook.pdf)
#### RFS Academy Phase 3 Automation Project
- [RFS Academy_Phase 3_Automation Project.pdf](https://github.com/jbabs22/rfsproject3/files/14256032/RFS.Academy_Phase.3_Automation.Project.pdf)
#### SDET Phase 3 - Introduction to Object Oriented
- [SDET Phase 3 - Introduction to OO.pptx](https://github.com/jbabs22/rfsproject3/files/14256042/SDET.Phase.3.-.Introduction.to.OO.pptx)
