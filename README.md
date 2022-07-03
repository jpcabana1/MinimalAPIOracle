# MinimalAPIOracle

## Commands:
- Scaffold-DbContext "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=GabinatorMobile)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=jpcabana;Password=otis2016;" Oracle.EntityFrameworkCore -OutputDir Models
- **_Tabelas Individuais:_** Scaffold-DbContext -Connection Name=XEPDB1 Oracle.EntityFrameworkCore -OutputDir Models -Tables TB_ANEXO_PROCESSO_GLOSA, TB_PRODUCAO_SERVICO, COUNTRIES