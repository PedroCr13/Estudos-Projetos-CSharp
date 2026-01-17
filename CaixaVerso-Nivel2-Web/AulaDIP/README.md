# Exercício – Princípio da Inversão de Dependência DIP (SOLID) em C#

Este projeto foi desenvolvido na aula sobre os princípios **SOLID**, com foco no **Princípio da Inversão de Dependência (Dependency Inversion Principle – DIP)**.

## 📌 Conceito Abordado

O Princípio da Inversão de Dependência estabelece que **módulos de alto nível não devem depender de módulos de baixo nível**, mas ambos devem depender de **abstrações**.

Tradicionalmente, o código de alto nível depende diretamente de implementações concretas. O DIP propõe uma inversão dessa dependência, tornando o sistema mais flexível, desacoplado e fácil de manter.

## 🟢 Vantagens do DIP

- Redução de acoplamento entre classes  
- Facilidade de manutenção e extensão  
- Design mais modular  
- Alterações em módulos de baixo nível não afetam módulos de alto nível  

Um indício comum de violação do DIP é o uso excessivo de `new` dentro das classes, criando dependência direta de implementações concretas.

## 🟢 Solução Aplicada

No projeto **Loja**, o exercício de DIP de forma bastante simples foi aplicado na classe `ItemComTaxa`.

Foi introduzida uma nova regra de negócio hipotética:  

**durante o mês de dezembro, todo produto passa a ter uma taxa fixa de 10%**.

Inicialmente, a verificação do mês era feita instanciando um `DateTime` diretamente dentro do método, o que gerava forte acoplamento e violava o DIP.

Posteriormente, o código foi refatorado para que a data fosse **recebida como parâmetro** (`DateTime data`), sendo instanciada externamente (na classe de testes) e passada para o método.

Dessa forma, a classe deixou de depender diretamente da criação do objeto, passando a depender apenas da abstração do dado recebido.

## 🛠️ Tecnologias

- C#
- Programação Orientada a Objetos
- Princípios SOLID

## 🎯 Objetivo

Demonstrar a aplicação do **DIP**, removendo dependências diretas de implementações concretas e tornando o código mais flexível, testável e desacoplado.

---
Exercício desenvolvido com fins educacionais para estudo de boas práticas de design de software.
