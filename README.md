# Identity Server

É um framework que permite criar um servidor de autenticação.

## Duende Identity Server

É uma implementação do Identity Server.

## Terminologias do Identity Server

### Client

O cliente ele primeiro precisa ser registrado pra pode solicitar Token.

```cs
public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
            };
```

### Identity Resource

Os recursos de identidade são dados como userId, email, no. de telefone que são dados exclusivos para uma identidade do usuário.

```cs
public static IEnumerable<IdentityResource> IdentityResources =>
    new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    };
```

## Api Scopes

Os escopos representam o que um aplicativo cliente pode fazer e são normalmente modelados como recursos, que vêm em dois tipos: Identidade e API.

```cs
public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };
```

## Api Resource

Neste código definimos a própria API onde damos a ela o nome de myApi e definimos os escopos suportados junto com o secret, e, aqui , você tem que aplicar um hash neste secret, visto que este código hash será salvo internamente no IdentityServer.

```cs
  public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
               new ApiResource("myApi")
               {
                   Scopes = new List<string>{ "myApi.read","myApi.write" },
                   ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
               }
            };
```
