FROM mcr.microsoft.com/dotnet/core/runtime:3.1
LABEL version="1.0" mainteiner="Gustavo César de Melo"
WORKDIR /app
COPY ./dist .
ENTRYPOINT [ "dotnet", "Presentation.dll" ]
