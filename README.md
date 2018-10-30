# LivrariaV2

<h1>Sistema Livraria desenvolvido com microserviços e Api gateway utilizando OCELOT</h1>

<b>Trabalho de Api PUC Minas IEC</b></br></br>
<b>Disciplina:</b></br>
Arquitetura de BackEnd</br>
<b>Professor:</b></br>
Marco Mendes</br></br>
<b>Alunos:</b></br>
Alexandre Cunha Cruz Oliveira</br>
Henrique Franzoni Keppel</br>

<h4><p>O sistema foi desenvolvido utilizando o modelo arquitetural de microserviços com Api Gateway. Este ultimo foi desenvolvido
utilizando a tecnologia Ocelot, .netCore.</p></br>
<p>Devido ao objetivo de aprendizado das tecnologias de microserviçoes e Api Gateway, não foram desenvolvidas as regras de negócio
do projeto, são utilizados apenas exemplos fixos de consultas e inserções. Segue abaixo os exemplos que podem ser utilizados.</p>

<b>Todas as api's podem ser testadas utilizando o swagger, execeto a Api Gateay</b></br></br></h5>

<b>API LivroApi</b><br>
GET:
GET/{isnb}: Valores: Isbn = 1

POST, PUT ou DELETE podem ser usados quaisquer valores<br><br>

<b>API AutorApi</b><br>
GET:
GET/{id}: Valores 1 ou 2

POST, PUT ou DELETE podem ser usados quaisquer valores<br><br>

<b>API EditoraApi</b><br>
GET:
GET/{id}: Valores 1 ou 2

POST, PUT ou DELETE podem ser usados quaisquer valores<br><br>

<b>API AutenticacaoApi</b><br>
POST: 
{
  "email": "keppel@iec.com.br",
  "password": "123456"
}<br>
ValidaAutenticacao (NÃO IMPLEMENTADO)<br>

<b>API LoggerApi</b><br>
Post: quaisquer valores podem ser utilizados<br><br>

<b>API CartaoCreditoApi</b><br>
Post: quaisquer valores podem ser utilizados<br><br>


