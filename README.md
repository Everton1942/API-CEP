# API de CEP

Esta é uma API em .NET C# que recebe em um endpoint uma lista de strings. Nessa lista, cada item é um CEP e a API consome uma API do Viacep.com para verificar se esse CEP é válido ou não. Se esse CEP for válido, a API retorna um JSON onde mostra as informações referentes a logradouro, bairro, cidade e estado de cada um desses CEPs. Se ele não for válido, a API retorna que ele está indisponível.

## Como usar

Para usar esta API, você precisa enviar uma requisição HTTP POST para o endpoint `/api/cep` com um corpo no formato JSON contendo uma lista de strings com os CEPs que você quer consultar. Por exemplo:

```json
[
  "01001000",
  "99999999",
  "12345678"
]
```

A API vai retornar uma resposta no formato JSON com uma lista de objetos do tipo `CepData`, que contém as seguintes propriedades:

- `Logradouro`: string que representa o nome da rua, avenida ou praça do CEP.
- `Bairro`: string que representa o nome do bairro do CEP.
- `Localidade`: string que representa o nome da cidade do CEP.
- `Uf`: string que representa a sigla do estado do CEP.
- `Valido`: booleano que indica se o CEP é válido ou não.

Por exemplo:

```json
{
  "ceps": [
    {
      "logradouro": "Praça da Sé",
      "bairro": "Sé",
      "localidade": "São Paulo",
      "uf": "SP",
      "valido": true
    },
    {
      "valido": false
    },
    {
      "logradouro": "Rua Teste",
      "bairro": "Teste",
      "localidade": "Teste",
      "uf": "TE",
      "valido": true
    }
  ]
}
```

## Como instalar

Para instalar esta API, você precisa ter o SDK do .NET instalado na sua máquina. Você também precisa clonar este repositório usando o comando:

```bash
git clone https://github.com/Everton1942/API-CEP
```

Depois de clonar o repositório, você pode abrir o projeto no Visual Studio Code ou no Visual Studio e executá-lo usando o comando:

```bash
dotnet run
```

A API vai rodar na porta 5000 por padrão, mas você pode alterar isso no arquivo `launchSettings.json`.

## Como testar

Para testar esta API, você pode usar qualquer ferramenta de teste de APIs, como o Postman ou o Insomnia. Você também pode usar o Swagger UI, que é uma interface web que permite visualizar e testar a API de forma interativa. Para acessar o Swagger UI, basta abrir o navegador e digitar o endereço:

```url
http://localhost:5000/swagger/index.html
```

Você vai ver a página do swagger e nela você pode ver a documentação da API, os endpoints disponíveis, os formatos de entrada e saída e os exemplos de requisições e respostas. Você também pode clicar no botão "Try it out" para enviar uma requisição para a API e ver o resultado na tela.

## Como contribuir

Se você quiser contribuir para esta API, você pode abrir uma issue ou um pull request neste repositório. Por favor, siga as boas práticas de desenvolvimento e documentação. Qualquer sugestão ou feedback é bem-vindo.
