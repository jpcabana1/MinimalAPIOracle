# MinimalAPIOracle

## Commands:
- **_Tabelas Individuais:_** Scaffold-DbContext -Connection Name=XEPDB1 Oracle.EntityFrameworkCore -OutputDir Models -Tables TABELA1, TABELA2, TABELA3

- dotnet ef dbcontext scaffold Name=CONNECTION_STRING Oracle.EntityFrameworkCore -o Models  -t TABLE1 -t TABLE2
