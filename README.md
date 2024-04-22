Orientação de como compilar/executar e realizar as requisições dos métodos GET, POST, PUT e DELETE via Postman:

1. *Verificar as configurações do projeto:*
   - Verifique se a SDK 5.0 está instalada na sua máquina, caso não esteja instale no seguinte link:
     --> https://dotnet.microsoft.com/pt-br/download/dotnet/5.0 

2. *Abrir o projeto seja ele pelo URL no GIT ou instalando o zip, descompactando e abrindo:*
   - Abra o editor de código da preferência, seja ele o Visual Studio, Visual Studio Code, Rider.
   - No menu principal, selecione "File" > "Open" e navegue até o diretório do seu projeto ou caso preferir copie a URL do repositório do GIT diretamente no editor de código da sua preferência.

3. **Compilar e executar o projeto:**
   - Abra o terminal, procure a pasta onde você armazenou o arquivo do repositório que foi baixado ou clonado, exemplo: cd ATAK, após isso você ja vai estar dentro da pasta, para executar basta digitar dotnet watch run. Após digitar no terminal o dotnet watch run ele irá compilar/executar o projeto e em seguida abrirá uma aba no seu navegador do localhost, a princípio a página não vai apresentar nada no localhost mas o seu projeto já irá estar funcionando para realizar as requisições de GET, PUT, POST e DELETE no POSTMAN.

# Usando Postman para realizar solicitações:

1. *Abrir o Postman:*
   - Abra o Postman no seu computador.

2. *Realizar uma solicitação GET:*
   - Para buscar um item por ID, insira o URL do localhost seguido pelo endpoint correspondente. Por exemplo:
     - https://localhost:5001/v1/todos/15 para buscar o item com o ID 15 ou outro ID que queira buscar.
   - Para buscar todos os itens ordenados por data crescente ou decrescente, insira o URL do localhost com o parâmetro de consulta sortOrder. Por exemplo:
     - https://localhost:5001/v1/todos?sortOrder=asc para ordenação ascendente.
     - https://localhost:5001/v1/todos?sortOrder=desc para ordenação descendente.

3. *Realizar uma solicitação POST:*
   - Para criar um novo item, insira o URL do localhost seguido pelo endpoint correspondente no Postman. Por exemplo:
     - https://localhost:5001/v1/todos
   - Selecione o tipo de requisição como "POST".
   - Selecione o tipo "raw" e o formato "JSON".
   - No corpo da requisição, insira os campos title, desc e status com os valores desejados em formato JSON. Por exemplo:
     
     {
       "title": "Nova tarefa",
       "desc": "Descrição da nova tarefa",
       "status": "Pendente"
     }
     
   - Envie a requisição para criar o novo item.

4. *Realizar uma solicitação PUT:*
   - Para editar um item existente, insira o URL do localhost seguido pelo endpoint correspondente no Postman. Por exemplo:
     - https://localhost:5001/v1/todos/15 para editar o item com o ID 15 ou outro ID que queira editar.
   - Selecione o tipo de requisição como "PUT".
   - Selecione o tipo "raw" e o formato "JSON".
   - No corpo da requisição, insira os campos title, desc e status com os valores desejados em formato JSON. Estes campos representam as informações que você deseja alterar no item.
   - Envie a requisição para editar o item.

5. *Realizar uma solicitação DELETE:*
   - Para excluir um item existente, insira o URL do localhost seguido pelo endpoint correspondente no Postman. Por exemplo:
     - https://localhost:5001/v1/todos/15 para excluir o item com o ID 15 ou outro ID que queira deletar.
   - Selecione o tipo de requisição como "DELETE".
   - Envie a requisição para excluir o item.


**Informações adicionais:**
  - Os pacotes utilizados nesse projeto foram os seguintes abaixo:
    --> Microsoft.EntityFrameworkCore.Sqlite;
    -->	Microsoft.EntityFrameworkCore.Design;
    -->	Microsoft.Data.Sqlite.Core.



