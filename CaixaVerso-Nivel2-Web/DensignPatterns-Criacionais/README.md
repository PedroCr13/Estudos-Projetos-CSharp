
# Exercicio desenvolvido durante Aula Design Patterns – Padrões Criacionais (C#)

Este projeto foi desenvolvido como parte do estudo de **Design Patterns**, com foco inicial nos **padrões criacionais**, conforme apresentado em aula.

O objetivo principal é **compreender o conceito**, a **intenção de cada padrão** e **ver exemplos práticos e simples em C#**, servindo como material de consulta futura.

---

##  O que são Design Patterns?

Design Patterns (Padrões de Projeto) são **soluções reutilizáveis para problemas recorrentes** no desenvolvimento de software.

Eles **não são códigos prontos**, mas sim **modelos de solução** que ajudam a:
- organizar melhor o código
- reduzir acoplamento
- facilitar manutenção e extensão
- melhorar a comunicação entre desenvolvedores

📚 Referência:
Refactoring Guru – https://refactoring.guru/pt-br/design-patterns/

---

##  Padrões Criacionais

Os padrões criacionais tratam da **forma como os objetos são criados**, abstraindo ou controlando esse processo.

Padrões estudados neste projeto:
- Singleton
- Factory Method
- Abstract Factory
- Builder
- Prototype

> Observação: Para fins didáticos, algumas pastas mantêm mais de uma classe por arquivo.

---
## Estrutura do projeto:

```
Criacionais/
│
├── Singleton/
│   └── Singleton.cs
│
├── Factory/
│   └── FactoryMethod.cs
│
├── AbstractFactory/
│   └── AbstractFactory.cs
│
├── Builder/
│   └── Builder.cs
│
├── Prototype/
│   └── Prototype.cs
│
└── Program.cs
```

---
## 🔹 Singleton

Garante que uma classe possua **apenas uma instância** durante toda a aplicação.

**Exemplo:** `MeuBancoDeDados`  
Utilizado para simular recursos compartilhados como conexão com banco de dados.

Conceito-chave:
> Uma única instância acessível globalmente.

---

## 🔹 Factory Method

Define uma interface para criação de objetos, permitindo que subclasses decidam **qual objeto instanciar**.

**Exemplo:** Sistema de logs (`SimpleLog`, `DetailedLog`).

Conceito-chave:
> Delegar a criação do objeto para subclasses.

---

## 🔹 Abstract Factory

Permite criar **famílias de objetos relacionados** sem depender de classes concretas.

**Exemplo:** Interface gráfica com temas Claro e Escuro (Botão e Caixa de Texto).

Conceito-chave:
> Criar objetos compatíveis entre si.

---

## 🔹 Builder

Constrói objetos complexos **passo a passo**, permitindo variações no resultado final.

**Exemplo:** Construção de interfaces diferentes conforme o tipo de cliente.

Conceito-chave:
> Separar construção da representação.

---

## 🔹 Prototype

Cria novos objetos **clonando instâncias existentes**, evitando dependência direta da classe.

**Exemplo:** Clonagem de documentos.

Conceito-chave:
> Clonar objetos sem compartilhar referência.

---

##  Execução

O arquivo `Program.cs` demonstra o uso de cada padrão por meio de exemplos simples no console.

---

##  Objetivo

Este projeto serve como:
- material de estudo
- apoio para revisões futuras
- base para projetos mais avançados com Design Patterns
