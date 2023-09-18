# Reverse Proxy POC

Este é um projeto de prova de conceito (POC) de um proxy reverso desenvolvido como parte de um trabalho acadêmico para a pós-graduação em Arquitetura de Software e Soluções. O proxy reverso é uma solução personalizada que tem o objetivo de demonstrar conceitos de balanceamento de carga, cache e roteamento de solicitações para diferentes serviços de destino.

## Visão Geral

O objetivo desta POC é explorar e aplicar conceitos essenciais de arquitetura de software relacionados a proxy reverso e suas funcionalidades. O proxy foi desenvolvido como uma aplicação ASP.NET Core e apresenta as seguintes funcionalidades:

- Balanceamento de carga: O proxy é capaz de distribuir o tráfego entre várias instâncias de serviços de destino registrados dinamicamente. Ele seleciona aleatoriamente um serviço de destino disponível para lidar com cada solicitação.

- Cache: O proxy inclui um mecanismo de cache de resposta para melhorar o desempenho. As respostas às solicitações são armazenadas em cache temporariamente, reduzindo a carga nos serviços de destino.

- Roteamento de solicitações: O proxy é configurado para rotear solicitações para serviços de destino com base em diferentes caminhos de URL. Cada caminho de URL é associado a um serviço de destino específico.

- Desacoplamento e Injeção de Dependência: A aplicação segue princípios de arquitetura de software que favorecem o desacoplamento e a injeção de dependência, facilitando a manutenção e extensibilidade do código.
