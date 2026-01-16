# Exercício – Princípio Liskov (SOLID)

Este projeto foi desenvolvido na aula sobre SOLID, com foco no ***Princípio da Substituição de Liskov (LSP)***.

## 🟢 Conceito abordado
O Princípio de Liskov define que objetos de uma classe base devem poder ser substituídos por objetos de suas subclasses sem que isso cause erros ou altere o comportamento esperado do sistema.
Se uma classe Item é usada em um ponto do sistema, qualquer uma de suas subclasses deve poder ser utilizada no lugar dela sem quebrar o funcionamento do programa.

## ✅ Benefícios da LSP

- Maior robustez do sistema
- Reutilização de código segura
- Garantia de que subclasses estendem, e não quebram, a classe base
- Consistência no comportamento das classes
- Facilita manutenção e testes automatizados

## 📌 Descrição do Exercício
No contexto de uma Loja, existe a classe abstrata Item, que define o método ObterTaxa() e o método ObterValorTotal(), que depende dessa taxa.
As classes Cerveja, Suco e Destilado herdam de Item e implementam corretamente o método de taxa, respeitando o LSP.
Porém, a classe Agua foi propositalmente alterada para não retornar nenhuma taxa, quebrando o contrato da classe base e causando falhas no projeto de testes

## 🔴 Violação do LSP
A classe Agua não pode substituir Item sem causar erro, ferindo o Princípio de Liskov e demonstrando na prática os problemas gerados por subclasses inconsistentes.

## 🟢 Objetivo
Demonstrar uma violação do LSP para posterior correção em outra aula, utilizando interfaces para garantir consistência e segurança no comportamento das classes

## 🧩 Estrutura do Projeto

- **Item**: classe base abstrata que define o contrato para cálculo de taxa
- **Agua, Cerveja, Suco, Destilado**: classes concretas que implementam suas próprias regras de taxa
- **Pedido**: responsável por calcular subtotal, taxas e valor total utilizando polimorfismo

## 🛠️ Tecnologias
- C#
- Programação Orientada a Objetos
- Princípios SOLID

---
Exercício desenvolvido com fins educacionais para estudo de boas práticas de design de software.
