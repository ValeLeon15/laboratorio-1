FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /usr/src/app

COPY db-config/entrypoint.sh /usr/src/app/entrypoint.sh
COPY db-config/persona_ddl_ms.sql /usr/src/app/persona_ddl_ms.sql
COPY db-config/persona_dml_ms.sql /usr/src/app/persona_dml_ms.sql
USER root
RUN chmod +x entrypoint.sh

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=Password123!
ENV MSSQL_PID=Developer

RUN apt-get update && apt-get install -y \
    mssql-tools unixodbc-dev 

# Añadir herramientas al PATH
ENV PATH="$PATH:/opt/mssql-tools/bin"

EXPOSE 1433

ENTRYPOINT ["/bin/bash", "/usr/src/app/entrypoint.sh"]
