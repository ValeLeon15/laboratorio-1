#!/bin/bash
# Iniciar SQL Server en segundo plano
/opt/mssql/bin/sqlservr &
 
# Esperar a que SQL Server esté disponible
sleep 30s
 
# Variables de entorno
SA_PASSWORD=Password123!


# Ejecutar los scripts DDL y DML
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password123! -i /usr/src/app/persona_ddl_ms.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Password123! -i /usr/src/app/persona_dml_ms.sql
 
# Esperar a que finalice el proceso SQL Server
wait