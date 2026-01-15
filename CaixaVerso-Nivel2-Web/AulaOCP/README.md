# Exercício – Princípio Open/Closed (SOLID)

Este projeto é um exercício prático para aplicar o **Princípio do Open/Closed (OCP)** do SOLID, que afirma que entidades de software devem estar **abertas para extensão, mas fechadas para modificação**.

## 📌 Contexto do Exercício
O sistema representa uma loja onde diferentes tipos de produtos possuem **taxas específicas** que impactam o valor final de um pedido.

## 🔴 Problema Inicial
Inicialmente, o cálculo das taxas dos produtos estava centralizado na classe `Item`, utilizando estruturas condicionais (`if/else`) baseadas na categoria do produto.  
Sempre que um novo produto era adicionado, era necessário **alterar a classe base**, o que viola o princípio Open/Closed e dificulta a manutenção do sistema.

## 🟢 Solução Aplicada
A solução consistiu em:

- Transformar `Item` em uma **classe abstrata**
- Definir o método abstrato `ObterTaxa()`
- Delegar para cada produto a responsabilidade de implementar sua própria taxa por meio de **sobrescrita**
- Utilizar **polimorfismo** na classe `Pedido`, eliminando a necessidade de condicionais

Com isso, novos produtos podem ser adicionados ao sistema sem modificar o código existente.

## 🧩 Estrutura do Projeto

- **Item**: classe base abstrata que define o contrato para cálculo de taxa
- **Agua, Cerveja, Suco, Destilado**: classes concretas que implementam suas próprias regras de taxa
- **Pedido**: responsável por calcular subtotal, taxas e valor total utilizando polimorfismo

## ✅ Benefícios da Abordagem

- Código mais limpo e organizado
- Facilidade para expansão do sistema
- Redução de acoplamento
- Melhor manutenção
- Aderência aos princípios SOLID

## 🛠️ Tecnologias
- C#
- Programação Orientada a Objetos
- Princípios SOLID

---
Exercício desenvolvido com fins educacionais para estudo de boas práticas de design de software.
