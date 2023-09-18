# Reverse Proxy POC

Este � um projeto de prova de conceito (POC) de um proxy reverso desenvolvido como parte de um trabalho acad�mico para a p�s-gradua��o em Arquitetura de Software e Solu��es. O proxy reverso � uma solu��o personalizada que tem o objetivo de demonstrar conceitos de balanceamento de carga, cache e roteamento de solicita��es para diferentes servi�os de destino.

## Vis�o Geral

O objetivo desta POC � explorar e aplicar conceitos essenciais de arquitetura de software relacionados a proxy reverso e suas funcionalidades. O proxy foi desenvolvido como uma aplica��o ASP.NET Core e apresenta as seguintes funcionalidades:

- Balanceamento de carga: O proxy � capaz de distribuir o tr�fego entre v�rias inst�ncias de servi�os de destino registrados dinamicamente. Ele seleciona aleatoriamente um servi�o de destino dispon�vel para lidar com cada solicita��o.

- Cache: O proxy inclui um mecanismo de cache de resposta para melhorar o desempenho. As respostas �s solicita��es s�o armazenadas em cache temporariamente, reduzindo a carga nos servi�os de destino.

- Roteamento de solicita��es: O proxy � configurado para rotear solicita��es para servi�os de destino com base em diferentes caminhos de URL. Cada caminho de URL � associado a um servi�o de destino espec�fico.

- Desacoplamento e Inje��o de Depend�ncia: A aplica��o segue princ�pios de arquitetura de software que favorecem o desacoplamento e a inje��o de depend�ncia, facilitando a manuten��o e extensibilidade do c�digo.