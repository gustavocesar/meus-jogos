FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

COPY ["Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Application/MeusJogos.Contexts.JogoContext.Application.csproj", "Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Application/"]
COPY ["Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Domain/MeusJogos.Contexts.JogoContext.Domain.csproj", "Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Domain/"]
COPY ["Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Application/MeusJogos.Contexts.AmigoContext.Application.csproj", "Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Application/"]
COPY ["Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Domain/MeusJogos.Contexts.AmigoContext.Domain.csproj", "Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Domain/"]
COPY ["Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Application/MeusJogos.Contexts.EmprestimoContext.Application.csproj", "Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Application/"]
COPY ["Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Domain/MeusJogos.Contexts.EmprestimoContext.Domain.csproj", "Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Domain/"]
COPY ["Infra/CrossCutting/Auth/Auth.csproj", "Infra/CrossCutting/Auth/"]
COPY ["Infra/Data/MeusJogos.Infra.Data.EntityFramework/MeusJogos.Infra.Data.EntityFramework.csproj", "Infra/Data/MeusJogos.Infra.Data.EntityFramework/"]
COPY ["SharedKernel/MeusJogos.SharedKernel.Domain/MeusJogos.SharedKernel.Domain.csproj", "SharedKernel/MeusJogos.SharedKernel.Domain/"]


RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]