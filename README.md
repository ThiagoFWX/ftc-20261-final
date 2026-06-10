# 📚 Projeto – Implementação de Máquinas Abstratas: AFD, Autômato de Pilha e Máquina de Turing

## 👥 Integrantes da Equipe

* Ana Carolina Rodrigues de Almeida César Alves – 72500719
* Thiago Ferraz Werneck Xavier – 72301244

## 📌 Descrição do Projeto

Este projeto foi desenvolvido como trabalho final da disciplina de Fundamentos Teóricos da Computação, contendo a implementação de três modelos formais:

### 🔹 Parte 1 - Autômato Finito Determinístico (AFD)

* Implementação de um simulador de AFD.
* Leitura da configuração do autômato via arquivo JSON (`afd.json`).
* Leitura das entradas a partir de arquivo (`entradas.txt`).
* Processamento das cadeias com base nas transições definidas.
* Geração de logs com os resultados da simulação.

Principais componentes:

* `AFD.cs`, `Estado.cs`, `Transicao.cs`
* `AfdConfigLoaderService.cs`
* `AfdSimulatorService.cs`

---

### 🔹 Parte 2 - Autômato de Pilha (AP)

* Implementação de um simulador de autômato de pilha.
* Processamento de cadeias com uso de pilha.
* Controle de estados, transições e conteúdo da pilha.
* Representação de configurações instantâneas durante a execução.

Principais componentes:

* `AutomatoPilha.cs`
* `TransicaoPilha.cs`
* `ConfiguracaoInstantanea.cs`
* `SimuladorAutomatoPilhaService.cs`

---

### 🔹 Parte 3 - Máquina de Turing (MT)

* Implementação de um simulador de Máquina de Turing.
* Leitura de configuração via arquivos JSON (`mt.json` e `mt_unario.json`).
* Manipulação de fita, cabeçote e estados.
* Execução passo a passo das transições.

Principais componentes:

* `MaquinaTuring.cs`
* `Fita.cs`
* `Cabecote.cs`
* `TransicaoMT.cs`
* `MtSimulatorService.cs`

---

## 🚀 Como Usar

### ✅ Pré-requisitos

* .NET 6 ou superior instalado

---
### 1. Clone o repositório:
```git clone https://github.com/ThiagoFWX/ftc-20261-final.git```

### 2. Entre na pasta do projeto:
```cd ftc-20261-final```

---

### ▶️ Executar Parte 1 (AFD)

```bash
cd Parte1
dotnet run
```

---

### ▶️ Executar Parte 2 (Autômato de Pilha)

```bash
cd Parte2
dotnet run
```

---

### ▶️ Executar Parte 3 (Máquina de Turing)

```bash
cd Parte3
dotnet run
```

---

## 📂 Estrutura do Projeto

```
Parte1/
 ├── config/
 ├── data/
 ├── models/
 ├── services/

Parte2/
 ├── data/
 ├── models/
 ├── services/

Parte3/
 ├── config/
 ├── data/
 ├── models/
 ├── services/
```

---

## 🎥 Vídeo de Defesa

Link do vídeo:
👉 [Vídeo - Trabalho Final FTC](https://youtu.be/5LJL_L8kBv4)

---

## 📌 Observações

* Os arquivos de entrada estão localizados nas pastas `data/`.
* As configurações dos autômatos estão nas pastas `config/`.
* Os logs de execução são gerados nas pastas `logs/`.

---
