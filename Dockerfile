FROM mcr.microsoft.com/dotnet/core/runtime:3.1
LABEL version="1.0" mainteiner="Gustavo César de Melo"
WORKDIR /app
COPY ./dist .
ENTRYPOINT [ "dotnet", "Api.dll" ]

#COPY ["Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Application/MeusJogos.Contexts.JogoContext.Application.csproj", "Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Application/"]
#COPY ["Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Domain/MeusJogos.Contexts.JogoContext.Domain.csproj", "Contexts/JogoContext/MeusJogos.Contexts.JogoContext.Domain/"]
#COPY ["Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Application/MeusJogos.Contexts.AmigoContext.Application.csproj", "Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Application/"]
#COPY ["Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Domain/MeusJogos.Contexts.AmigoContext.Domain.csproj", "Contexts/AmigoContext/MeusJogos.Contexts.AmigoContext.Domain/"]
#COPY ["Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Application/MeusJogos.Contexts.EmprestimoContext.Application.csproj", "Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Application/"]
#COPY ["Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Domain/MeusJogos.Contexts.EmprestimoContext.Domain.csproj", "Contexts/EmprestimoContext/MeusJogos.Contexts.EmprestimoContext.Domain/"]
#COPY ["Infra/CrossCutting/Auth/Auth.csproj", "Infra/CrossCutting/Auth/"]
#COPY ["Infra/Data/MeusJogos.Infra.Data.EntityFramework/MeusJogos.Infra.Data.EntityFramework.csproj", "Infra/Data/MeusJogos.Infra.Data.EntityFramework/"]
#COPY ["SharedKernel/MeusJogos.SharedKernel.Domain/MeusJogos.SharedKernel.Domain.csproj", "SharedKernel/MeusJogos.SharedKernel.Domain/"]