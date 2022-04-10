# Honeypot Webservice (API)
## Task
Write a honeypot web service that accepts all GET requests and replies very slowly with an infinite stream of text, tying up the bot's resources and slowing it down.

This service sends a new line of text, "Not Found", once every 5 seconds.

## Deliverables
<git repository link>

## How to build & run

  I have no experience with the Docker/Container mechanism, so I have added docker support to this solution but haven't tested or configured it. Therefore, to build and run this API, please follow the instructions:
1.	Clone repository
2.	On the debugging option, change from "Docker" to "IIS Express"
3.	Once the web service is running, it will launch a swagger page with the below link:
https://localhost:44389/swagger/index.html
4.	To test the service, please run the following commands on a command prompt (as administrator):
  - curl https://localhost:44389/wplogin.cgi?admin=True

  - curl https://localhost:44389/wplogin.cgi?admin

  - curl https://localhost:44389/wplogin.cgi

  - curl https://localhost:44389/wplogin

  - curl https://localhost:44389/

  - curl https://localhost:44389/wplogin?admin=True

  - curl https://localhost:44389/cgi?admin=True

  - curl https://localhost:44389?admin=True

## Considerations
#### Async/Await
  The endpoint implementation uses the async-await mechanism to ensure that multiple concurrent requests can be handled simultaneously without any issues.
#### DI Lifetime
  The dependency injection is scoped with Transient lifetime to ensure that a new service is created for every API endpoint request.

## Unit Tests
Unfortunately, I have created empty unit tests as I couldn't get around to implementing tests for the controller or the interface-concrete method. I understand the importance of the unit tests; however, I am still trying to get my head around the implementation to test the stream of chunks on the HttpResponse object.
