# Enquete #
## App de enquete ##
### MySQL ###
* Instalar o MySQL 8.0
* Instalar MySQL Workbench
* Abrir MySQL Workbench
* Criar a database "appenquete"

### Instação ###
* git clone https://github.com/xavierluz/enquete.git 
* cd enquete 


#### Visual Studio 2019 ####
* Abrir o projeto app-enquete.sln
#### Nuget ####
##### MySql.Data.EntityFrameworkCore for Entity Framework. #####
**1. Install-Package MySql.Data.EntityFrameworkCore -Version 8.0.21**
##### Microsoft.EntityFrameworkCore #####
**1. Install-Package Microsoft.EntityFrameworkCore -Version 3.1.6**
##### Microsoft.EntityFrameworkCore.Design #####
**1. Install-Package Microsoft.EntityFrameworkCore.Design -Version 3.1.6**
##### Microsoft.EntityFrameworkCore.Tools #####
**1. Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.6**
##### Microsoft.Extensions.Configuration.UserSecrets #####
**1. Install-Package Microsoft.Extensions.Configuration.UserSecrets -Version 3.1.6**

#### Conexão com banco de dados MySQL ####
**Criar Conexão 
**_Adicionar no arquivo appsettings.json_**
```
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;user id=usuario;pwd=senha;persistsecurityinfo=True;database=appenquete;port=3306"
  }
  ```
 #### Migration ####
 ##### Gerar script do banco de dados #####
 1. Add-Migration -name "InitialEnquete" 
 2. Script-Migration
 3. Copiar o script gerado
 
 #### Abrir MySQL Workbench ####
 1. Colar o script
 2. executar o script**
 
 
