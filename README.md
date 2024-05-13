# API de Investimentos
Este projeto é uma API .NET que permite um usuário comprar e vender produtos financeiros, além de consultar sua carteira de investimentos e o extrato de todas as operações realizadas.

## Como executar a aplicação

1. **Pré-requisitos**: 
Certifique-se de ter o **.NET 8** e o **Docker** instalados em sua máquina.

2. **Clone o repositório**: 
Use o comando `git clone https://github.com/matheusbezulle/xpchallenge-investimento-api.git` para clonar o repositório.

3. **Navegue até o diretório do projeto**: 
Use o comando `cd xpchallenge-investimento-api`.

4. **Construa o projeto**: 
Execute o docker-compose na raiz do projeto com o comando `docker-compose-build` para buildar o projeto.

5. **Execute o projeto**: 
Use o comando `docker-compose up` para executar o microsserviço e seu respectivo banco de dados mongodb.

5. **Acesse o swagger**: 
A aplicação sobe por padrão na porta 8000. Para acessa-la digite no seu navegador `localhost:8000/swagger`

6. **Acesse o mongodb**:
Caso queira acessar o mongodb, ele sobe por padrão na porta 27017. É possível se conectar através da connstring `mongodb://localhost:27017/db_investimento?replicaSet=rs0`

## Como utilizar a aplicação

É possível consultar a documentação da API e realizar chamadas através do swagger. Segue a documentação mais detalhada dos objetos de request nos diversos endpoints:

#### 🔵 GET /Carteira/{idCliente}/Extrato

Método responsável por obter o extrato de operações de determinado cliente.

**Parâmetros da URL**:

- `idCliente` (Guid): Identificador único do cliente. Este campo é obrigatório.

#### 🔵 GET /Carteira/{idCliente}

Método responsável por obter os dados da carteira de determinado cliente.

**Parâmetros da URL**:

- `idCliente` (Guid): Identificador único do cliente. Este campo é obrigatório.

---

#### 🟢 POST /Exchange/Comprar

Método responsável por enviar uma ordem de compra na carteira de determinado cliente.

**Parâmetros do corpo da solicitação**:

- `IdCliente` (Guid): Identificador único do cliente. Este campo é obrigatório.
- `NomeProdutoFinanceiro` (string): Nome do produto financeiro a ser comprado. Este campo é obrigatório. Exemplo: PETR4.
- `Quantidade` (int): Quantidade do produto financeiro a ser comprado. Este campo é obrigatório e deve ser maior que 0.

#### 🟢 POST /Exchange/Vender

Método responsável por enviar uma ordem de venda na carteira de determinado cliente.

**Parâmetros do corpo da solicitação**:

- `IdCliente` (Guid): Identificador único do cliente. Este campo é obrigatório.
- `NomeProdutoFinanceiro` (string): Nome do produto financeiro a ser vendido. Este campo é obrigatório. Exemplo: PETR4.
- `Quantidade` (int): Quantidade do produto financeiro a ser vendido. Este campo é obrigatório e deve ser maior que 0.

Para mais detalhes, consulte a documentação da API.

### AlphaVantage

Para consultar as cotações dos produtos financeiros está sendo usada a API aberta AlphaVantage.

## Evoluções

- Autenticação: garantir a segurança no consumo da aplicação.
- Ambientação: criar ambientes de dev, hlg e prd.
- Esteira CI/CD: realizar o deploy contínuo em uma esteira automatizada.
- Cloud: algum gerenciador de containers, como AKS.
- Observabilidade: aprimorar logs, métricas e traces.
- Monitoria: ferramentas para monitorar aplicação, como Grafana.

## Contribuição

Matheus Bezulle dos Anjos, (11) 97067-4857
