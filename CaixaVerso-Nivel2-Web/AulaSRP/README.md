# Aula SRP – Single Responsibility Principle

Este exercício foi desenvolvido durante a aula sobre o **SRP (Princípio da Responsabilidade Única)**, que estabelece que **uma classe deve ter apenas uma razão para existir ou mudar**.

## Objetivo da Aula
Demonstrar como a separação correta de responsabilidades:
- Facilita a manutenção
- Torna o código mais testável
- Melhora a legibilidade
- Ajuda na correção de bugs

## Exemplo Abordado
Durante a aula, foi explicado que uma classe como `GerenciaUsuarioEEnvioDeEmail` viola o SRP, pois possui mais de uma responsabilidade.

O ideal é separar em classes distintas, como:
- Uma classe responsável por Usuários
- Outra classe responsável por Envio de Email

## Estrutura do Exercício
Neste projeto:

### Pedido
A classe **Pedido** é responsável apenas por:
- Gerenciar os itens do pedido
- Calcular o valor total
- Calcular o valor total com taxas

### Item
A classe **Item** é responsável por:
- Representar um item
- Definir sua categoria
- Informar a taxa aplicada conforme a categoria

As regras de taxa foram implementadas com `if/else`, pois o foco deste exercício é o **SRP**, não o **OCP**.

## Testes e TDD
O projeto possui um projeto de testes utilizando **xUnit**, onde foi apresentada uma introdução ao **TDD (Test Driven Development)**:

- Primeiro os testes foram criados
- Inicialmente os testes falharam
- O código foi ajustado até que os testes passassem
- Os testes validam os métodos com os resultados esperados

## Observação
Este exercício serve como base para evoluções posteriores, como a aplicação do **OCP (Open/Closed Principle)** em aulas seguintes.