# Checkout Inteligente (API - Back-end)

Este projeto é uma API desenvolvida em .NET 8 utilizando Entity Framework Core, destinada a simular operações de gerenciamento de um e-commerce. A API oferece um conjunto abrangente de funcionalidades que permitem a autenticação de administradores e clientes, além de operações de CRUD (Criar, Ler, Atualizar e Deletar) para campanhas, categorias e produtos.

-   **[Instalação](#instalação)**
-   **[Endpoints](#endpoints)**
-   **[Colaboradores](#colaboradores)**

## Instalação

### Pré-requisitos

Antes de começar, você precisa ter os seguintes itens instalados em sua máquina:

1. **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
2. **[MySQL Server](https://dev.mysql.com/downloads/mysql/)**
3. **[MySQL Workbench](https://dev.mysql.com/downloads/workbench/)** (opcional, mas recomendado para gerenciar o banco de dados)
4. **[Git](https://git-scm.com/downloads)**

### Clonando o Repositório

```bash
git clone https://github.com/VitorNuness/checkout-inteligente-back.git

cd checkout-inteligente-back
```

### Configurando o Banco de Dados

Após clonar o repositório, será necessário configurar a conexão com o banco em `appsettings.json`.

```json
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;userid=root;password=root_password;database=checkout"
},
```

Altere o `userid` e `password` para o usuário e a senha com permissões do seu banco. A `database` é opcional, mas se necessário, poderá atualizar para um nome de sua preferência.

### Executando as Migrações

Navegue até o projeto de infraestrutura:

```bash
cd src/Checkout/Infra
```

Para criar as tabelas no banco de dados, utilize o comando:

```bash
dotnet ef database update -s ../Presentation
```

### Executando o Projeto

Navegue até o projeto de infraestrutura:

```bash
cd ..//Presentation
```

Para executar o projeto, use o seguinte comando:

```bash
dotnet run
```

Ao executar o projeto, o Banco de Dados será atualizado com dados para demonstração.

O servidor deve iniciar e você verá uma mensagem indicando que a aplicação está rodando em http://localhost:5102.

## Endpoints

-   **[Auth](#auth)**
-   **[Campaign](#campaign)**
-   **[Category](#category)**
-   **[Order](#order)**
-   **[Report](#report)**
-   **[Product](#product)**

### Auth

#### **POST:** `/api/auth/register`

> Request:
>
> `'Content-Type: application/json'`
>
> ```json
> {
>     "name": "string",
>     "email": "string",
>     "password": "string"
> }
> ```
>
> Response:
>
> ```json
> {
>     "user": {
>         "id": 0,
>         "name": "string",
>         "email": "string",
>         "role": "string"
>     },
>     "token": "string"
> }
> ```

#### **POST:** `/api/auth/login`

> Request:
>
> `'Content-Type: application/json'`
>
> ```json
> {
>     "email": "string",
>     "password": "string"
> }
> ```
>
> Response:
>
> ```json
> {
>     "user": {
>         "id": 0,
>         "name": "string",
>         "email": "string",
>         "role": "string"
>     },
>     "token": "string"
> }
> ```

---

### Campaign

#### **GET:** `/api/campaigns`

> Response:
>
> ```json
> [
>     {
>         "id": 0,
>         "title": "string",
>         "products": [
>             {
>                 "id": 0,
>                 "name": "string",
>                 "quantity": 0,
>                 "price": 0,
>                 "imageUrl": "string",
>                 "sales": 0,
>                 "category": {
>                     "id": 0,
>                     "name": "string",
>                     "products": ["string"],
>                     "imageUrl": "string"
>                 },
>                 "campaigns": ["string"]
>             }
>         ],
>         "active": true,
>         "imageUrl": "string"
>     }
> ]
> ```

#### **GET:** `/api/campaigns/{id}`

> Parameters:
>
> -   `id=0`
>
> Response:
>
> ```json
> {
>     "id": 0,
>     "title": "string",
>     "products": [
>         {
>             "id": 0,
>             "name": "string",
>             "quantity": 0,
>             "price": 0,
>             "imageUrl": "string",
>             "sales": 0,
>             "category": {
>                 "id": 0,
>                 "name": "string",
>                 "products": ["string"],
>                 "imageUrl": "string"
>             },
>             "campaigns": ["string"]
>         }
>     ],
>     "active": true,
>     "imageUrl": "string"
> }
> ```

#### **POST:** `/api/campaigns`

> Request:
>
> `'Content-Type: multipart/form-data'`
>
> -   `Title="string"`
> -   `Active=true`
> -   `image="string"`
>
> Response:
>
> ```json
> {
>     "id": 0,
>     "title": "string",
>     "products": [
>         {
>             "id": 0,
>             "name": "string",
>             "quantity": 0,
>             "price": 0,
>             "imageUrl": "string",
>             "sales": 0,
>             "category": {
>                 "id": 0,
>                 "name": "string",
>                 "products": ["string"],
>                 "imageUrl": "string"
>             },
>             "campaigns": ["string"]
>         }
>     ],
>     "active": true,
>     "imageUrl": "string"
> }
> ```

#### **PUT:** `/api/campaigns/{id}`

> Parameters:
>
> -   `id=0`
>
> Request:
>
> `'Content-Type: multipart/form-data'`
>
> -   `Title="string"`
> -   `Active=true`
> -   `image="string"`
>
> Response:
>
> -   `200 - No content`

#### **DELETE:** `/api/campaigns/{id}`

> Parameters:
>
> -   `id=0`
>
> Response:
>
> -   `200 - No content`

---

### Category

#### **GET:** `/api/categories`

> Response:
>
> ```json
> [
>     {
>         "id": 0,
>         "name": "string",
>         "products": [
>             {
>                 "id": 0,
>                 "name": "string",
>                 "quantity": 0,
>                 "price": 0,
>                 "imageUrl": "string",
>                 "sales": 0,
>                 "category": "string",
>                 "campaigns": [
>                     {
>                         "id": 0,
>                         "title": "string",
>                         "products": ["string"],
>                         "active": true,
>                         "imageUrl": "string"
>                     }
>                 ]
>             }
>         ],
>         "imageUrl": "string"
>     }
> ]
> ```

#### **GET:** `/api/categories/{id}`

> Parameters:
>
> -   `id=0`
>
> Response:
>
> ```json
> {
>     "id": 0,
>     "name": "string",
>     "products": [
>         {
>             "id": 0,
>             "name": "string",
>             "quantity": 0,
>             "price": 0,
>             "imageUrl": "string",
>             "sales": 0,
>             "category": "string",
>             "campaigns": [
>                 {
>                     "id": 0,
>                     "title": "string",
>                     "products": ["string"],
>                     "active": true,
>                     "imageUrl": "string"
>                 }
>             ]
>         }
>     ],
>     "imageUrl": "string"
> }
> ```

#### **POST:** `/api/categories`

> Request:
>
> `'Content-Type: multipart/form-data'`
>
> -   `Name="string"`
> -   `image="string"`
>
> Response:
>
> ```json
> {
>     "id": 0,
>     "name": "string",
>     "products": [
>         {
>             "id": 0,
>             "name": "string",
>             "quantity": 0,
>             "price": 0,
>             "imageUrl": "string",
>             "sales": 0,
>             "category": "string",
>             "campaigns": [
>                 {
>                     "id": 0,
>                     "title": "string",
>                     "products": ["string"],
>                     "active": true,
>                     "imageUrl": "string"
>                 }
>             ]
>         }
>     ],
>     "imageUrl": "string"
> }
> ```

#### **PUT:** `/api/categories/{id}`

> Parameters:
>
> -   `id=0`
>
> Request:
>
> `'Content-Type: multipart/form-data'`
>
> -   `Name="string"`
> -   `image="string"`
>
> Response:
>
> -   `200 - No content`

#### **DELETE:** `/api/categories/{id}`

> Parameters:
>
> -   `id=0`
>
> Response:
>
> -   `200 - No content`

---

### Order

#### **GET:** `/api/orders/user/{userId}/orders/current`

> Paramenters:
>
> -   `userId=0`
>
> Response:
>
> ```json
> {
>     "id": 0,
>     "items": [
>         {
>             "productId": 0,
>             "product": {
>                 "id": 0,
>                 "name": "string",
>                 "quantity": 0,
>                 "price": 0,
>                 "imageUrl": "string",
>                 "sales": 0,
>                 "category": {
>                     "id": 0,
>                     "name": "string",
>                     "products": ["string"],
>                     "imageUrl": "string"
>                 },
>                 "campaigns": [
>                     {
>                         "id": 0,
>                         "title": "string",
>                         "products": ["string"],
>                         "active": true,
>                         "imageUrl": "string"
>                     }
>                 ]
>             },
>             "quantity": 0,
>             "total": 0
>         }
>     ],
>     "totalAmount": 0,
>     "status": "string",
>     "userId": 0
> }
> ```

#### **GET:** `/api/orders/user/{userId}/orders`

> Parameters:
>
> -   `userId=0`
>
> Response:
>
> ```json
> [
>     {
>         "id": 0,
>         "items": [
>             {
>                 "productId": 0,
>                 "product": {
>                     "id": 0,
>                     "name": "string",
>                     "quantity": 0,
>                     "price": 0,
>                     "imageUrl": "string",
>                     "sales": 0,
>                     "category": {
>                         "id": 0,
>                         "name": "string",
>                         "products": ["string"],
>                         "imageUrl": "string"
>                     },
>                     "campaigns": [
>                         {
>                             "id": 0,
>                             "title": "string",
>                             "products": ["string"],
>                             "active": true,
>                             "imageUrl": "string"
>                         }
>                     ]
>                 },
>                 "quantity": 0,
>                 "total": 0
>             }
>         ],
>         "totalAmount": 0,
>         "status": "string",
>         "userId": 0
>     }
> ]
> ```

#### **POST:** `/api/orders/{id}/add-product`

> Parameters:
>
> -   `id=0`
> -   `productId=0`
>
> Response:
>
> -   `200 - No content`

#### **POST:** `/api/orders/{id}/remove-product`

> Parameters:
>
> -   `id=0`
> -   `productId=0`
>
> Response:
>
> -   `200 - No content`

#### **POST:** `/api/orders/{id}/complete`

> Parameters:
>
> -   `id=0`
> -   `productId=0`
>
> Response:
>
> -   `200 - No content`

#### **POST:** `/api/orders/export/csv`

> Parameters:
>
> -   `startDate="string"`
> -   `endDate="string"`
>
> Response:
>
> -   `200 - No content`
---

### Report

#### **GET:** `/api/reports`

> Response:
>
> ```json
> [
>     {
>         "id": 0,
>         "name": "string",
>         "url": "string",
>         "reference": "string",
>         "createdAt": "string",
>     }
> ]
> ```

#### **DELETE:** `/api/reports/{id}`

> Parameters:
>
> -   `id=0`
>
> Response:
>
> -   `200 - No content`

---

### Product

#### **GET:** `/api/products`

> Response:
>
> ```json
> [
>     {
>         "id": 0,
>         "name": "string",
>         "quantity": 0,
>         "price": 0,
>         "imageUrl": "string",
>         "sales": 0,
>         "category": {
>             "id": 0,
>             "name": "string",
>             "products": ["string"],
>             "imageUrl": "string"
>         },
>         "campaigns": [
>             {
>                 "id": 0,
>                 "title": "string",
>                 "products": ["string"],
>                 "active": true,
>                 "imageUrl": "string"
>             }
>         ]
>     }
> ]
> ```

#### **GET:** `/api/products/best-sellers`

> Response:
>
> ```json
> [
>     {
>         "id": 0,
>         "name": "string",
>         "quantity": 0,
>         "price": 0,
>         "imageUrl": "string",
>         "sales": 0,
>         "category": {
>             "id": 0,
>             "name": "string",
>             "products": ["string"],
>             "imageUrl": "string"
>         },
>         "campaigns": [
>             {
>                 "id": 0,
>                 "title": "string",
>                 "products": ["string"],
>                 "active": true,
>                 "imageUrl": "string"
>             }
>         ]
>     }
> ]
> ```

#### **GET:** `/api/products/{id}`

> Parameters:
>
> -   `id=0`
>
> Response:
>
> ```json
> {
>     "id": 0,
>     "name": "string",
>     "quantity": 0,
>     "price": 0,
>     "imageUrl": "string",
>     "sales": 0,
>     "category": {
>         "id": 0,
>         "name": "string",
>         "products": ["string"],
>         "imageUrl": "string"
>     },
>     "campaigns": [
>         {
>             "id": 0,
>             "title": "string",
>             "products": ["string"],
>             "active": true,
>             "imageUrl": "string"
>         }
>     ]
> }
> ```

#### **POST:** `/api/products`

> Request:
>
> `'Content-Type: multipart/form-data'`
>
> -   `Name="string"`
> -   `Quantity=0`
> -   `Price=0`
> -   `CategoryId=0`
> -   `image="string"`
>
> Response:
>
> ```json
> {
>     "id": 0,
>     "name": "string",
>     "quantity": 0,
>     "price": 0,
>     "imageUrl": "string",
>     "sales": 0,
>     "category": {
>         "id": 0,
>         "name": "string",
>         "products": ["string"],
>         "imageUrl": "string"
>     },
>     "campaigns": [
>         {
>             "id": 0,
>             "title": "string",
>             "products": ["string"],
>             "active": true,
>             "imageUrl": "string"
>         }
>     ]
> }
> ```

#### **PUT:** `/api/products/{id}`

> Parameters:
>
> -   `id=0`
>
> Request:
>
> `'Content-Type: multipart/form-data'`
>
> -   `Name="string"`
> -   `Quantity=0`
> -   `Price=0`
> -   `CategoryId=0`
> -   `image="string"`
>
> Response:
>
> -   `200 - No content`

#### **DELETE:** `/api/categories/{id}`

> Parameters:
>
> -   `id=0`
>
> Response:
>
> -   `200 - No content`

---

## Colaboradores

**@[AlexHPasquini](https://github.com/AlexHPasquini) | @[MayconMacedo23](https://github.com/MayconMacedo23) | @[vinirainho](https://github.com/vinirainho) | @[VitorNuness](https://github.com/VitorNuness)**
