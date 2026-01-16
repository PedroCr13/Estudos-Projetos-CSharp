# Exercício – Princípio da Segregação de Interfaces (SOLID) em C#

Este projeto foi desenvolvido em uma aula sobre os princípios **SOLID**, com foco no **Princípio da Segregação de Interfaces (Interface Segregation Principle – ISP)**.

## 📌 Conceito Abordado

O Princípio da Segregação de Interfaces define que **nenhuma classe deve ser forçada a depender de métodos que não utiliza**.  
Interfaces (ou abstrações) grandes devem ser divididas em **interfaces menores e mais específicas**, aumentando a coesão e reduzindo o acoplamento.

## 📌 Descrição do Exercício

No projeto **Loja**, anteriormente a classe `Item` possuía o método `ObterTaxa()`, o que causava problemas quando um produto não possuía taxa, como a classe `Agua`.

Para resolver isso, o método de cálculo de taxa foi removido de `Item`, e foi criada a abstração `ItemComTaxa`, responsável apenas pelos itens que realmente possuem taxa.

- `Item`: contém apenas dados comuns a todos os produtos
- `ItemComTaxa`: herda de `Item` e define os métodos relacionados a taxa
- `Cerveja`, `Suco`, `Destilado`: herdam de `ItemComTaxa`
- `Agua`: herda apenas de `Item`, pois não possui taxa

## 🟢 Benefícios da aplicação do ISP

- Classes implementam **apenas os métodos necessários**
- Redução de **acoplamento**
- Aumento de **coesão**
- Evita implementações desnecessárias
- Elimina violações do **Princípio de Liskov (LSP)**

## 🟢 Solução Aplicada

A solução consistiu em:

- Transformar `Item` em uma **classe abstrata**
- Definir o método abstrato `ObterTaxa()`
- Delegar para cada produto a responsabilidade de implementar sua própria taxa por meio de **sobrescrita**
- Utilizar **polimorfismo** na classe `Pedido`, eliminando a necessidade de condicionais

Com isso, novos produtos podem ser adicionados ao sistema sem modificar o código existente.

## 🛠️ Tecnologias

- C#
- Programação Orientada a Objetos
- Princípios SOLID

## 🎯 Objetivo

Demonstrar a aplicação do **ISP** como solução para o problema apresentado no exercício anterior, garantindo que cada classe dependa apenas dos comportamentos que realmente utiliza.

---
Exercício desenvolvido com fins educacionais para estudo de boas práticas de design de software.
