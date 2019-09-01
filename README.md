# POC - Sistema de Gestão Ambiental

Trabalho de Conclusão de Curso de Especialização em Arquitetura de Software Distribuído como requisito parcial à obtenção do título de especialista.

- Será necessário um ambiente com [Docker](https://www.docker.com/) instalado.

Para rodar o projeto, clone este repositório e execute o seguinte comando:
```console
docker-compose -f ./src/docker-compose.yml up
```

Com isso toda a estrutura do projeto será criada e configurada, será necessário apenas criar as tabelas do banco de dados relacional do módulo de processos, para isso execute os comandos abaixo substituindo o `src_sqlserver_1` com o nome do container de sqlserver criado pelo docker-compose:
```
docker cp ./sql/db-processos.sql src_sqlserver_1:./
docker exec src_sqlserver_1 bash -c '/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P ${SA_PASSWORD} -i db-processos.sql'
```