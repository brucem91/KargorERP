FROM node:8.12.0 AS client-env
WORKDIR /app/src/client
COPY ./src/client/package.json . 
RUN npm install
COPY ./src/client/. .
RUN npm run build

FROM microsoft/dotnet:2.1-sdk AS server-env
WORKDIR /app/src/server/KargorERP
COPY ./src/server/KargorERP/KargorERP.csproj .
RUN dotnet restore
COPY ./src/server/. ../
RUN dotnet publish -c Release -o ../../../dist/
WORKDIR /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=server-env ./app/dist/. .
COPY --from=client-env ./app/src/client/build/. ./wwwroot/.
ENTRYPOINT [ "dotnet", "KargorERP.dll" ]