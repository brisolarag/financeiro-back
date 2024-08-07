<a id="readme-top"></a>


[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/brisolarag/financeiro-back">
    <img src="https://http2.mlstatic.com/D_NQ_NP_900912-MLB48372399747_112021-O.webp" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Financeiro Backend</h3>

  <p align="center">
    This rep is the api to my app solution, where I can manage my personal finances
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template"><strong>Project repository »</strong></a>
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues/new?labels=bug&template=bug-report---.md">Report Bug</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues/new?labels=enhancement&template=feature-request---.md">View Frontend</a>
  </p>
</div>





<!-- ABOUT THE PROJECT -->
## Api usage
### Entries endpoints
```
Entrada is an entry operation in Portuguese
```
| Endpoint                                                               |  Type  |                                                                                             About |
|:-----------------------------------------------------------------------|:------:|--------------------------------------------------------------------------------------------------:|
| /Entrada                                                               |  GET   |                                                                       Get all  entries operations |
| /Entrada/ <span style="color:yellow; font-weight:bolder">{ id }</span> |  GET   |                                                  Get an entry operation passing the id in the URL |
| /Entrada/ <span style="color:yellow; font-weight:bolder">{ id }</span> |  PUT   | Edit some entry property by calling the id in the URL and passing the property change in the body |
| /Entrada/ <span style="color:yellow; font-weight:bolder">{ id }</span> | DELETE |                                           Delete any entry operation by passing the id in the URL |
### Outs endpoints
```
Saida is an out operation in Portuguese
```
| Endpoint                                                             |  Type  |                                                                                             About |
|:---------------------------------------------------------------------|:------:|--------------------------------------------------------------------------------------------------:|
| /Saida                                                               |  GET   |                                                                           Get all outs operations |
| /Saida/ <span style="color:yellow; font-weight:bolder">{ id }</span> |  GET   |                                                    Get an out operation passing the id in the URL |
| /Saida/ <span style="color:yellow; font-weight:bolder">{ id }</span> |  PUT   | Edit some entry property by calling the id in the URL and passing the property change in the body |
| /Saida/ <span style="color:yellow; font-weight:bolder">{ id }</span> | DELETE |                                             Delete any out operation by passing the id in the URL |
Using this API, you're able to create new entries and outs, and consume the api using views to create a consistent app. Here is also the api documentation to consume the endpoints.

Here's what you can do:
* CRUD entries...
* CRUD outs...
* Get some general reports.
* More will be avalible in the future.

There also a `docker-compose.yml` file in the root repository to run the application in a container.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With
* [![DOTNET][DOTNET8]][DOTNET8-url]
* [![DOTNET][EFCORE8]][EFCORE8-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- GETTING STARTED -->
## Getting Started

This sections is properly wrote to show the instruction to run and help to contribute to this project.
This is how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* dotnet (this is how you can get your sdks in your sh)
* You must have **.NET 8.0** listed below
  ```sh
  dotnet --list-sdks
  ```

### Installation and Contributing

_Below is the **step-by-step** of how you can contribute and run the application properly_

1. Clone the repo and get your branch
   ```sh
   git clone https://github.com/brisolarag/financeiro-back
   ```
2. Go to the branch you will be developing **(skip this step if you're not contributing)**
<br>_**Here you'll need to pass what type of branch you need <span style="color:red">(push to the same branch)</span>, such as:**_
   - Feat
   - Fix
   - ...More
    ```sh
    git checkout -b {type}/{name}
      ```
3. Install packages by building or restoring
   ```sh
   dotnet build
   ```
4. Enter your SQLite connection in `appsettings.Development.json`
   ```json
   {
      "ConnectionStrings": {
      "Default": "Data Source=Database/app-develop.db"
      }
    }
   ```
5. Apply the migrations to the database
    ```sh
   dotnet ef database update
    ```
6. Run
    ```sh
   dotnet watch run
    ```
<p align="right">(<a href="#readme-top">back to top</a>)</p>





<!-- CONTACT -->
## Contact

Gabriel Brisolara - [Linkedin](https://www.linkedin.com/in/gabriel-brisolara/) - dev.brisolara@gmail.com

Project Link: [https://github.com/brisolarag/financeiro-back](https://github.com/brisolarag/financeiro-back)

<p align="right">(<a href="#readme-top">back to top</a>)</p>





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/brisolarag/financeiro-back.svg?style=for-the-badge
[contributors-url]: https://github.com/brisolarag/financeiro-back/graphs/contributors

[forks-shield]: https://img.shields.io/github/forks/brisolarag/financeiro-back.svg?style=for-the-badge
[forks-url]: https://github.com/brisolarag/financeiro-back/network/members

[stars-shield]: https://img.shields.io/github/stars/brisolarag/financeiro-back.svg?style=for-the-badge
[stars-url]: https://github.com/brisolarag/financeiro-back/stargazers

[issues-shield]: https://img.shields.io/github/issues/brisolarag/financeiro-back.svg?style=for-the-badge
[issues-url]: https://github.com/brisolarag/financeiro-back/issues

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/gabriel-brisolara/

[product-screenshot]: images/screenshot.png

[DOTNET8]: https://img.shields.io/badge/.NET-8.0-blue
[DOTNET8-url]: https://dotnet.microsoft.com/pt-br/lue
[EFCORE8]: https://img.shields.io/badge/.EFCORE-8.0-red
[EFCORE8-url]: https://learn.microsoft.com/pt-br/ef/core/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/