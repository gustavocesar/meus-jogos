# Desafio .Net

Seus amigos vivem pedindo seus jogos emprestados. Muitas vezes você quer jogar um jogo e não sabe com quem está. Pensando nisso, crie um sistema que você possa gerenciar os empréstimos dos seus jogos.
O sistema deverá permitir a inserção/edição/exclusão de amigos e jogos, além de permitir o gerenciamento e visualização dos seus jogos, dos amigos e qual jogo está com quem.

| Requisito | Status | Observações |
| ------ | ------ | ------ |
| Inserção/Edição/Exclusão de Jogos | Ok |  |
| Inserção/Edição/Exclusão de Amigos | Todo |  |
| Visualização de Amigos e Jogos | Ok |  |
| Gerenciamento de Jogos (emprestimo) | Ok |  |
| Gerenciamento de Jogos (devolução) | Todo |  |
| .Net core | Ok |  |
| Controle de segurança/acesso (Jwt) | Ok | Mock de usuários |
| WebApi ou MVC | Ok | WebApi no backend e Mvc no frontend |
| Mecanismo de banco de dados SQL e/ou NOSQL | Ok | SqlServer com docker (Seeds pelo Entity Framework) |
| Docker files dos projetos + Docker compose | Ok | Dockerfile e Docker-Compose na raiz + Dockerfile dentro de Presentation (front-end) |
| Camada de testes | Ok | Somente nos projetos de domínio |
| Script de CI | Todo | |
| Arquitetura | Ok | DDD com Cqrs |
| Integração com front | Ok | Mvc e Jquery |
| Disponibilizar o código em um repositório | Ok | https://github.com/gustavocesar/meus-jogos |


### Instalação

Requer [Docker](https://www.docker.com).

```sh
docker build -t meus-jogos-api -f Dockerfile .
cd ./Presentation
docker build -t meus-jogos-front -f Dockerfile .
cd ..
docker-compose up -d
```
