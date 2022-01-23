# Projeto demo api custom countries

Projeto .Net Core que lista países através de uma api. As informações para cadastro de um país, pode ser obtido neste link [countries graphql](https://countries.trevorblades.com/).

#### Payload para buscar algum país em [countries graphql](https://countries.trevorblades.com/)

```console
{
  country(code: "BR") {
    name
    native
    capital
    emoji
    currency
    languages {
      code
      name
    }
  }
}
```

## Pré requisitos para rodar local

- Visual Studio ou algum outro IDE que rode .Net Core 3.1
- Conexão com banco de dados NoSql MongoDB
- Chave do Application Insights AZ
- Projeto authority - [demo identity server auth](https://github.com/andremco/demo-identity-server-auth)

## Instância MongoDB NoSql
Para rodar a api localmente, foi utilizado o ambiente docker contendo as instâncias do mongodb e do mongo-express. No diretório `infra/mongo` contém o `docker-compose.yml` com os devidos containers. É necessário ter o docker instalado no seu ambiente de desenvolvimento, e rodar o seguinte comando, para subir as instâncias:  

```console
docker-compose up --force-recreate -d
```

Se preferir, pode utilizar também a instância community edition do mongodb. Instruções para instalar esta versão em seu ambiente [mongodb - install](https://docs.mongodb.com/manual/administration/install-community/). Ou pode utilizar o recurso Azure Cosmos DB API for MongoDB, para mais detalhes segue este tutorial [create-mongodb-dotnet](https://docs.microsoft.com/pt-br/azure/cosmos-db/mongodb/create-mongodb-dotnet).

## Obter instrumentation key do application insights

Para mais informações, segue este [tutorial](https://docs.microsoft.com/pt-br/azure/azure-monitor/app/create-new-resource).

## Arquitetura da API
- Utilizando injeção de dependências nas classes
- Padrão singleton utilizando uma instância somente
- Repositórios para abstrair o acesso a camada do banco de dados
- Services onde é feita toda a lógica da aplicação
- Validações na camada domain do projeto
