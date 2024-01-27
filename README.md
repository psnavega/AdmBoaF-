## Descrição

Este projeto trata-se de uma implementação de uma API para a Administradora Boa Fé imobiliári

## Libs e dependências

<ul>
    <li>Linguagem: C#</li>
    <li>Plataforma: .NET Framework ou .NET Core ou .NET 7</li>
    <li>Banco de Dados: SQL Server</li>
    <li>Mapeamento objeto-relacional (ORM): Entity Framework</li>
</ul>

## Artefatos

Estrutura de dados na pasta doc, com o script do sql, bem como a visualização do diagrama

Caso a visualização do diagrama não esteja suficientemente bom na imagem em doc, clique <a href="https://miro.com/app/board/uXjVN4wcQAI=/?share_link_id=156706185326">aqui</a> para visualizá-lo na web

Vídeo de explicação do projeto: <a href="https://vimeo.com/903754395?share=copy">Aqui</a>

## Como Executar o Projeto ##

### Clone o repositório: ###
        
```bash
git clone https://github.com/psnavega/AdmBoaF-.git
```
Configure a string de conexão com o banco de dados no arquivo <code>appsettings.json</code>.</li>
```{
  "ConnectionStrings": {
    "DefaultConnection": "SuaStringDeConexao"
  }
}
```
Execute as migrações do banco de dados:

```
dotnet ef database update
```
Execute a aplicação:
```
dotnet run
```
Acesse <a href="http://localhost:7228">http://localhost:7228</a> no seu navegador.

## Extras ##

### Documentação da API ###

A documentação da API pode ser gerada automaticamente utilizando o Swagger. Acesse <a href="http://localhost:7228/swagger">http://localhost:72287228/swagger</a> após iniciar a aplicação.</p>

## Revisão ##

Gitflow:
    <ol>
        <li>Faça um fork do projeto.</li>
        <li>branch AdmBoaFé/patrick-navega</li>
        <li>PR nesse repositório</li>
    </ol>
</body>

## Observação ##

Feedbacks são bem vindos

Link p/ auxílio na conteinirização do banco de dados a quem interessar possa<a href="https://dev.to/cloudx/running-azure-sql-edge-on-docker-on-macos-m1-3lf5">aqui</a>
