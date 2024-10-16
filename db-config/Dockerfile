FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /usr/src/app

COPY db-config/entrypoint.sh /usr/src/app/entrypoint.sh

USER root
RUN chmod +x entrypoint.sh

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=Password123!
ENV MSSQL_PID=Express


EXPOSE 1433

ENTRYPOINT ["/bin/bash", "/usr/src/app/entrypoint.sh"]
